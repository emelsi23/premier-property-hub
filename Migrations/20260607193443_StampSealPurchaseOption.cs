using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class StampSealPurchaseOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    DO $ef$
                    BEGIN
                        IF NOT EXISTS (
                            SELECT 1 FROM information_schema.columns
                            WHERE table_schema = 'public'
                              AND table_name = 'StampSealSubmissions'
                              AND column_name = 'PurchaseOption'
                        ) THEN
                            ALTER TABLE "StampSealSubmissions"
                                ADD COLUMN "PurchaseOption" integer NOT NULL DEFAULT 2;
                        END IF;

                        IF NOT EXISTS (
                            SELECT 1 FROM information_schema.columns
                            WHERE table_schema = 'public'
                              AND table_name = 'StampSealSubmissions'
                              AND column_name = 'SelectedAmount'
                        ) THEN
                            ALTER TABLE "StampSealSubmissions"
                                ADD COLUMN "SelectedAmount" numeric NOT NULL DEFAULT 490;
                        END IF;
                    END
                    $ef$;

                    UPDATE "StampSealSubmissions"
                    SET "PurchaseOption" = 2,
                        "SelectedAmount" = 490
                    WHERE "SelectedAmount" = 0;
                    """);
                return;
            }

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOption",
                table: "StampSealSubmissions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "SelectedAmount",
                table: "StampSealSubmissions",
                type: "TEXT",
                nullable: false,
                defaultValue: 490m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "StampSealSubmissions" DROP COLUMN IF EXISTS "PurchaseOption";
                    ALTER TABLE "StampSealSubmissions" DROP COLUMN IF EXISTS "SelectedAmount";
                    """);
                return;
            }

            migrationBuilder.DropColumn(
                name: "PurchaseOption",
                table: "StampSealSubmissions");

            migrationBuilder.DropColumn(
                name: "SelectedAmount",
                table: "StampSealSubmissions");
        }
    }
}
