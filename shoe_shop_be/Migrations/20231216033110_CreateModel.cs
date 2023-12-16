using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class CreateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1685bb01-3b06-4c30-a22c-894bcdfb0afb"), "Converse" },
                    { new Guid("46c76a79-c34f-4c40-b97e-ad4ae06adde8"), "Nike" },
                    { new Guid("990566c9-5f71-445a-aed4-b6f577db2897"), "Addidas" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8632cdee-1536-40bc-9087-e2c6643c2ed4"), "green" },
                    { new Guid("be3f3fb0-088c-4c36-8ac6-3bd3ddbae7d7"), "red" },
                    { new Guid("fd9afbdc-640e-4ee0-897d-437b043944e4"), "blue" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ebf68f2-10e9-4008-b9b8-57354618bd51"), "40" },
                    { new Guid("9f8ce1f3-7e2a-4436-97c6-a456f9307ae4"), "42" },
                    { new Guid("ccab8188-8b17-4987-a00c-e72b482bfb77"), "41" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("1685bb01-3b06-4c30-a22c-894bcdfb0afb"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("46c76a79-c34f-4c40-b97e-ad4ae06adde8"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("990566c9-5f71-445a-aed4-b6f577db2897"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("8632cdee-1536-40bc-9087-e2c6643c2ed4"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("be3f3fb0-088c-4c36-8ac6-3bd3ddbae7d7"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("fd9afbdc-640e-4ee0-897d-437b043944e4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("2ebf68f2-10e9-4008-b9b8-57354618bd51"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9f8ce1f3-7e2a-4436-97c6-a456f9307ae4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("ccab8188-8b17-4987-a00c-e72b482bfb77"));
        }
    }
}
