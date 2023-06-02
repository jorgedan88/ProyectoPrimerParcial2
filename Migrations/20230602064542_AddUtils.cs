using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class AddUtils : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LegajoVuelo",
                table: "Instructor",
                newName: "NumeroLicencia");

            migrationBuilder.AlterColumn<int>(
                name: "TipoLicencia",
                table: "Instructor",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroLicencia",
                table: "Instructor",
                newName: "LegajoVuelo");

            migrationBuilder.AlterColumn<string>(
                name: "TipoLicencia",
                table: "Instructor",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
