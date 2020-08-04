using Microsoft.EntityFrameworkCore.Migrations;

namespace TechartMap_back.DAL.Migrations
{
    public partial class addPlaceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "PlaceType",
                "Places",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PlaceType",
                "Places");
        }
    }
}