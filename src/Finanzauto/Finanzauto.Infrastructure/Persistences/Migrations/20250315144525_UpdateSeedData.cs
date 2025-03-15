using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzauto.Infrastructure.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DocumentNumber", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, 11223344, "Carlos", "Gonzalez" },
                    { 4, 22334455, "Maria", "Fernandez" },
                    { 5, 33445566, "Luis", "Ramirez" },
                    { 6, 44556677, "Ana", "Torres" },
                    { 7, 55667788, "Pedro", "Mendoza" },
                    { 8, 66778899, "Lucia", "Ortega" },
                    { 9, 77889900, "Javier", "Silva" },
                    { 10, 88990011, "Andrea", "Castillo" },
                    { 11, 99001122, "Fernando", "Reyes" },
                    { 12, 10002233, "Patricia", "Cruz" },
                    { 13, 11003344, "Sergio", "Rojas" },
                    { 14, 12004455, "Gabriela", "Vega" },
                    { 15, 13005566, "Ricardo", "Lopez" },
                    { 16, 14006677, "Monica", "Guerrero" },
                    { 17, 15007788, "Alberto", "Acosta" },
                    { 18, 16008899, "Diana", "Salazar" },
                    { 19, 17009900, "Hector", "Miranda" },
                    { 20, 18001122, "Elena", "Soto" },
                    { 21, 19002233, "Oscar", "Nuñez" },
                    { 22, 20003344, "Valeria", "Ibarra" },
                    { 23, 21004455, "Rodrigo", "Herrera" },
                    { 24, 22005566, "Camila", "Espinoza" },
                    { 25, 23006677, "Manuel", "Paredes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
