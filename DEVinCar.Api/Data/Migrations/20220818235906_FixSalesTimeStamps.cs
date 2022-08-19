using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEVinCar.Api.Data.Migrations
{
    public partial class FixSalesTimeStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SaleDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryForecast",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "SaleDate",
                table: "Sales",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<byte[]>(
                name: "DeliveryForecast",
                table: "Deliveries",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
