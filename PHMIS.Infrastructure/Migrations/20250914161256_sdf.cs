using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabTests_LabTestGroups_LabTestGroupId1",
                table: "LabTests");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLabTests_LabTests_LabTestId",
                table: "PatientLabTests");

            migrationBuilder.DropIndex(
                name: "IX_LabTests_LabTestGroupId1",
                table: "LabTests");

            migrationBuilder.DropColumn(
                name: "LabTestGroupId1",
                table: "LabTests");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLabTests_LabTests_LabTestId",
                table: "PatientLabTests",
                column: "LabTestId",
                principalTable: "LabTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLabTests_LabTests_LabTestId",
                table: "PatientLabTests");

            migrationBuilder.AddColumn<int>(
                name: "LabTestGroupId1",
                table: "LabTests",
                type: "INTEGER",
                nullable: true);

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
                columns: new[] { "LabTestGroupId1", "PublicId" },
                values: new object[] { null, "6b6e3d00-582e-440a-8f50-bdfeb2735779" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LabTestGroupId1", "PublicId" },
                values: new object[] { null, "e3f14a7e-ccf7-40c3-a1bd-50e9cffd6d3a" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LabTestGroupId1", "PublicId" },
                values: new object[] { null, "8ca0015a-5210-44b5-842b-debc0e251c16" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LabTestGroupId1", "PublicId" },
                values: new object[] { null, "187d01e4-0e0e-49a0-bf6b-5ad5ce58a0c3" });

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

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_LabTestGroupId1",
                table: "LabTests",
                column: "LabTestGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTests_LabTestGroups_LabTestGroupId1",
                table: "LabTests",
                column: "LabTestGroupId1",
                principalTable: "LabTestGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLabTests_LabTests_LabTestId",
                table: "PatientLabTests",
                column: "LabTestId",
                principalTable: "LabTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
