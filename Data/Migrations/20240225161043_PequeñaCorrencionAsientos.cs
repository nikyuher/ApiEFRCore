using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class PequeñaCorrencionAsientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroAsiento",
                table: "Asientos",
                newName: "NombreAsiento");

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 1,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 2,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 3,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 4,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 5,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 6,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 7,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 8,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 9,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 10,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 11,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 12,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 13,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 14,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 15,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 16,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 17,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 18,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 19,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 20,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 21,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 22,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 23,
                column: "Estado",
                value: false);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 24,
                column: "Estado",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreAsiento",
                table: "Asientos",
                newName: "NumeroAsiento");

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 1,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 2,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 3,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 4,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 5,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 6,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 7,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 8,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 9,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 10,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 11,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 12,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 13,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 14,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 15,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 16,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 17,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 18,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 19,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 20,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 21,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 22,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 23,
                column: "Estado",
                value: null);

            migrationBuilder.UpdateData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 24,
                column: "Estado",
                value: null);
        }
    }
}
