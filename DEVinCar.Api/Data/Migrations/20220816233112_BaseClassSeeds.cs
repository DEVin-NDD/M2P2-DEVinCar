using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinCar.Api.Data.Migrations
{
    public partial class BaseClassSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Name", "SuggestedPrice" },
                values: new object[,]
                {
                    { 1, "Camaro Chevrolet", 60000m },
                    { 2, "Maverick Ford", 20000m },
                    { 3, "Astra Chevrolet", 30000m },
                    { 4, "Hilux Toyota", 20000m },
                    { 5, "Bravo Fiat", 20000m },
                    { 6, "BR800 Gurgel", 10000m },
                    { 7, "147 Fiat", 50000m },
                    { 8, "Del Rey Ford", 10000m },
                    { 9, "Mustang Ford", 70000m },
                    { 10, "Belina Ford", 20000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jose@email.com", "Jose", "12345678" },
                    { 2, new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "andrea@email.com", "Andrea", "12345678" },
                    { 3, new DateTime(2005, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "adao@email.com", "Adao", "12345678" },
                    { 4, new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "monique@email.com", "Monique", "12345678" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
