using Microsoft.EntityFrameworkCore.Migrations;

namespace TechartMap_back.DAL.Migrations
{
    public partial class AddRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "RefreshTokens",
                table => new
                {
                    Login = table.Column<string>(nullable: false),
                    Token = table.Column<string>("varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Login);
                    table.ForeignKey(
                        "FK_RefreshTokens_Users_Login",
                        x => x.Login,
                        "Users",
                        "Login",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "RefreshTokens");
        }
    }
}