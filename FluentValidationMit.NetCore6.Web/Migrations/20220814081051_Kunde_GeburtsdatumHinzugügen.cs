using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluentValidationMit.NetCore6.Web.Migrations
{
    public partial class Kunde_GeburtsdatumHinzugügen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "GeburtsDatum",
                table: "Kunden",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeburtsDatum",
                table: "Kunden");
        }
    }
}
