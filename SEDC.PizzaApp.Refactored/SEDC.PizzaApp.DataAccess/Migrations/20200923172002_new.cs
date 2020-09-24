using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMBG",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasExtras",
                table: "Pizzas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMBG",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasExtras",
                table: "Pizzas",
                nullable: true);
        }
    }
}
