using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class MultiAdminAgentIsolation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "ReservasGenericas" ADD COLUMN IF NOT EXISTS "AdminUsername" character varying(64) NOT NULL DEFAULT '';
                    ALTER TABLE "ReservaPaymentSettings" ADD COLUMN IF NOT EXISTS "AdminUsername" character varying(64) NOT NULL DEFAULT '';
                    ALTER TABLE "Citas" ADD COLUMN IF NOT EXISTS "AdminUsername" character varying(64) NOT NULL DEFAULT '';

                    UPDATE "ReservaPaymentSettings" SET "AdminUsername" = 'admin000' WHERE "AdminUsername" = '';
                    UPDATE "ReservasGenericas" SET "AdminUsername" = 'admin000' WHERE "AdminUsername" = '';

                    CREATE INDEX IF NOT EXISTS "IX_ReservasGenericas_AdminUsername" ON "ReservasGenericas" ("AdminUsername");
                    CREATE UNIQUE INDEX IF NOT EXISTS "IX_ReservaPaymentSettings_AdminUsername" ON "ReservaPaymentSettings" ("AdminUsername");
                    CREATE INDEX IF NOT EXISTS "IX_Citas_AdminUsername" ON "Citas" ("AdminUsername");
                    """);
                return;
            }

            migrationBuilder.AddColumn<string>(
                name: "AdminUsername",
                table: "ReservasGenericas",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminUsername",
                table: "ReservaPaymentSettings",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminUsername",
                table: "Citas",
                type: "TEXT",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("""
                UPDATE ReservaPaymentSettings SET AdminUsername = 'admin000' WHERE AdminUsername = '';
                UPDATE ReservasGenericas SET AdminUsername = 'admin000' WHERE AdminUsername = '';
                """);

            migrationBuilder.CreateIndex(
                name: "IX_ReservasGenericas_AdminUsername",
                table: "ReservasGenericas",
                column: "AdminUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPaymentSettings_AdminUsername",
                table: "ReservaPaymentSettings",
                column: "AdminUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_AdminUsername",
                table: "Citas",
                column: "AdminUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReservasGenericas_AdminUsername",
                table: "ReservasGenericas");

            migrationBuilder.DropIndex(
                name: "IX_ReservaPaymentSettings_AdminUsername",
                table: "ReservaPaymentSettings");

            migrationBuilder.DropIndex(
                name: "IX_Citas_AdminUsername",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "AdminUsername",
                table: "ReservasGenericas");

            migrationBuilder.DropColumn(
                name: "AdminUsername",
                table: "ReservaPaymentSettings");

            migrationBuilder.DropColumn(
                name: "AdminUsername",
                table: "Citas");
        }
    }
}
