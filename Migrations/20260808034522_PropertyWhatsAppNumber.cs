using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class PropertyWhatsAppNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhatsAppNumber",
                table: "Propiedades",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatsAppNumber",
                table: "Propiedades");
        }
    }
}
