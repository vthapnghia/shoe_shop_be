using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Secret",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GoogleId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("82dcb2b9-8395-4183-a7ff-36a0f04d5598"), "Nike" },
                    { new Guid("97508e19-fa06-4ba1-8bba-064e68357f62"), "Converse" },
                    { new Guid("9b02bd89-52e8-4b2b-a724-0ea3b008119d"), "Addidas" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17d01ed3-d360-4e7b-a075-9703c6a8511a"), "red" },
                    { new Guid("3f2a11d5-99c0-473b-a7eb-c157c2b39305"), "blue" },
                    { new Guid("b6f161fe-c07c-4f1b-b4ea-e8b220e64161"), "green" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b5109de-b938-402f-ad21-bbbb631cc479"), "41" },
                    { new Guid("4f006700-1da0-4506-934d-305c0519c4e4"), "42" },
                    { new Guid("76695b5e-aa99-44eb-ab73-9bb8c9e0ff7a"), "40" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("82dcb2b9-8395-4183-a7ff-36a0f04d5598"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("97508e19-fa06-4ba1-8bba-064e68357f62"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9b02bd89-52e8-4b2b-a724-0ea3b008119d"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("17d01ed3-d360-4e7b-a075-9703c6a8511a"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("3f2a11d5-99c0-473b-a7eb-c157c2b39305"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("b6f161fe-c07c-4f1b-b4ea-e8b220e64161"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("3b5109de-b938-402f-ad21-bbbb631cc479"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("4f006700-1da0-4506-934d-305c0519c4e4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("76695b5e-aa99-44eb-ab73-9bb8c9e0ff7a"));

            migrationBuilder.AlterColumn<string>(
                name: "Secret",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoogleId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
