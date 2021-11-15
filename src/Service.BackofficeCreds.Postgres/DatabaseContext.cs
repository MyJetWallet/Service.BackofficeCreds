using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Postgres;
using Service.BackofficeCreds.Domain.Models;

namespace Service.BackofficeCreds.Postgres
{
    public class DatabaseContext : MyDbContext
    {
        public const string Schema = "backoffice_creds";
        
        private const string UserTableName = "user";
        private const string RoleTableName = "role";
        private const string UserInRoleTableName = "userinrole";
        private const string RightTableName = "right";
        private const string RightInRoleTableName = "rightinrole";
        
        public DbSet<User> UserCollection { get; set; }
        public DbSet<Role> RoleCollection { get; set; }
        public DbSet<UserInRole> UserInRoleCollection { get; set; }
        public DbSet<Right> RightCollection { get; set; }
        public DbSet<RightInRole> RightInRoleCollection { get; set; }
        
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            SetUserEntity(modelBuilder);
            SetRoleEntity(modelBuilder);
            SetUserInRoleEntity(modelBuilder);
            SetRightInRoleEntity(modelBuilder);
            SetRightEntity(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
            
            SetupDefaultData(modelBuilder);
        }

        private void SetupDefaultData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role() { Name = "SupervisorRole", IsSupervisor = true});
            modelBuilder.Entity<User>()
                .HasData(new User() { Email = "Supervisor", Phone = "empty", Telegram = "empty", IsActive = true});
            modelBuilder.Entity<UserInRole>()
                .HasData(new UserInRole() { UserEmail = "Supervisor", RoleName = "SupervisorRole", Id = 1});
        }

        private void SetRightInRoleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RightInRole>().ToTable(RightInRoleTableName);
            
            modelBuilder.Entity<RightInRole>().Property(e => e.Id).UseIdentityColumn();
            modelBuilder.Entity<RightInRole>().HasKey(e => e.Id);
            
            modelBuilder.Entity<RightInRole>().HasIndex(e => new {e.RightId, e.RoleName}).IsUnique();
        }

        private void SetRightEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Right>().ToTable(RightTableName);
            
            modelBuilder.Entity<Right>().Property(e => e.Id).UseIdentityColumn();
            modelBuilder.Entity<Right>().HasKey(e => e.Id);
            
            modelBuilder.Entity<Right>().Property(e => e.Name).HasMaxLength(64);
            
            modelBuilder.Entity<Right>().HasIndex(e => new{e.Name, e.Service}).IsUnique();
        }

        private void SetUserInRoleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().ToTable(UserInRoleTableName);
            
            modelBuilder.Entity<UserInRole>().Property(e => e.Id).UseIdentityColumn();
            modelBuilder.Entity<UserInRole>().HasKey(e => e.Id);
            
            modelBuilder.Entity<UserInRole>().HasIndex(e => new {e.UserEmail, e.RoleName}).IsUnique();
        }

        private void SetRoleEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable(RoleTableName);
            
            modelBuilder.Entity<Role>().HasKey(e => e.Name);
            
            modelBuilder.Entity<Role>().Property(e => e.Name).HasMaxLength(64);
        }

        private void SetUserEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable(UserTableName);
            
            modelBuilder.Entity<User>().HasKey(e => e.Email);
            
            modelBuilder.Entity<User>().Property(e => e.Email).HasMaxLength(256);
            modelBuilder.Entity<User>().Property(e => e.Phone).HasMaxLength(64);
            modelBuilder.Entity<User>().Property(e => e.Telegram).HasMaxLength(128);
        }
    }
}