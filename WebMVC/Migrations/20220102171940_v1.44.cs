using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMVC.Migrations
{
    public partial class v144 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numeroPersonas",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numeroPersonas",
                table: "Reservas");
        }
    }
}
