using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class GenericReservationProtocol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservasGenericas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicToken = table.Column<Guid>(type: "TEXT", nullable: false),
                    CodigoConfirmacion = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    FechaVisita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OcupantesTotales = table.Column<int>(type: "INTEGER", nullable: false),
                    PoseeHijos = table.Column<bool>(type: "INTEGER", nullable: false),
                    CantidadVehiculos = table.Column<int>(type: "INTEGER", nullable: false),
                    PoseeMascotas = table.Column<bool>(type: "INTEGER", nullable: false),
                    AceptaTerminos = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirmaData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    FirmaContentType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IdentidadData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    IdentidadContentType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IdentidadUploadedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DepositAmount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaCompletada = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasGenericas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservasGenericas_CodigoConfirmacion",
                table: "ReservasGenericas",
                column: "CodigoConfirmacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservasGenericas_Estado",
                table: "ReservasGenericas",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasGenericas_FechaSolicitud",
                table: "ReservasGenericas",
                column: "FechaSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasGenericas_PublicToken",
                table: "ReservasGenericas",
                column: "PublicToken",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasGenericas");
        }
    }
}
