using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class AgregacionRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Rol",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Contraseña", "CorreoElectronico", "Nombre", "Rol" },
                values: new object[] { 1, "admin", "admin@admin.com", "admin", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");
        }
    }
}
