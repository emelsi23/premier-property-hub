using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class AgentProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Slug = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    FotoUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    RolTitulo = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Calificacion = table.Column<decimal>(type: "TEXT", precision: 3, scale: 2, nullable: false),
                    TotalResenas = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroLicencia = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    EstadoLicencia = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    AnosExperiencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Biografia = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    AreasServicio = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Idiomas = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PropiedadesActivas = table.Column<int>(type: "INTEGER", nullable: false),
                    TiempoRespuestaHoras = table.Column<decimal>(type: "TEXT", precision: 5, scale: 2, nullable: false),
                    PorcentajeRespuesta = table.Column<int>(type: "INTEGER", nullable: false),
                    CodigoVerificacion = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                    Verificado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaVerificacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_Activo",
                table: "Agentes",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_CodigoVerificacion",
                table: "Agentes",
                column: "CodigoVerificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_Slug",
                table: "Agentes",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agentes");
        }
    }
}
