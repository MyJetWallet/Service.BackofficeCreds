using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.BackofficeCreds.Domain.Models;
using Service.BackofficeCreds.Postgres;

namespace Service.BackofficeCreds.Engines
{
    public class BoCredManagerEngine
    {
        private readonly ILogger<BoCredManagerEngine> _logger;
        private readonly DatabaseContextFactory _databaseContextFactory;

        public BoCredManagerEngine(ILogger<BoCredManagerEngine> logger, 
            DatabaseContextFactory databaseContextFactory)
        {
            _logger = logger;
            _databaseContextFactory = databaseContextFactory;
        }

        public async Task CreateUserAsync(string email)
        {
            await using var ctx = _databaseContextFactory.Create();
            await ctx.UserCollection.Upsert(new User() {Email = email}).On(e => e.Email).RunAsync();
        }
        
        public async Task CreateRoleAsync(string name)
        {
            await using var ctx = _databaseContextFactory.Create();
            await ctx.RoleCollection.Upsert(new Role() {Name = name}).On(e => e.Name).RunAsync();
        }

        public async Task SetupRolesAsync(long userId, List<long> roles)
        {
            await using var ctx = _databaseContextFactory.Create();

            var actualRoles = ctx.UserInRoleCollection.Where(e => e.UserId == userId);
            if (actualRoles.Any())
                ctx.UserInRoleCollection.RemoveRange(actualRoles);
            
            var userInRoles = ctx.UserInRoleCollection.Where(e => e.UserId == userId);
            if (userInRoles.Any())
                ctx.UserInRoleCollection.RemoveRange(userInRoles);
            
            if (roles != null && roles.Any())
                await ctx.UserInRoleCollection.AddRangeAsync(roles.Select(e => new UserInRole(){UserId = userId, RoleId = e}));

            await ctx.SaveChangesAsync();
        }

        public async Task InitRightsAsync(IEnumerable<string> rights)
        {
            await using var ctx = _databaseContextFactory.Create();
            
            await ctx.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {DatabaseContext.Schema}.{DatabaseContext.RightTableName};");

            await ctx.RightCollection.AddRangeAsync(rights.Select(e => new Right() {Name = e}));
            await ctx.SaveChangesAsync(); 
        }

        public async Task RemoveUserAsync(long userId)
        {
            await using var ctx = _databaseContextFactory.Create();
            
            var userInRoles = ctx.UserInRoleCollection.Where(e => e.UserId == userId);
            if (userInRoles.Any())
                ctx.UserInRoleCollection.RemoveRange(userInRoles);

            var user = ctx.UserCollection.FirstOrDefault(e => e.Id == userId);
            if (user != null)
                ctx.UserCollection.Remove(user);
            
            await ctx.SaveChangesAsync(); 
        }

        public async Task RemoveRoleAsync(long roleId)
        {
            await using var ctx = _databaseContextFactory.Create();
            
            var userInRoles = ctx.UserInRoleCollection.Where(e => e.RoleId == roleId);
            if (userInRoles.Any())
                ctx.UserInRoleCollection.RemoveRange(userInRoles);
            
            var rightsInRole = ctx.RightInRoleCollection.Where(e => e.RoleId == roleId);
            if (rightsInRole.Any())
                ctx.RightInRoleCollection.RemoveRange(rightsInRole);

            var role = ctx.RoleCollection.FirstOrDefault(e => e.Id == roleId);
            if (role != null)
                ctx.RoleCollection.Remove(role);
            
            await ctx.SaveChangesAsync();
        }
    }
}