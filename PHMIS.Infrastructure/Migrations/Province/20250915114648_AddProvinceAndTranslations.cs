using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PHMIS.Infrastructure.Migrations.Province
{
    /// <inheritdoc />
    public partial class AddProvinceAndTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b32b67e0-e08c-4a2e-8004-445e8b0b23a3", "AQAAAAIAAYagAAAAEIZAMFHWcwt9yfxvolCbjdFWmyGaLi/38j6aeO3IwaIxhkWLKPzTOR/wqbZVneRzvA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a4348ef-497d-4f19-a394-4a205f2b01a4", "AQAAAAIAAYagAAAAEC0OfgbHl7eTk6TwT5yWK4sxKu7Il0fQlM1wFs91+9oW4doJSi1LOTKvydvh2RH2Tg==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 16, 48, 468, DateTimeKind.Local).AddTicks(757), new DateTime(2025, 9, 15, 16, 16, 48, 468, DateTimeKind.Local).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 16, 48, 468, DateTimeKind.Local).AddTicks(774), new DateTime(2025, 9, 15, 16, 16, 48, 468, DateTimeKind.Local).AddTicks(775) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 16, 48, 468, DateTimeKind.Local).AddTicks(779), new DateTime(2025, 9, 15, 16, 16, 48, 468, DateTimeKind.Local).AddTicks(780) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "9fe7c58d-eddb-4941-9ae9-5e258aa11a07");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "5b087451-b5ca-4351-895f-663f504edd42");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "efbddbec-3a42-404e-876d-86023bb1e749");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "1d2d4dd5-e3f4-4fcf-8aa7-c3989c0245e7");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "10dddaff-c6cf-46ad-a89a-be5eba14f163");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "355a4a3d-e263-4835-a80b-d37234b2a83c");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "200e8a72-cd9a-48ac-8d9e-ef061f02e7ea");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "f924bc50-0d6d-40bc-8c18-ee1ff0d4f7e8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "1c5d27e5-6a3f-413a-8b51-c90ea1539d82");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "327f33af-68fc-4bfc-9866-e7e2fe0711cd");

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "HospitalId", "IsPublic", "Name", "PublicId" },
                values: new object[,]
                {
                    { 1, 0, true, "Kabul", "11111111-1111-1111-1111-111111111111" },
                    { 2, 0, true, "Kandahar", "22222222-2222-2222-2222-222222222222" },
                    { 3, 0, true, "Herat", "33333333-3333-3333-3333-333333333333" },
                    { 4, 0, true, "Nangarhar", "44444444-4444-4444-4444-444444444444" },
                    { 5, 0, true, "Balkh", "55555555-5555-5555-5555-555555555555" },
                    { 6, 0, true, "Ghazni", "66666666-6666-6666-6666-666666666666" },
                    { 7, 0, true, "Kunduz", "77777777-7777-7777-7777-777777777777" }
                });

            migrationBuilder.InsertData(
                table: "ProvinceTranslations",
                columns: new[] { "Id", "IsDefault", "Language", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, true, "en", "Kabul", 1 },
                    { 2, false, "fa", "????", 1 },
                    { 3, false, "ps", "????", 1 },
                    { 4, true, "en", "Kandahar", 2 },
                    { 5, false, "fa", "??????", 2 },
                    { 6, false, "ps", "??????", 2 },
                    { 7, true, "en", "Herat", 3 },
                    { 8, false, "fa", "????", 3 },
                    { 9, false, "ps", "????", 3 },
                    { 10, true, "en", "Nangarhar", 4 },
                    { 11, false, "fa", "???????", 4 },
                    { 12, false, "ps", "???????", 4 },
                    { 13, true, "en", "Balkh", 5 },
                    { 14, false, "fa", "???", 5 },
                    { 15, false, "ps", "???", 5 },
                    { 16, true, "en", "Ghazni", 6 },
                    { 17, false, "fa", "????", 6 },
                    { 18, false, "ps", "????", 6 },
                    { 19, true, "en", "Kunduz", 7 },
                    { 20, false, "fa", "?????", 7 },
                    { 21, false, "ps", "?????", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProvinceTranslations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7);

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
    }
}
