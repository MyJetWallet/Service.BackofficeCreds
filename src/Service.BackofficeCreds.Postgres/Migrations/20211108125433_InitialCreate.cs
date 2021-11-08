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
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
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
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    IsSupervisor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userinrole",
                schema: "backoffice_creds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userinrole", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "backoffice_creds",
                table: "role",
                columns: new[] { "Id", "IsSupervisor", "Name" },
                values: new object[] { 1L, true, "Supervisor" });

            migrationBuilder.InsertData(
                schema: "backoffice_creds",
                table: "user",
                columns: new[] { "Id", "Email" },
                values: new object[] { 1L, "Supervisor" });

            migrationBuilder.InsertData(
                schema: "backoffice_creds",
                table: "userinrole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_right_Name",
                schema: "backoffice_creds",
                table: "right",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rightinrole_RightId_RoleId",
                schema: "backoffice_creds",
                table: "rightinrole",
                columns: new[] { "RightId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_Name",
                schema: "backoffice_creds",
                table: "role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                schema: "backoffice_creds",
                table: "user",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userinrole_UserId_RoleId",
                schema: "backoffice_creds",
                table: "userinrole",
                columns: new[] { "UserId", "RoleId" },
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
