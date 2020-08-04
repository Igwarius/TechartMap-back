using Microsoft.EntityFrameworkCore.Migrations;

namespace TechartMap_back.DAL.Migrations
{
    public partial class FixUserLoginType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Transactions_Users_UserLogin1",
                "Transactions");

            migrationBuilder.DropIndex(
                "IX_Transactions_UserLogin1",
                "Transactions");

            migrationBuilder.DropColumn(
                "UserLogin1",
                "Transactions");

            migrationBuilder.AlterColumn<string>(
                "UserLogin",
                "Transactions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                "IX_Transactions_UserLogin",
                "Transactions",
                "UserLogin");

            migrationBuilder.AddForeignKey(
                "FK_Transactions_Users_UserLogin",
                "Transactions",
                "UserLogin",
                "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Transactions_Users_UserLogin",
                "Transactions");

            migrationBuilder.DropIndex(
                "IX_Transactions_UserLogin",
                "Transactions");

            migrationBuilder.AlterColumn<int>(
                "UserLogin",
                "Transactions",
                "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "UserLogin1",
                "Transactions",
                "character varying(15)",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Transactions_UserLogin1",
                "Transactions",
                "UserLogin1");

            migrationBuilder.AddForeignKey(
                "FK_Transactions_Users_UserLogin1",
                "Transactions",
                "UserLogin1",
                "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }
    }
}