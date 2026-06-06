using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class ZelleDepositFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "Propiedades" ADD COLUMN IF NOT EXISTS "DepositAmount" numeric(10,2) NOT NULL DEFAULT 0;
                    ALTER TABLE "Propiedades" ADD COLUMN IF NOT EXISTS "ZelleContact" character varying(120) NOT NULL DEFAULT '';
                    ALTER TABLE "Propiedades" ADD COLUMN IF NOT EXISTS "ZelleDisplayName" character varying(120) NOT NULL DEFAULT '';
                    ALTER TABLE "Citas" ADD COLUMN IF NOT EXISTS "PaymentProofContentType" character varying(100) NULL;
                    ALTER TABLE "Citas" ADD COLUMN IF NOT EXISTS "PaymentProofData" bytea NULL;
                    ALTER TABLE "Citas" ADD COLUMN IF NOT EXISTS "PaymentProofUploadedAt" timestamp with time zone NULL;
                    ALTER TABLE "Citas" ADD COLUMN IF NOT EXISTS "PublicToken" uuid NOT NULL DEFAULT gen_random_uuid();

                    UPDATE "Citas"
                    SET "PublicToken" = gen_random_uuid()
                    WHERE "PublicToken" = '00000000-0000-0000-0000-000000000000'::uuid;

                    CREATE UNIQUE INDEX IF NOT EXISTS "IX_Citas_PublicToken" ON "Citas" ("PublicToken");
                    """);
                return;
            }

            migrationBuilder.AddColumn<decimal>(
                name: "DepositAmount",
                table: "Propiedades",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ZelleContact",
                table: "Propiedades",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZelleDisplayName",
                table: "Propiedades",
                type: "TEXT",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentProofContentType",
                table: "Citas",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PaymentProofData",
                table: "Citas",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentProofUploadedAt",
                table: "Citas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PublicToken",
                table: "Citas",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.Sql("""
                UPDATE Citas
                SET PublicToken = lower(
                    hex(randomblob(4)) || '-' ||
                    hex(randomblob(2)) || '-4' ||
                    substr(hex(randomblob(2)), 2) || '-' ||
                    substr('89ab', abs(random()) % 4 + 1, 1) ||
                    substr(hex(randomblob(2)), 2) || '-' ||
                    hex(randomblob(6))
                )
                WHERE PublicToken = '00000000-0000-0000-0000-000000000000';
                """);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PublicToken",
                table: "Citas",
                column: "PublicToken",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Citas_PublicToken",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "DepositAmount",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "ZelleContact",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "ZelleDisplayName",
                table: "Propiedades");

            migrationBuilder.DropColumn(
                name: "PaymentProofContentType",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "PaymentProofData",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "PaymentProofUploadedAt",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "PublicToken",
                table: "Citas");
        }
    }
}
