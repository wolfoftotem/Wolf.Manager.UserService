using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wolf.ManagerService.Domain.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<Guid>(maxLength: 36, nullable: false),
                    account = table.Column<string>(maxLength: 30, nullable: false),
                    real_name = table.Column<string>(maxLength: 20, nullable: true),
                    password_salt = table.Column<string>(maxLength: 6, nullable: false),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    user_state = table.Column<int>(nullable: false),
                    register_time = table.Column<DateTimeOffset>(nullable: false),
                    forbit_time = table.Column<DateTimeOffset>(nullable: true),
                    last_update_time = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin_login_records",
                columns: table => new
                {
                    id = table.Column<Guid>(maxLength: 36, nullable: false),
                    user_id = table.Column<Guid>(maxLength: 36, nullable: false),
                    appid = table.Column<int>(nullable: false),
                    ip = table.Column<string>(maxLength: 15, nullable: true),
                    user_agent = table.Column<string>(maxLength: 500, nullable: true),
                    create_time = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_login_records", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    application_id = table.Column<int>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 20, nullable: false),
                    state = table.Column<bool>(nullable: false),
                    summary = table.Column<string>(maxLength: 50, nullable: true),
                    create_time = table.Column<DateTimeOffset>(nullable: false),
                    add_user_id = table.Column<Guid>(nullable: false),
                    update_time = table.Column<DateTimeOffset>(nullable: false),
                    edit_user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 20, nullable: false),
                    summary = table.Column<string>(maxLength: 200, nullable: true),
                    state = table.Column<bool>(nullable: false),
                    create_time = table.Column<DateTimeOffset>(nullable: false),
                    create_user_id = table.Column<Guid>(nullable: false),
                    update_time = table.Column<DateTimeOffset>(nullable: false),
                    update_user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "admin_login_records");

            migrationBuilder.DropTable(
                name: "admin_roles");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
