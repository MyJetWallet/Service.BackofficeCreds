using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Service.BackofficeCreds.Postgres;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Blazor.Engines
{
    public class BoAuthEngine
    {
        private readonly DatabaseContextFactory _databaseContextFactory;

        public BoAuthEngine(DatabaseContextFactory databaseContextFactory)
        {
            _databaseContextFactory = databaseContextFactory;
        }

        public async Task<string> Login(string service, string email)
        {
            await using var ctx = _databaseContextFactory.Create();

            var user = ctx.UserCollection.FirstOrDefault(e => e.Email == email);
            if (user == null || !user.IsActive)
                return string.Empty;

            var claims = new List<Claim> {new(ClaimTypes.Name, email)};
            
            var rolesNames = ctx.UserInRoleCollection
                .Where(e => e.UserEmail == user.Email).Select(e => e.RoleName).ToList();
            if (rolesNames.Any())
            {
                var roles = ctx.RoleCollection.Where(e => rolesNames.Contains(e.Name)).ToList();
                if (roles.Any())
                {
                    var rightsInRole = ctx.RightInRoleCollection
                        .Where(e => roles.Select(x => e.RoleName).Contains(e.RoleName));

                    var serviceRights = ctx.RightCollection
                        .Where(e => e.Service == service && rightsInRole.Select(x => x.RightId).Contains(e.Id));
                    
                    if (serviceRights.Any())
                        claims.AddRange(serviceRights.Select(right => new Claim(ClaimTypes.Role, right.Name)));
                }
            }
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Program.Settings.JwtSecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(Program.Settings.JwtExpiryInDays));

            var token = new JwtSecurityToken(
                Program.Settings.JwtIssuer,
                Program.Settings.JwtAudience,
                claims,
                expires: expiry,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        public async Task InitRightsAsync(string service, IEnumerable<string> rights)
        {
            await using var ctx = _databaseContextFactory.Create();

            var serviceRights = ctx.RightCollection.Where(e => e.Service == service);
            if (serviceRights.Any())
            {
                var rightsToRemove = serviceRights.Where(e => !rights.Contains(e.Name)).ToList();
                if (rightsToRemove.Any())
                {
                    var rightsInRoleToRemove = ctx.RightInRoleCollection
                        .Where(e => rightsToRemove.Select(x => x.Id).Contains(e.RightId))
                        .ToList();
                    if (rightsInRoleToRemove.Any())
                        ctx.RightInRoleCollection.RemoveRange(rightsInRoleToRemove);
                }
                ctx.RightCollection.RemoveRange(serviceRights);
            }
            await ctx.RightCollection.AddRangeAsync(rights.Select(e => new Right() {Name = e, Service = service}));
            await ctx.SaveChangesAsync(); 
        }
    }
}