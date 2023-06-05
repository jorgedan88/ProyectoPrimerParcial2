using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class Hangar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangar",
                columns: table => new
                {
                    HangarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreHangar = table.Column<string>(type: "TEXT", nullable: false),
                    Sector = table.Column<int>(type: "INTEGER", nullable: false),
                    AptoMantenimiento = table.Column<bool>(type: "INTEGER", nullable: false),
                    oficinas = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangar", x => x.HangarId);
                });

            migrationBuilder.CreateTable(
                name: "AeronaveHangar",
                columns: table => new
                {
                    AeronaveListAeronaveId = table.Column<int>(type: "INTEGER", nullable: false),
                    HangarListHangarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AeronaveHangar", x => new { x.AeronaveListAeronaveId, x.HangarListHangarId });
                    table.ForeignKey(
                        name: "FK_AeronaveHangar_Aeronave_AeronaveListAeronaveId",
                        column: x => x.AeronaveListAeronaveId,
                        principalTable: "Aeronave",
                        principalColumn: "AeronaveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AeronaveHangar_Hangar_HangarListHangarId",
                        column: x => x.HangarListHangarId,
                        principalTable: "Hangar",
                        principalColumn: "HangarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AeronaveHangar_HangarListHangarId",
                table: "AeronaveHangar",
                column: "HangarListHangarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AeronaveHangar");

            migrationBuilder.DropTable(
                name: "Hangar");
        }
    }
}
