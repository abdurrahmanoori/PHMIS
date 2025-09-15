using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureEnumsAsStrings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6221), new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6295), new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6300), new DateTime(2025, 9, 14, 20, 52, 32, 656, DateTimeKind.Local).AddTicks(6300) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8586278e-b6bf-49fc-afdf-34efd8e76a95", "AQAAAAIAAYagAAAAEOiTifq1DYd7oTdujYEHZ2WNlLhWXDuTHBmHsR+0GiHLtuNk9aZT5JcdbarNViTPmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dda094e6-aede-4a98-88e7-490b8953eec0", "AQAAAAIAAYagAAAAECwwGxvuSOw+QewNiU5O1lGcsUP1mOYEJjo+w83fKXjKamNYCR3TDK72aJKLoYeDIA==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 42, 55, 242, DateTimeKind.Local).AddTicks(2830), new DateTime(2025, 9, 14, 20, 42, 55, 242, DateTimeKind.Local).AddTicks(2844) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 42, 55, 242, DateTimeKind.Local).AddTicks(2863), new DateTime(2025, 9, 14, 20, 42, 55, 242, DateTimeKind.Local).AddTicks(2864) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 42, 55, 242, DateTimeKind.Local).AddTicks(2870), new DateTime(2025, 9, 14, 20, 42, 55, 242, DateTimeKind.Local).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "2bb34d96-d5f1-4254-a144-b988fd9063a0");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "0646a6ae-ca17-4eed-ac10-6d8bc4efe7e2");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "bb1a49bb-3baf-4290-84ac-7957e1f1afce");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "36cfed33-e669-4b20-aa85-3e10f8a8aac2");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "e1bfe9eb-c98d-479d-9d81-ec21a44a775d");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "35c649ba-f088-4afa-ad62-489782498caf");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "3dc686e6-4a1a-49b4-9391-83a654ce8dfe");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "5c82915a-ddf6-465f-9b0e-20555474d50b");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "a28579e9-d1f0-4ff6-a2e5-a34e10d43aee");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "aadedb64-01e9-4a4c-b20d-979e13ae1bfc");
        }
    }
}
