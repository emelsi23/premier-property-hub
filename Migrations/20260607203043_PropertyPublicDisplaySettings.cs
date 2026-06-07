using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartamentosRenta.Migrations
{
    /// <inheritdoc />
    public partial class PropertyPublicDisplaySettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    DO $ef$
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Propiedades' AND column_name = 'MostrarAplicacionPublica') THEN
                            ALTER TABLE "Propiedades" ADD COLUMN "MostrarAplicacionPublica" boolean NOT NULL DEFAULT TRUE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Propiedades' AND column_name = 'MostrarContratoPublico') THEN
                            ALTER TABLE "Propiedades" ADD COLUMN "MostrarContratoPublico" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Propiedades' AND column_name = 'MostrarStampillasPublico') THEN
                            ALTER TABLE "Propiedades" ADD COLUMN "MostrarStampillasPublico" boolean NOT NULL DEFAULT FALSE;
                        END IF;
                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'Propiedades' AND column_name = 'IdiomaPublico') THEN
                            ALTER TABLE "Propiedades" ADD COLUMN "IdiomaPublico" integer NOT NULL DEFAULT 0;
                        END IF;

                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'LeaseContracts' AND column_name = 'TitleEs') THEN
                            ALTER TABLE "LeaseContracts" ADD COLUMN "TitleEs" character varying(200) NULL;
                            ALTER TABLE "LeaseContracts" ADD COLUMN "SubtitleEs" character varying(200) NULL;
                            ALTER TABLE "LeaseContracts" ADD COLUMN "NoticeHtmlEs" character varying(4000) NULL;
                            ALTER TABLE "LeaseContracts" ADD COLUMN "BodyHtmlEs" text NULL;
                        END IF;

                        IF NOT EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'StampSealContracts' AND column_name = 'TitleEs') THEN
                            ALTER TABLE "StampSealContracts" ADD COLUMN "TitleEs" character varying(200) NULL;
                            ALTER TABLE "StampSealContracts" ADD COLUMN "SubtitleEs" character varying(200) NULL;
                            ALTER TABLE "StampSealContracts" ADD COLUMN "NoticeHtmlEs" character varying(4000) NULL;
                            ALTER TABLE "StampSealContracts" ADD COLUMN "BodyHtmlEs" text NULL;
                        END IF;
                    END
                    $ef$;

                    UPDATE "Propiedades" SET "MostrarAplicacionPublica" = TRUE WHERE "MostrarAplicacionPublica" = FALSE;
                    """);
                return;
            }

            migrationBuilder.AddColumn<string>(
                name: "BodyHtmlEs",
                table: "StampSealContracts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoticeHtmlEs",
                table: "StampSealContracts",
                type: "TEXT",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtitleEs",
                table: "StampSealContracts",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEs",
                table: "StampSealContracts",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdiomaPublico",
                table: "Propiedades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "MostrarAplicacionPublica",
                table: "Propiedades",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "MostrarContratoPublico",
                table: "Propiedades",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MostrarStampillasPublico",
                table: "Propiedades",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BodyHtmlEs",
                table: "LeaseContracts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoticeHtmlEs",
                table: "LeaseContracts",
                type: "TEXT",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtitleEs",
                table: "LeaseContracts",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEs",
                table: "LeaseContracts",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("""
                    ALTER TABLE "Propiedades" DROP COLUMN IF EXISTS "MostrarAplicacionPublica";
                    ALTER TABLE "Propiedades" DROP COLUMN IF EXISTS "MostrarContratoPublico";
                    ALTER TABLE "Propiedades" DROP COLUMN IF EXISTS "MostrarStampillasPublico";
                    ALTER TABLE "Propiedades" DROP COLUMN IF EXISTS "IdiomaPublico";
                    ALTER TABLE "LeaseContracts" DROP COLUMN IF EXISTS "TitleEs";
                    ALTER TABLE "LeaseContracts" DROP COLUMN IF EXISTS "SubtitleEs";
                    ALTER TABLE "LeaseContracts" DROP COLUMN IF EXISTS "NoticeHtmlEs";
                    ALTER TABLE "LeaseContracts" DROP COLUMN IF EXISTS "BodyHtmlEs";
                    ALTER TABLE "StampSealContracts" DROP COLUMN IF EXISTS "TitleEs";
                    ALTER TABLE "StampSealContracts" DROP COLUMN IF EXISTS "SubtitleEs";
                    ALTER TABLE "StampSealContracts" DROP COLUMN IF EXISTS "NoticeHtmlEs";
                    ALTER TABLE "StampSealContracts" DROP COLUMN IF EXISTS "BodyHtmlEs";
                    """);
                return;
            }

            migrationBuilder.DropColumn(name: "BodyHtmlEs", table: "StampSealContracts");
            migrationBuilder.DropColumn(name: "NoticeHtmlEs", table: "StampSealContracts");
            migrationBuilder.DropColumn(name: "SubtitleEs", table: "StampSealContracts");
            migrationBuilder.DropColumn(name: "TitleEs", table: "StampSealContracts");
            migrationBuilder.DropColumn(name: "IdiomaPublico", table: "Propiedades");
            migrationBuilder.DropColumn(name: "MostrarAplicacionPublica", table: "Propiedades");
            migrationBuilder.DropColumn(name: "MostrarContratoPublico", table: "Propiedades");
            migrationBuilder.DropColumn(name: "MostrarStampillasPublico", table: "Propiedades");
            migrationBuilder.DropColumn(name: "BodyHtmlEs", table: "LeaseContracts");
            migrationBuilder.DropColumn(name: "NoticeHtmlEs", table: "LeaseContracts");
            migrationBuilder.DropColumn(name: "SubtitleEs", table: "LeaseContracts");
            migrationBuilder.DropColumn(name: "TitleEs", table: "LeaseContracts");
        }
    }
}
