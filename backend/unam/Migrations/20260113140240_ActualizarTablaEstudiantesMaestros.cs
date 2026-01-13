using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace unam.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarTablaEstudiantesMaestros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Maestros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireToken",
                table: "Maestros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Maestros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Pin",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireToken",
                table: "Estudiantes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "ExpireToken",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Maestros");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "ExpireToken",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Estudiantes");

            migrationBuilder.AlterColumn<string>(
                name: "Pin",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
