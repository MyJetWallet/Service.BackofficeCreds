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

            var serviceRights = GetRightsForUser(user, service, ctx);

            if (serviceRights.Any())
                claims.AddRange(serviceRights.Select(right => new Claim(ClaimTypes.Role, right.Name)));
            
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

        private static List<Right> GetRightsForUser(User user, string service, DatabaseContext ctx)
        {
            var rights = new List<Right>();
            
            var rolesNames = ctx.UserInRoleCollection
                .Where(e => e.UserEmail == user.Email).Select(e => e.RoleName).ToList();
            if (!rolesNames.Any()) 
                return rights;
            
            var roles = ctx.RoleCollection.Where(e => rolesNames.Contains(e.Name)).ToList();
            if (!roles.Any())
                return rights;
            
            var rightsInRole = ctx.RightInRoleCollection
                .Where(e => roles.Select(x => x.Name).Contains(e.RoleName))
                .Select(e => e.RightId)
                .ToList();
            var serviceRights = ctx.RightCollection
                .Where(e => e.Service == service && rightsInRole.Contains(e.Id))
                .ToList();

            if (serviceRights.Any())
                rights.AddRange(serviceRights);

            return rights;
        }

        public async Task<(User, List<Right>)> LoginWithoutJwt(string service, string email)
        {
            await using var ctx = _databaseContextFactory.Create();

            var user = ctx.UserCollection.FirstOrDefault(e => e.Email == email);
            if (user == null || !user.IsActive)
                return (null, null);

            var rights = GetRightsForUser(user, service, ctx);

            return (user, rights);
        }
        
        public async Task InitRightsAsync(string service, List<string> rights)
        {
            await using var ctx = _databaseContextFactory.Create();

            var serviceRights = ctx.RightCollection.Where(e => e.Service == service).ToList();
            var rightsToRemove = serviceRights.Where(e => !rights.Contains(e.Name)).ToList();
            var newRights = rights.Where(e => !serviceRights.Select(x => x.Name).Contains(e)).ToList();
            
            if (rightsToRemove.Any())
            {
                var rightsInRoleToRemove = ctx.RightInRoleCollection
                    .Where(e => rightsToRemove.Select(x => x.Id).Contains(e.RightId))
                    .ToList();
                if (rightsInRoleToRemove.Any())
                    ctx.RightInRoleCollection.RemoveRange(rightsInRoleToRemove);
                    
                ctx.RightCollection.RemoveRange(rightsToRemove);
            }
            if (newRights.Any())
                await ctx.RightCollection.AddRangeAsync(newRights.Select(e => new Right() {Name = e, Service = service}));
            
            await ctx.SaveChangesAsync(); 
        }
    }
}