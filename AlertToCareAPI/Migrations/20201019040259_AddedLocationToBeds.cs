using Microsoft.EntityFrameworkCore.Migrations;

namespace AlertToCareAPI.Migrations
{
    public partial class AddedLocationToBeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "BedModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "BedModel");
        }
    }
}
