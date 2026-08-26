using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class ReservaPaymentFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "ReservasGenericas" ADD COLUMN IF NOT EXISTS "MetodoPago" integer NOT NULL DEFAULT 0;
                    ALTER TABLE "ReservasGenericas" ADD COLUMN IF NOT EXISTS "PaymentProofContentType" character varying(100) NULL;
                    ALTER TABLE "ReservasGenericas" ADD COLUMN IF NOT EXISTS "PaymentProofData" bytea NULL;
                    ALTER TABLE "ReservasGenericas" ADD COLUMN IF NOT EXISTS "PaymentProofUploadedAt" timestamp with time zone NULL;

                    CREATE TABLE IF NOT EXISTS "ReservaPaymentSettings" (
                        "Id" integer PRIMARY KEY,
                        "DepositAmount" numeric(10,2) NOT NULL DEFAULT 150,
                        "NoShowFee" numeric(10,2) NOT NULL DEFAULT 10,
                        "ZelleDisplayName" character varying(120) NOT NULL DEFAULT 'Premier Property Hub',
                        "ZelleContact" character varying(120) NOT NULL DEFAULT '',
                        "ZelleInstructions" character varying(500) NOT NULL DEFAULT 'Envíe el depósito por Zelle e incluya su nombre completo en el mensaje.',
                        "ZelleEnabled" boolean NOT NULL DEFAULT true,
                        "BarcodeEnabled" boolean NOT NULL DEFAULT true,
                        "BarcodeInstructions" character varying(500) NOT NULL DEFAULT 'Pague en efectivo mostrando este código de barras y conserve su recibo.',
                        "BarcodeImageData" bytea NULL,
                        "BarcodeImageContentType" character varying(100) NULL,
                        "UpdatedAt" timestamp with time zone NOT NULL DEFAULT NOW()
                    );
                    """);
                return;
            }

            migrationBuilder.AddColumn<int>(
                name: "MetodoPago",
                table: "ReservasGenericas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentProofContentType",
                table: "ReservasGenericas",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PaymentProofData",
                table: "ReservasGenericas",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentProofUploadedAt",
                table: "ReservasGenericas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservaPaymentSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositAmount = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    NoShowFee = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    ZelleDisplayName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    ZelleContact = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    ZelleInstructions = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ZelleEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    BarcodeEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    BarcodeInstructions = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    BarcodeImageData = table.Column<byte[]>(type: "BLOB", nullable: true),
                    BarcodeImageContentType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaPaymentSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaPaymentSettings");

            migrationBuilder.DropColumn(
                name: "MetodoPago",
                table: "ReservasGenericas");

            migrationBuilder.DropColumn(
                name: "PaymentProofContentType",
                table: "ReservasGenericas");

            migrationBuilder.DropColumn(
                name: "PaymentProofData",
                table: "ReservasGenericas");

            migrationBuilder.DropColumn(
                name: "PaymentProofUploadedAt",
                table: "ReservasGenericas");
        }
    }
}
