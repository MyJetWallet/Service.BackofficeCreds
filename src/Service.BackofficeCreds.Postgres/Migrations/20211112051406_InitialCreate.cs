using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Service.BackofficeCreds.Postgres.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "backoffice_creds");

            migrationBuilder.CreateTable(
                name: "right",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Service = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_right", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rightinrole",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RightId = table.Column<long>(type: "bigint", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rightinrole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    IsSupervisor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Telegram = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "userinrole",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    RoleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userinrole", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "backoffice_creds",
                table: "role",
                columns: new[] { "Name", "IsSupervisor" },
                values: new object[] { "SupervisorRole", true });

            migrationBuilder.InsertData(
                schema: "backoffice_creds",
                table: "user",
                columns: new[] { "Email", "IsActive", "Phone", "Telegram" },
                values: new object[] { "Supervisor", true, "empty", "empty" });

            migrationBuilder.InsertData(
                schema: "backoffice_creds",
                table: "userinrole",
                columns: new[] { "Id", "RoleName", "UserEmail" },
                values: new object[] { 1L, "SupervisorRole", "Supervisor" });

            migrationBuilder.CreateIndex(
                name: "IX_right_Name_Service",
                schema: "backoffice_creds",
                table: "right",
                columns: new[] { "Name", "Service" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rightinrole_RightId_RoleName",
                schema: "backoffice_creds",
                table: "rightinrole",
                columns: new[] { "RightId", "RoleName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userinrole_UserEmail_RoleName",
                schema: "backoffice_creds",
                table: "userinrole",
                columns: new[] { "UserEmail", "RoleName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "right",
                schema: "backoffice_creds");

            migrationBuilder.DropTable(
                name: "rightinrole",
                schema: "backoffice_creds");

            migrationBuilder.DropTable(
                name: "role",
                schema: "backoffice_creds");

            migrationBuilder.DropTable(
                name: "user",
                schema: "backoffice_creds");

            migrationBuilder.DropTable(
                name: "userinrole",
                schema: "backoffice_creds");
        }
    }
}
