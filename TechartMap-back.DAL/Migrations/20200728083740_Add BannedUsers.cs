using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechartMap_back.DAL.Migrations
{
    public partial class AddBannedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "BannedUser",
                table => new
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
                        "FK_BannedUser_Users_Login",
                        x => x.Login,
                        "Users",
                        "Login",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BannedUser");
        }
    }
}