using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentApiRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ea097c0-afda-4754-81ad-7eef21f254a5", "AQAAAAIAAYagAAAAEMinunM6fCfdBQBppIwI1MM9QY75CygWprBU8K04Fi6TD/69TxdZTWMSt9e0iiCvFA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff526138-860e-4193-9442-4ced794ac104", "AQAAAAIAAYagAAAAECTgvwnG7ZS1sFfYhf30Z3ONuLVCe/ewGvQgyjoAtaaskmqzB5W1GP59fLhKqlH/DQ==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 39, 50, 903, DateTimeKind.Local).AddTicks(3237), new DateTime(2025, 9, 14, 20, 39, 50, 903, DateTimeKind.Local).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 39, 50, 903, DateTimeKind.Local).AddTicks(3256), new DateTime(2025, 9, 14, 20, 39, 50, 903, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 39, 50, 903, DateTimeKind.Local).AddTicks(3263), new DateTime(2025, 9, 14, 20, 39, 50, 903, DateTimeKind.Local).AddTicks(3263) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "513deebb-9242-4f9f-80bd-70245b2771d6");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "895728d4-5105-4ad3-bf49-f3bb1b64d30b");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "b61b185a-6daf-464c-884d-c2b2a4a0700a");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "6b6e3d00-582e-440a-8f50-bdfeb2735779");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "e3f14a7e-ccf7-40c3-a1bd-50e9cffd6d3a");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "8ca0015a-5210-44b5-842b-debc0e251c16");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "187d01e4-0e0e-49a0-bf6b-5ad5ce58a0c3");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "df7570d2-26d7-4436-99c2-68bbc468f2d8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "0d93cc57-e544-45d3-afa3-fa5c9cc5818f");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "b7e06876-6e31-4cfe-abef-c43137746d3a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a9795c8c-1163-4274-adec-b86ccfc2bb84", "AQAAAAIAAYagAAAAEPOuWDryVAmuV15KStMdCQu9+C8aHMNkMFjA3wVOINaDWFe+GeF86yDhZ6QcfMowpw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "96bf0de7-f7da-47ab-8965-c13c61867507", "AQAAAAIAAYagAAAAEH9ghdvhTL4mAftMIVCjAU/M9nPBkCPGTHVVM6LFtPxJDeT71IobVQWnjdxoxesVRA==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(189), new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(201) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(215), new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(222), new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "ec199fe7-d8f6-4492-8fc4-72e39527112b");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "f36e4fc8-b351-4fee-bfcb-3bd61da7bde3");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "ea135d2e-c3a9-4c46-b741-1f2193a0dd03");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "26f752f8-aaf0-42ca-8221-2f9c040650da");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "e9987587-4fab-4008-bc6c-f7115dea6577");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "23aae843-76a0-48b7-a0a5-65d9d0abe255");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "b4102c91-15ba-4efe-a4fa-5ee4b5e93786");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "a80ad021-1245-4421-b99b-78c616104ec3");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "54a0beab-3e07-4e03-9a95-d2d28a8a2e16");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "cab16574-29ca-43b3-b307-17448f32db56");
        }
    }
}
