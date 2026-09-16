using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class OptionalReservaIdentitySelfie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "ReservaPaymentSettings"
                    ADD COLUMN IF NOT EXISTS "RequireIdentitySelfie" boolean NOT NULL DEFAULT true;
                    """);
                return;
            }

            migrationBuilder.AddColumn<bool>(
                name: "RequireIdentitySelfie",
                table: "ReservaPaymentSettings",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "ReservaPaymentSettings"
                    DROP COLUMN IF EXISTS "RequireIdentitySelfie";
                    """);
                return;
            }

            migrationBuilder.DropColumn(
                name: "RequireIdentitySelfie",
                table: "ReservaPaymentSettings");
        }
    }
}
