using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace unam.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarSolicitudesAgregarVerificacionDeSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPagada",
                table: "Solicitudes",
                newName: "IsAprobada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAprobada",
                table: "Solicitudes",
                newName: "IsPagada");
        }
    }
}
