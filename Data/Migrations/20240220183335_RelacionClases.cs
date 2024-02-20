using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class RelacionClases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_DetalleSalas_DetalleSalaId",
                table: "Asientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaSalas",
                table: "ReservaSalas");

            migrationBuilder.DropIndex(
                name: "IX_ReservaSalas_SalaId",
                table: "ReservaSalas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleSalas",
                table: "DetalleSalas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleSalas_SalaId",
                table: "DetalleSalas");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_DetalleSalaId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "ReservaSalaId",
                table: "ReservaSalas");

            migrationBuilder.DropColumn(
                name: "DetalleSalaId",
                table: "DetalleSalas");

            migrationBuilder.RenameColumn(
                name: "DetalleSalaId",
                table: "Asientos",
                newName: "DetalleSalaSalaId");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetalleSalaObraId",
                table: "Asientos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaSalas",
                table: "ReservaSalas",
                columns: new[] { "SalaId", "ReservaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleSalas",
                table: "DetalleSalas",
                columns: new[] { "SalaId", "ObraId" });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos",
                columns: new[] { "DetalleSalaSalaId", "DetalleSalaObraId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_DetalleSalas_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos",
                columns: new[] { "DetalleSalaSalaId", "DetalleSalaObraId" },
                principalTable: "DetalleSalas",
                principalColumns: new[] { "SalaId", "ObraId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_DetalleSalas_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaSalas",
                table: "ReservaSalas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleSalas",
                table: "DetalleSalas");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_DetalleSalaSalaId_DetalleSalaObraId",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "DetalleSalaObraId",
                table: "Asientos");

            migrationBuilder.RenameColumn(
                name: "DetalleSalaSalaId",
                table: "Asientos",
                newName: "DetalleSalaId");

            migrationBuilder.AddColumn<int>(
                name: "ReservaSalaId",
                table: "ReservaSalas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DetalleSalaId",
                table: "DetalleSalas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaSalas",
                table: "ReservaSalas",
                column: "ReservaSalaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleSalas",
                table: "DetalleSalas",
                column: "DetalleSalaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSalas_SalaId",
                table: "ReservaSalas",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSalas_SalaId",
                table: "DetalleSalas",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_DetalleSalaId",
                table: "Asientos",
                column: "DetalleSalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_DetalleSalas_DetalleSalaId",
                table: "Asientos",
                column: "DetalleSalaId",
                principalTable: "DetalleSalas",
                principalColumn: "DetalleSalaId");
        }
    }
}
