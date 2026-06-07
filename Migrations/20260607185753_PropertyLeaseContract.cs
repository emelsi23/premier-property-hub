using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class PropertyLeaseContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropiedadId",
                table: "LeaseContracts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropiedadId",
                table: "ContractSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("""
                UPDATE "LeaseContracts"
                SET "PropiedadId" = (SELECT "Id" FROM "Propiedades" ORDER BY "Id" LIMIT 1)
                WHERE "PropiedadId" = 0 AND EXISTS (SELECT 1 FROM "Propiedades");

                UPDATE "ContractSubmissions"
                SET "PropiedadId" = (SELECT "Id" FROM "Propiedades" ORDER BY "Id" LIMIT 1)
                WHERE "PropiedadId" = 0 AND EXISTS (SELECT 1 FROM "Propiedades");
                """);

            migrationBuilder.CreateIndex(
                name: "IX_LeaseContracts_PropiedadId",
                table: "LeaseContracts",
                column: "PropiedadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractSubmissions_PropiedadId",
                table: "ContractSubmissions",
                column: "PropiedadId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractSubmissions_Propiedades_PropiedadId",
                table: "ContractSubmissions",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseContracts_Propiedades_PropiedadId",
                table: "LeaseContracts",
                column: "PropiedadId",
                principalTable: "Propiedades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractSubmissions_Propiedades_PropiedadId",
                table: "ContractSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaseContracts_Propiedades_PropiedadId",
                table: "LeaseContracts");

            migrationBuilder.DropIndex(
                name: "IX_LeaseContracts_PropiedadId",
                table: "LeaseContracts");

            migrationBuilder.DropIndex(
                name: "IX_ContractSubmissions_PropiedadId",
                table: "ContractSubmissions");

            migrationBuilder.DropColumn(
                name: "PropiedadId",
                table: "LeaseContracts");

            migrationBuilder.DropColumn(
                name: "PropiedadId",
                table: "ContractSubmissions");
        }
    }
}
