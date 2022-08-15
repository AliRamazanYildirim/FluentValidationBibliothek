using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentValidationMit.NetCore6.Web.Migrations
{
    public partial class Adresse_Entity_Erstellen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inhalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provinz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostleitZahl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KundeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adressen_Kunden_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunden",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_KundeId",
                table: "Adressen",
                column: "KundeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adressen");
        }
    }
}
