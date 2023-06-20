using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class AddFechaFabricacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LegajoVuelo",
                table: "Instructor",
                newName: "TipoLicencia");

            migrationBuilder.AddColumn<bool>(
                name: "EnActividad",
                table: "Instructor",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExpedicion",
                table: "Instructor",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumeroLicencia",
                table: "Instructor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFabricacion",
                table: "Aeronave",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnActividad",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "FechaExpedicion",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "NumeroLicencia",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "FechaFabricacion",
                table: "Aeronave");

            migrationBuilder.RenameColumn(
                name: "TipoLicencia",
                table: "Instructor",
                newName: "LegajoVuelo");
        }
    }
}
