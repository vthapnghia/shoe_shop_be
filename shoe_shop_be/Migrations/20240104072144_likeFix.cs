using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class likeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3cbba9cf-965f-4131-bc43-265ffeeb6626"), "Addidas" },
                    { new Guid("9c6bf887-e81b-48c8-b9aa-b94996f1a347"), "Converse" },
                    { new Guid("daae4f7f-45f5-4276-9e93-0e24c0757cb5"), "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a53afcac-c7d2-4814-943f-73f65364d1d0"), "red" },
                    { new Guid("c2ae1f6e-6ca8-43d8-ba71-1e5fc9485ae4"), "green" },
                    { new Guid("cd5aabbe-1c14-4069-bd70-8b69a6632885"), "blue" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24187f49-c845-4e9c-9947-14d12681ccd8"), "40" },
                    { new Guid("631b9231-e144-4970-8136-03aea18f2bca"), "42" },
                    { new Guid("e7f6eb63-126a-423a-95a6-2f1329778d3a"), "41" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3cbba9cf-965f-4131-bc43-265ffeeb6626"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9c6bf887-e81b-48c8-b9aa-b94996f1a347"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("daae4f7f-45f5-4276-9e93-0e24c0757cb5"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("a53afcac-c7d2-4814-943f-73f65364d1d0"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("c2ae1f6e-6ca8-43d8-ba71-1e5fc9485ae4"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("cd5aabbe-1c14-4069-bd70-8b69a6632885"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("24187f49-c845-4e9c-9947-14d12681ccd8"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("631b9231-e144-4970-8136-03aea18f2bca"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e7f6eb63-126a-423a-95a6-2f1329778d3a"));

            migrationBuilder.DropColumn(
                name: "delete",
                table: "Likes");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Users",
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
    }
}
