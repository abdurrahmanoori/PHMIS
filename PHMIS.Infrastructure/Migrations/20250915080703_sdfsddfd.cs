using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfsddfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Hospitals",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Hospitals",
                type: "TEXT",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProvinceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Language = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvinceTranslations_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b6947a3-d23f-4424-bc9e-8150cd17348b", "AQAAAAIAAYagAAAAEEblseR8Ku4Y/7QiUlrIt2HLK/VVEGeRCjZfaTgZ69pumvz7fdbsWuURUjYwppo6kg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e70d8c5d-9b14-4338-8a60-5cda283d9fc0", "AQAAAAIAAYagAAAAEP3Hv3UFHRU3ogxFs1JQ4+rGZdgB8I8KwZEFIvCWMaOCX/bWp+iVMw6qaU2P87KvSA==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { null, new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9514), null, new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9525) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { null, new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9532), null, new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9533) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { null, new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9537), null, new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9538) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "490d93f2-cf15-4452-a2c2-be113b40156e");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "297c5aca-a773-4fcc-a038-43133a87fab9");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "53dee776-1a15-4567-a68f-9049cbf2c8f7");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "46f7d248-afd4-40d1-8d9a-1e2f28baaaaa");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "750cf2ff-074b-415a-bced-35239725c636");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "14f80c5f-a6d7-414f-8aa5-8de30b2253e8");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "e07f0cd2-d214-4a1c-94e7-39deacc0cb4f");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "en", true, "English" },
                    { 2, "fr", true, "French" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "66117dc3-3f83-4fe6-9cc9-0d5a14cc2a7c");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "87385063-d0cb-44fa-86cc-cebe64753c4e");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "69e1417f-f99f-47a8-a4be-9982ffb041e2");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceTranslations_ProvinceId_Language",
                table: "ProvinceTranslations",
                columns: new[] { "ProvinceId", "Language" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProvinceTranslations");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Hospitals",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Hospitals",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2a34781-e9b1-44c0-9c7a-9bd8486d3593", "AQAAAAIAAYagAAAAEHscH6juR5E02SI/k3f4b5xwJkIeRUdU0hK2nzCe+am62ZJGElcO3ZJggQGe1Gbwig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd66695b-b4c7-4f8c-b324-03dd5e13753a", "AQAAAAIAAYagAAAAECYrX3GnBDRfJN8kprhva8i6YTanxdzpGcvQUnA1JfOjAWjso/3IFVv9C1Wprmwsgg==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { null, new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6221), null, new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { null, new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6295), null, new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedDate", "Type", "UpdatedDate" },
                values: new object[] { null, new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6300), null, new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "914b2ffb-644e-4850-bea0-1caebaf29199");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "ff500bef-e130-4230-a2b5-1c17a9e7e3cc");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "1725f9ca-9d7f-4e77-81d4-ac39727bbb47");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "b8d2d2e8-bfa4-4d3e-bb5f-a4da4e8ea6bc");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "e1a03d6e-5082-4a40-a265-f457b24c1919");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "d00eeabc-2362-4174-83d1-791f521be036");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "511e8689-3ebf-4aed-9dc4-6bc8f46b35af");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "220e395f-6444-4f3c-bd03-dac37e2022cf");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "375bab90-ead7-4bb2-9f71-b0cf366d7c28");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "328d8de3-c49e-434b-b01d-d82ad222ec64");
        }
    }
}
