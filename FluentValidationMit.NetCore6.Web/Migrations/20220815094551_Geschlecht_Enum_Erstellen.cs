using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentValidationMit.NetCore6.Web.Migrations
{
    public partial class Geschlecht_Enum_Erstellen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Geschlecht",
                table: "Kunden",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geschlecht",
                table: "Kunden");
        }
    }
}
