using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechartMap_back.DAL.Migrations
{
    public partial class AddBannedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BannedUser",
                columns: table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Reason = table.Column<string>(nullable: false),
                    BanDate = table.Column<DateTime>(nullable: false),
                    Period = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedUser", x => x.Login);
                    table.ForeignKey(
                        name: "FK_BannedUser_Users_Login",
                        column: x => x.Login,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannedUser");
        }
    }
}
