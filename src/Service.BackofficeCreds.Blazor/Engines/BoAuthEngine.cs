using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Service.BackofficeCreds.Postgres;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Service.BackofficeCreds.Blazor.Engines
{
    public class BoAuthEngine
    {
        private readonly DatabaseContextFactory _databaseContextFactory;

        public BoAuthEngine(DatabaseContextFactory databaseContextFactory)
        {
            _databaseContextFactory = databaseContextFactory;
        }

        public async Task<string> Login(string email)
        {
            await using var ctx = _databaseContextFactory.Create();

            var user = ctx.UserCollection.FirstOrDefault(e => e.Email == email);
            if (user == null)
                return string.Empty;

            var claims = new List<Claim> {new(ClaimTypes.Name, email)};
            
            var rolesId = ctx.UserInRoleCollection.Where(e => e.UserId == user.Id).Select(e => e.RoleId).ToList();
            if (rolesId.Any())
            {
                var roles = ctx.RoleCollection.Where(e => rolesId.Contains(e.Id)).ToList();
                if (roles.Any())
                    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
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
    }
}