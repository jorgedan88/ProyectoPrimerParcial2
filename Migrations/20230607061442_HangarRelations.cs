using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class HangarRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AeronaveHangar_Aeronave_AeronaveListAeronaveId",
                table: "AeronaveHangar");

            migrationBuilder.DropForeignKey(
                name: "FK_AeronaveHangar_Hangar_HangarListHangarId",
                table: "AeronaveHangar");

            migrationBuilder.RenameColumn(
                name: "HangarListHangarId",
                table: "AeronaveHangar",
                newName: "HangarsHangarId");

            migrationBuilder.RenameColumn(
                name: "AeronaveListAeronaveId",
                table: "AeronaveHangar",
                newName: "AeronavesAeronaveId");

            migrationBuilder.RenameIndex(
                name: "IX_AeronaveHangar_HangarListHangarId",
                table: "AeronaveHangar",
                newName: "IX_AeronaveHangar_HangarsHangarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AeronaveHangar_Aeronave_AeronavesAeronaveId",
                table: "AeronaveHangar",
                column: "AeronavesAeronaveId",
                principalTable: "Aeronave",
                principalColumn: "AeronaveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AeronaveHangar_Hangar_HangarsHangarId",
                table: "AeronaveHangar",
                column: "HangarsHangarId",
                principalTable: "Hangar",
                principalColumn: "HangarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AeronaveHangar_Aeronave_AeronavesAeronaveId",
                table: "AeronaveHangar");

            migrationBuilder.DropForeignKey(
                name: "FK_AeronaveHangar_Hangar_HangarsHangarId",
                table: "AeronaveHangar");

            migrationBuilder.RenameColumn(
                name: "HangarsHangarId",
                table: "AeronaveHangar",
                newName: "HangarListHangarId");

            migrationBuilder.RenameColumn(
                name: "AeronavesAeronaveId",
                table: "AeronaveHangar",
                newName: "AeronaveListAeronaveId");

            migrationBuilder.RenameIndex(
                name: "IX_AeronaveHangar_HangarsHangarId",
                table: "AeronaveHangar",
                newName: "IX_AeronaveHangar_HangarListHangarId");

            migrationBuilder.AddForeignKey(
                name: "FK_AeronaveHangar_Aeronave_AeronaveListAeronaveId",
                table: "AeronaveHangar",
                column: "AeronaveListAeronaveId",
                principalTable: "Aeronave",
                principalColumn: "AeronaveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AeronaveHangar_Hangar_HangarListHangarId",
                table: "AeronaveHangar",
                column: "HangarListHangarId",
                principalTable: "Hangar",
                principalColumn: "HangarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
