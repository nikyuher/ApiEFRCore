using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class ActualizacionAsientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroFila",
                table: "Asientos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroFila",
                table: "Asientos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
