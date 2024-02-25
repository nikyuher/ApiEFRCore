using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teatro.Data.Migrations
{
    public partial class GeneracionDeAsientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Estado", "NumeroAsiento" },
                values: new object[,]
                {
                    { 1, null, "A1" },
                    { 2, null, "A2" },
                    { 3, null, "A3" },
                    { 4, null, "A4" },
                    { 5, null, "A5" },
                    { 6, null, "A6" },
                    { 7, null, "B1" },
                    { 8, null, "B2" },
                    { 9, null, "B3" },
                    { 10, null, "B4" },
                    { 11, null, "B5" },
                    { 12, null, "B6" },
                    { 13, null, "B7" },
                    { 14, null, "B8" },
                    { 15, null, "B9" },
                    { 16, null, "B10" },
                    { 17, null, "B11" },
                    { 18, null, "B12" },
                    { 19, null, "C1" },
                    { 20, null, "C2" },
                    { 21, null, "C3" },
                    { 22, null, "C4" },
                    { 23, null, "C5" },
                    { 24, null, "C6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Asientos",
                keyColumn: "AsientoId",
                keyValue: 24);
        }
    }
}
