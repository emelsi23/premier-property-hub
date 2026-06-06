using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class CitaCamposExtra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Citas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SsnItin",
                table: "Citas",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "SsnItin",
                table: "Citas");
        }
    }
}
