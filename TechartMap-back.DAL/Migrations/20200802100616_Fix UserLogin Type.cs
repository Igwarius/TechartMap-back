using Microsoft.EntityFrameworkCore.Migrations;

namespace TechartMap_back.DAL.Migrations
{
    public partial class FixUserLoginType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserLogin1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserLogin1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserLogin1",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "UserLogin",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserLogin",
                table: "Transactions",
                column: "UserLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserLogin",
                table: "Transactions",
                column: "UserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserLogin",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserLogin",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "UserLogin",
                table: "Transactions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLogin1",
                table: "Transactions",
                type: "character varying(15)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserLogin1",
                table: "Transactions",
                column: "UserLogin1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserLogin1",
                table: "Transactions",
                column: "UserLogin1",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
