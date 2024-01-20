using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("0b34439a-11bb-4863-b591-7bd4eb9a93a5"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("25a07e7b-80cf-4918-b18c-401c57841f49"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("3568990e-ae5e-4ecb-87c2-5f503b882ce4"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("30cb44ea-d28e-47b6-9dbd-c58948ed8a00"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("b6f58fbc-b0fa-4b40-94d4-574255f32286"));

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: new Guid("eca1ab39-44f1-45d1-97a7-29fd807675bd"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("01f39c72-91a8-4148-98e8-ad16ee70f4dd"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("6d575ca9-aa1c-4f36-8d5a-62fb133b51db"));

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: new Guid("8bef51a5-b09f-4bda-8a2a-46e8949147ff"));

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b34439a-11bb-4863-b591-7bd4eb9a93a5"), "Nike" },
                    { new Guid("25a07e7b-80cf-4918-b18c-401c57841f49"), "Addidas" },
                    { new Guid("3568990e-ae5e-4ecb-87c2-5f503b882ce4"), "Converse" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("30cb44ea-d28e-47b6-9dbd-c58948ed8a00"), "green" },
                    { new Guid("b6f58fbc-b0fa-4b40-94d4-574255f32286"), "red" },
                    { new Guid("eca1ab39-44f1-45d1-97a7-29fd807675bd"), "blue" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01f39c72-91a8-4148-98e8-ad16ee70f4dd"), "41" },
                    { new Guid("6d575ca9-aa1c-4f36-8d5a-62fb133b51db"), "40" },
                    { new Guid("8bef51a5-b09f-4bda-8a2a-46e8949147ff"), "42" }
                });
        }
    }
}
