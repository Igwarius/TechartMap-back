using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TechartMap_back.DAL.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BannedUser_Users_Login",
                "BannedUser");

            migrationBuilder.DropPrimaryKey(
                "PK_BannedUser",
                "BannedUser");

            migrationBuilder.RenameTable(
                "BannedUser",
                newName: "BannedUsers");

            migrationBuilder.AddPrimaryKey(
                "PK_BannedUsers",
                "BannedUsers",
                "Login");

            migrationBuilder.CreateTable(
                "Cities",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Cities", x => x.Id); });

            migrationBuilder.CreateTable(
                "Films",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    AgeLimit = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Films", x => x.Id); });

            migrationBuilder.CreateTable(
                "Cinemas",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                    table.ForeignKey(
                        "FK_Cinemas_Cities_CityId",
                        x => x.CityId,
                        "Cities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Halls",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    CinemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                    table.ForeignKey(
                        "FK_Halls_Cinemas_CinemaId",
                        x => x.CinemaId,
                        "Cinemas",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Rows",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    HallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rows", x => x.Id);
                    table.ForeignKey(
                        "FK_Rows_Halls_HallId",
                        x => x.HallId,
                        "Halls",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Sessions",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false),
                    HallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        "FK_Sessions_Films_FilmId",
                        x => x.FilmId,
                        "Films",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Sessions_Halls_HallId",
                        x => x.HallId,
                        "Halls",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Places",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    RowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        "FK_Places_Rows_RowId",
                        x => x.RowId,
                        "Rows",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Transactions",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionType = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    UserLogin = table.Column<int>(nullable: false),
                    UserLogin1 = table.Column<string>(nullable: true),
                    SessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        "FK_Transactions_Sessions_SessionId",
                        x => x.SessionId,
                        "Sessions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Transactions_Users_UserLogin1",
                        x => x.UserLogin1,
                        "Users",
                        "Login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Cinemas_CityId",
                "Cinemas",
                "CityId");

            migrationBuilder.CreateIndex(
                "IX_Halls_CinemaId",
                "Halls",
                "CinemaId");

            migrationBuilder.CreateIndex(
                "IX_Places_RowId",
                "Places",
                "RowId");

            migrationBuilder.CreateIndex(
                "IX_Rows_HallId",
                "Rows",
                "HallId");

            migrationBuilder.CreateIndex(
                "IX_Sessions_FilmId",
                "Sessions",
                "FilmId");

            migrationBuilder.CreateIndex(
                "IX_Sessions_HallId",
                "Sessions",
                "HallId");

            migrationBuilder.CreateIndex(
                "IX_Transactions_SessionId",
                "Transactions",
                "SessionId");

            migrationBuilder.CreateIndex(
                "IX_Transactions_UserLogin1",
                "Transactions",
                "UserLogin1");

            migrationBuilder.AddForeignKey(
                "FK_BannedUsers_Users_Login",
                "BannedUsers",
                "Login",
                "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BannedUsers_Users_Login",
                "BannedUsers");

            migrationBuilder.DropTable(
                "Places");

            migrationBuilder.DropTable(
                "Transactions");

            migrationBuilder.DropTable(
                "Rows");

            migrationBuilder.DropTable(
                "Sessions");

            migrationBuilder.DropTable(
                "Films");

            migrationBuilder.DropTable(
                "Halls");

            migrationBuilder.DropTable(
                "Cinemas");

            migrationBuilder.DropTable(
                "Cities");

            migrationBuilder.DropPrimaryKey(
                "PK_BannedUsers",
                "BannedUsers");

            migrationBuilder.RenameTable(
                "BannedUsers",
                newName: "BannedUser");

            migrationBuilder.AddPrimaryKey(
                "PK_BannedUser",
                "BannedUser",
                "Login");

            migrationBuilder.AddForeignKey(
                "FK_BannedUser_Users_Login",
                "BannedUser",
                "Login",
                "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }
    }
}