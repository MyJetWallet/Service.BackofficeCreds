// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Service.BackofficeCreds.Postgres;

namespace Service.BackofficeCreds.Postgres.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("backoffice_creds")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Service.BackofficeCreds.Domain.Models.Right", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Service")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Service")
                        .IsUnique();

                    b.ToTable("right");
                });

            modelBuilder.Entity("Service.BackofficeCreds.Domain.Models.RightInRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("RightId")
                        .HasColumnType("bigint");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RightId", "RoleName")
                        .IsUnique();

                    b.ToTable("rightinrole");
                });

            modelBuilder.Entity("Service.BackofficeCreds.Domain.Models.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<bool>("IsSupervisor")
                        .HasColumnType("boolean");

                    b.HasKey("Name");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Name = "SupervisorRole",
                            IsSupervisor = true
                        });
                });

            modelBuilder.Entity("Service.BackofficeCreds.Domain.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Phone")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Telegram")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Email");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Email = "Supervisor",
                            IsActive = true,
                            Phone = "empty",
                            Telegram = "empty"
                        });
                });

            modelBuilder.Entity("Service.BackofficeCreds.Domain.Models.UserInRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserEmail", "RoleName")
                        .IsUnique();

                    b.ToTable("userinrole");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            RoleName = "SupervisorRole",
                            UserEmail = "Supervisor"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
