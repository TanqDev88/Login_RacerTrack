using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect_RaceTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehiculoTipoMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehiculoCosto",
                table: "Vehiculo");

            migrationBuilder.AlterColumn<int>(
                name: "VehiculoTipo",
                table: "Vehiculo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "VehiculoNombre",
                table: "Vehiculo",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "VehiculoMatricula",
                table: "Vehiculo",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "VehiculoApellido",
                table: "Vehiculo",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehiculoTipo",
                table: "Vehiculo",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "VehiculoNombre",
                table: "Vehiculo",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VehiculoMatricula",
                table: "Vehiculo",
                type: "TEXT",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VehiculoApellido",
                table: "Vehiculo",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehiculoCosto",
                table: "Vehiculo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
