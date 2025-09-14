using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Hospitals",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Hospitals",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Hospitals",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Provinces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Provinces",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "LabTests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "LabTests",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "LabTestGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "LabTestGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Hospitals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Hospitals",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedDate", "HospitalId", "IsPublic", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(189), 0, false, new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(201) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "HospitalId", "IsPublic", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(215), 0, false, new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(216) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "HospitalId", "IsPublic", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(222), 0, false, new DateTime(2025, 9, 14, 20, 32, 35, 27, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "ec199fe7-d8f6-4492-8fc4-72e39527112b" });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "f36e4fc8-b351-4fee-bfcb-3bd61da7bde3" });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "ea135d2e-c3a9-4c46-b741-1f2193a0dd03" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "26f752f8-aaf0-42ca-8221-2f9c040650da" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "e9987587-4fab-4008-bc6c-f7115dea6577" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "23aae843-76a0-48b7-a0a5-65d9d0abe255" });

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 0, false, "b4102c91-15ba-4efe-a4fa-5ee4b5e93786" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 1, false, "a80ad021-1245-4421-b99b-78c616104ec3" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 1, false, "54a0beab-3e07-4e03-9a95-d2d28a8a2e16" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HospitalId", "IsPublic", "PublicId" },
                values: new object[] { 1, false, "cab16574-29ca-43b3-b307-17448f32db56" });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "LabTests");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "LabTests");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "LabTestGroups");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "LabTestGroups");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Hospitals");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Hospitals",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Hospitals",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Hospitals",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Patients",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce7384dc-68ac-43c3-8245-c96a7617a097", "AQAAAAIAAYagAAAAEBaZoWy2Z8aHVkORsRG4vzTQ6MwpciJE3zN60GxMlcGj0ebHxOM8EdUKKv3EIP2e6Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a4e0ffc-e115-4b0e-832d-0ef95b73afca", "AQAAAAIAAYagAAAAEBLexWid84trUu43OdbgLdA7t3++eCsKI0ZAitmtbtw5HNi8Zwz+4hTfIVWe7x8vhA==" });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "b067b1f1-a15c-4587-8ba6-a0133e0388d3");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "3f883a9f-49db-45f5-976e-fda9b1a19f2e");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "66ee7cbb-ec2f-4aee-83ad-42b3fe53c28b");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "2047cb3e-1ca6-4694-a09e-579d18d74933");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "44d7a3b4-e1f2-4f73-9b05-c5d31f5f7a82");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "2fce2e21-6ffa-463e-8fb8-9c3c371b10fa");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "6daac446-6607-4c10-8bd3-d89f76ce3d2d");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HospitalId", "PublicId" },
                values: new object[] { null, "118cb46f-e99b-4962-a2dc-0e84760abfd8" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HospitalId", "PublicId" },
                values: new object[] { null, "ee78c548-ab54-476b-8177-cd6fcac11f09" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HospitalId", "PublicId" },
                values: new object[] { null, "e5a54274-eb6f-488a-bf4d-4276f0a93c33" });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Hospitals_HospitalId",
                table: "Patients",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }
    }
}
