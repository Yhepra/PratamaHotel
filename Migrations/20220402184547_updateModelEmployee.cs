using Microsoft.EntityFrameworkCore.Migrations;

namespace PratamaHotel.Migrations
{
    public partial class updateModelEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createDate",
                table: "Employees",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Employees");
        }
    }
}
