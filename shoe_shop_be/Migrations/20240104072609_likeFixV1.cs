using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoe_shop_be.Migrations
{
    public partial class likeFixV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "delete",
                table: "Likes",
                newName: "Delete");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Delete",
                table: "Likes",
                newName: "delete");

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
    }
}
