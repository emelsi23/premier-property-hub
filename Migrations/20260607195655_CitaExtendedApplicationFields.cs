using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class CitaExtendedApplicationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    DO $ef$
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'ApellidoCliente') THEN
                            ALTER TABLE "Citas" ADD COLUMN "ApellidoCliente" character varying(80) NOT NULL DEFAULT '';
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'CodigoPostal') THEN
                            ALTER TABLE "Citas" ADD COLUMN "CodigoPostal" character varying(10) NULL;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'EsCiudadanoAmericano') THEN
                            ALTER TABLE "Citas" ADD COLUMN "EsCiudadanoAmericano" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'PersonasEnUnidad') THEN
                            ALTER TABLE "Citas" ADD COLUMN "PersonasEnUnidad" integer NOT NULL DEFAULT 1;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'DuracionContratoDeseada') THEN
                            ALTER TABLE "Citas" ADD COLUMN "DuracionContratoDeseada" character varying(80) NULL;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'FechaMudanzaTemprana') THEN
                            ALTER TABLE "Citas" ADD COLUMN "FechaMudanzaTemprana" timestamp with time zone NULL;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'Fuma') THEN
                            ALTER TABLE "Citas" ADD COLUMN "Fuma" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'EmpleadoActualmente') THEN
                            ALTER TABLE "Citas" ADD COLUMN "EmpleadoActualmente" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'NombreCompania') THEN
                            ALTER TABLE "Citas" ADD COLUMN "NombreCompania" character varying(120) NULL;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'Salario') THEN
                            ALTER TABLE "Citas" ADD COLUMN "Salario" numeric(10,2) NULL;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'DisponibleParaAsegurar') THEN
                            ALTER TABLE "Citas" ADD COLUMN "DisponibleParaAsegurar" numeric(10,2) NULL;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'TieneMascotas') THEN
                            ALTER TABLE "Citas" ADD COLUMN "TieneMascotas" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'AceptaDepositoReserva') THEN
                            ALTER TABLE "Citas" ADD COLUMN "AceptaDepositoReserva" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'PagaraCitaCertificada') THEN
                            ALTER TABLE "Citas" ADD COLUMN "PagaraCitaCertificada" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Citas' AND column_name = 'MetodoPago') THEN
                            ALTER TABLE "Citas" ADD COLUMN "MetodoPago" integer NULL;
                        END IF;
                    END
                    $ef$;
                    """);
                return;
            }

            migrationBuilder.AddColumn<bool>(
                name: "AceptaDepositoReserva",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApellidoCliente",
                table: "Citas",
                type: "TEXT",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Citas",
                type: "TEXT",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DisponibleParaAsegurar",
                table: "Citas",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DuracionContratoDeseada",
                table: "Citas",
                type: "TEXT",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmpleadoActualmente",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EsCiudadanoAmericano",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaMudanzaTemprana",
                table: "Citas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Fuma",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MetodoPago",
                table: "Citas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreCompania",
                table: "Citas",
                type: "TEXT",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PagaraCitaCertificada",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PersonasEnUnidad",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<decimal>(
                name: "Salario",
                table: "Citas",
                type: "TEXT",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieneMascotas",
                table: "Citas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "AceptaDepositoReserva";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "ApellidoCliente";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "CodigoPostal";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "DisponibleParaAsegurar";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "DuracionContratoDeseada";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "EmpleadoActualmente";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "EsCiudadanoAmericano";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "FechaMudanzaTemprana";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "Fuma";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "MetodoPago";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "NombreCompania";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "PagaraCitaCertificada";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "PersonasEnUnidad";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "Salario";
                    ALTER TABLE "Citas" DROP COLUMN IF EXISTS "TieneMascotas";
                    """);
                return;
            }

            migrationBuilder.DropColumn(name: "AceptaDepositoReserva", table: "Citas");
            migrationBuilder.DropColumn(name: "ApellidoCliente", table: "Citas");
            migrationBuilder.DropColumn(name: "CodigoPostal", table: "Citas");
            migrationBuilder.DropColumn(name: "DisponibleParaAsegurar", table: "Citas");
            migrationBuilder.DropColumn(name: "DuracionContratoDeseada", table: "Citas");
            migrationBuilder.DropColumn(name: "EmpleadoActualmente", table: "Citas");
            migrationBuilder.DropColumn(name: "EsCiudadanoAmericano", table: "Citas");
            migrationBuilder.DropColumn(name: "FechaMudanzaTemprana", table: "Citas");
            migrationBuilder.DropColumn(name: "Fuma", table: "Citas");
            migrationBuilder.DropColumn(name: "MetodoPago", table: "Citas");
            migrationBuilder.DropColumn(name: "NombreCompania", table: "Citas");
            migrationBuilder.DropColumn(name: "PagaraCitaCertificada", table: "Citas");
            migrationBuilder.DropColumn(name: "PersonasEnUnidad", table: "Citas");
            migrationBuilder.DropColumn(name: "Salario", table: "Citas");
            migrationBuilder.DropColumn(name: "TieneMascotas", table: "Citas");
        }
    }
}
