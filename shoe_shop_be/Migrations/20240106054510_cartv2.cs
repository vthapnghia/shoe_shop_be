using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class cartv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("4fb25fe1-d3ad-496f-b9f3-2ac110a2b2cf"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("5a9ea9ea-9ab7-49a2-859e-1973f43a6008"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("6ada6193-169f-4911-b0cd-30a50f600378"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("6d866bbb-747c-4445-beae-bdf4e82bd2f1"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("810ced8e-7c20-46c3-bf34-ef6fa9352408"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("db953473-52ef-4600-9413-253fd77eb32c"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("65929ed0-2707-4b8b-a89a-a8f736541924"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("a40f8aed-682c-4f15-80d6-47a6a2eae818"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("e4f1debc-5efe-4cf8-9737-9bf80175f1f0"));

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Carts");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09fca17a-594b-4b22-98b9-95a6dae3f7e4"), "Addidas" },
                    { new Guid("2db6e12b-b4c2-4c64-b6eb-997a656a98c6"), "Nike" },
                    { new Guid("5be78aa4-2697-4213-8709-48579812ede0"), "Converse" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fee4e44-e8f5-45ea-9666-cee556a8c944"), "red" },
                    { new Guid("3d2b1079-6e67-4b9b-a3cf-8a3bd15153fe"), "blue" },
                    { new Guid("b36b9fe6-6a02-4556-9d29-f82419b59f0c"), "green" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02725be0-c75d-4a9b-b0ae-bcc0731c9520"), "41" },
                    { new Guid("9eeaa340-da6b-40e3-846c-f2af6a6626c7"), "40" },
                    { new Guid("a46c25ce-d113-4ad3-96fd-61c91c28cdd9"), "42" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AccountId",
                table: "Carts",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Accounts_AccountId",
                table: "Carts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Accounts_AccountId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_Carts_AccountId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("09fca17a-594b-4b22-98b9-95a6dae3f7e4"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("2db6e12b-b4c2-4c64-b6eb-997a656a98c6"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("5be78aa4-2697-4213-8709-48579812ede0"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("0fee4e44-e8f5-45ea-9666-cee556a8c944"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("3d2b1079-6e67-4b9b-a3cf-8a3bd15153fe"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("b36b9fe6-6a02-4556-9d29-f82419b59f0c"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("02725be0-c75d-4a9b-b0ae-bcc0731c9520"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("9eeaa340-da6b-40e3-846c-f2af6a6626c7"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("a46c25ce-d113-4ad3-96fd-61c91c28cdd9"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb25fe1-d3ad-496f-b9f3-2ac110a2b2cf"), "Addidas" },
                    { new Guid("5a9ea9ea-9ab7-49a2-859e-1973f43a6008"), "Converse" },
                    { new Guid("6ada6193-169f-4911-b0cd-30a50f600378"), "Nike" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6d866bbb-747c-4445-beae-bdf4e82bd2f1"), "blue" },
                    { new Guid("810ced8e-7c20-46c3-bf34-ef6fa9352408"), "red" },
                    { new Guid("db953473-52ef-4600-9413-253fd77eb32c"), "green" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65929ed0-2707-4b8b-a89a-a8f736541924"), "42" },
                    { new Guid("a40f8aed-682c-4f15-80d6-47a6a2eae818"), "40" },
                    { new Guid("e4f1debc-5efe-4cf8-9737-9bf80175f1f0"), "41" }
                });
        }
    }
}
