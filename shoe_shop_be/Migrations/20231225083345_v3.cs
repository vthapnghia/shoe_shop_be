using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b2c611c-966c-4e2a-b423-01e9159a79f3"), "Nike" },
                    { new Guid("e2536b84-bb84-4764-b478-0b93513fc1cf"), "Converse" },
                    { new Guid("f0eda341-0b75-49e0-b992-12c57975563e"), "Addidas" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3c59e3a4-1788-4bb5-8511-5c221aa30f71"), "green" },
                    { new Guid("633c5e0c-7a17-4097-89f4-55bb560138c8"), "red" },
                    { new Guid("c41ee164-cad4-4eb1-b1ad-2cbd61e2c378"), "blue" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("58f9e30b-d5e4-4296-9569-6cf63a43e38a"), "41" },
                    { new Guid("a2e8c255-e88a-4439-90ad-fb6ebaeba3d4"), "40" },
                    { new Guid("e2dec9d9-7d4f-4e04-818e-4b346adc0bc8"), "42" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("1b2c611c-966c-4e2a-b423-01e9159a79f3"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e2536b84-bb84-4764-b478-0b93513fc1cf"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f0eda341-0b75-49e0-b992-12c57975563e"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("3c59e3a4-1788-4bb5-8511-5c221aa30f71"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("633c5e0c-7a17-4097-89f4-55bb560138c8"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("c41ee164-cad4-4eb1-b1ad-2cbd61e2c378"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("58f9e30b-d5e4-4296-9569-6cf63a43e38a"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("a2e8c255-e88a-4439-90ad-fb6ebaeba3d4"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e2dec9d9-7d4f-4e04-818e-4b346adc0bc8"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
