using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLanguageMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "460a38d0-e2dd-435a-af1f-6af93a8bc79f", "AQAAAAIAAYagAAAAEGZN64iqOJsqWXGajm/UnHJ0bEvmy8ac/WKYtarg3gsEF79mVjcEQcJHBs7Rp1hMRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44558b57-c724-4c05-9e90-737d2cba470e", "AQAAAAIAAYagAAAAEN4letfkvk9aVMgZMp0n+X2IRIGo7qaUr4hAly2s/ePr0oeFUQaGoGXdmB3AAcTRYg==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 20, 2, 287, DateTimeKind.Local).AddTicks(1610), new DateTime(2025, 9, 15, 13, 20, 2, 287, DateTimeKind.Local).AddTicks(1621) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 20, 2, 287, DateTimeKind.Local).AddTicks(1630), new DateTime(2025, 9, 15, 13, 20, 2, 287, DateTimeKind.Local).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 20, 2, 287, DateTimeKind.Local).AddTicks(1634), new DateTime(2025, 9, 15, 13, 20, 2, 287, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "a26afaff-3af3-4a67-9283-ae9888adec64");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "d29af8f6-ed28-48ad-b5a5-a1c77ed4cd53");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "ea87f6fb-6719-4f8f-8861-00df1765cb01");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "740480c5-5bf0-4784-9132-23deb2bacf00");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "38b7504e-d903-4faa-876b-f44f05760c05");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "dfcd3a08-b1cf-460a-b148-8dc38e0d6813");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "79dd3b51-b6ee-4447-a3e3-763bf9b88b48");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Name" },
                values: new object[] { "ps", "Pashto" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[] { 3, "fa", true, "Farsi" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "8d82cf96-f852-4f2c-875d-d8cf65cdeea1");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "145beda6-873b-4508-8556-0f3712067b42");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "dd03dc0e-1e69-479f-9e9b-d098b3728879");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9514), new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9525) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9532), new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9533) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9537), new DateTime(2025, 9, 15, 12, 37, 2, 712, DateTimeKind.Local).AddTicks(9538) });

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

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Name" },
                values: new object[] { "fr", "French" });

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
        }
    }
}
