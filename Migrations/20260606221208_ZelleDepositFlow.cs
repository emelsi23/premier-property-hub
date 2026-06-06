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

            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    UPDATE "Citas"
                    SET "PublicToken" = gen_random_uuid()
                    WHERE "PublicToken" = '00000000-0000-0000-0000-000000000000';

                    ALTER TABLE "Propiedades" ALTER COLUMN "DepositAmount" TYPE numeric(10,2) USING 0::numeric;
                    ALTER TABLE "Citas" ALTER COLUMN "PublicToken" TYPE uuid USING "PublicToken"::uuid;
                    ALTER TABLE "Citas" ALTER COLUMN "PaymentProofData" TYPE bytea USING NULL::bytea;
                    ALTER TABLE "Citas" ALTER COLUMN "PaymentProofUploadedAt" TYPE timestamp with time zone USING NULL::timestamptz;
                    """);
            }
            else
            {
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
            }

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
