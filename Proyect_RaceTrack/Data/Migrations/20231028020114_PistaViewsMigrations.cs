using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_RaceTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class PistaViewsMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cochera",
                columns: table => new
                {
                    CocheraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CocheraNombre = table.Column<string>(type: "TEXT", nullable: true),
                    CocheraNumero = table.Column<int>(type: "INTEGER", nullable: false),
                    CocheraSector = table.Column<int>(type: "INTEGER", nullable: false),
                    CocheraAptoMantenimiento = table.Column<bool>(type: "INTEGER", nullable: false),
                    CocheraOficinas = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cochera", x => x.CocheraId);
                });

            migrationBuilder.CreateTable(
                name: "Pista",
                columns: table => new
                {
                    PistaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PistaNombre = table.Column<string>(type: "TEXT", nullable: true),
                    PistaCodigo = table.Column<int>(type: "INTEGER", nullable: false),
                    PistaMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    PistaIluminacion = table.Column<bool>(type: "INTEGER", nullable: false),
                    PistaAprovisionamiento = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pista", x => x.PistaId);
                });

            migrationBuilder.CreateTable(
                name: "CocheraPista",
                columns: table => new
                {
                    CocherasCocheraId = table.Column<int>(type: "INTEGER", nullable: false),
                    PistasPistaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocheraPista", x => new { x.CocherasCocheraId, x.PistasPistaId });
                    table.ForeignKey(
                        name: "FK_CocheraPista_Cochera_CocherasCocheraId",
                        column: x => x.CocherasCocheraId,
                        principalTable: "Cochera",
                        principalColumn: "CocheraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocheraPista_Pista_PistasPistaId",
                        column: x => x.PistasPistaId,
                        principalTable: "Pista",
                        principalColumn: "PistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CocheraPista_PistasPistaId",
                table: "CocheraPista",
                column: "PistasPistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CocheraPista");

            migrationBuilder.DropTable(
                name: "Cochera");

            migrationBuilder.DropTable(
                name: "Pista");
        }
    }
}
