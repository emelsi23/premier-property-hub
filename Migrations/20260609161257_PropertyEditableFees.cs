using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class PropertyEditableFees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    DO $ef$
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Propiedades' AND column_name = 'StampsAmount') THEN
                            ALTER TABLE "Propiedades" ADD COLUMN "StampsAmount" numeric(10,2) NOT NULL DEFAULT 245;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Propiedades' AND column_name = 'SealsAmount') THEN
                            ALTER TABLE "Propiedades" ADD COLUMN "SealsAmount" numeric(10,2) NOT NULL DEFAULT 245;
                        END IF;
                    END
                    $ef$;

                    UPDATE "Propiedades" SET "StampsAmount" = 245 WHERE "StampsAmount" = 0;
                    UPDATE "Propiedades" SET "SealsAmount" = 245 WHERE "SealsAmount" = 0;
                    UPDATE "Propiedades" SET "DepositAmount" = 150 WHERE "DepositAmount" = 0;
                    """);
                return;
            }

            migrationBuilder.AddColumn<decimal>(
                name: "SealsAmount",
                table: "Propiedades",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 245m);

            migrationBuilder.AddColumn<decimal>(
                name: "StampsAmount",
                table: "Propiedades",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 245m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "Propiedades" DROP COLUMN IF EXISTS "StampsAmount";
                    ALTER TABLE "Propiedades" DROP COLUMN IF EXISTS "SealsAmount";
                    """);
                return;
            }

            migrationBuilder.DropColumn(name: "SealsAmount", table: "Propiedades");
            migrationBuilder.DropColumn(name: "StampsAmount", table: "Propiedades");
        }
    }
}
