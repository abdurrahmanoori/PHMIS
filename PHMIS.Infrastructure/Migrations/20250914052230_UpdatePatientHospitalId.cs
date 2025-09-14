using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHMIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientHospitalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "PublicId",
                value: "118cb46f-e99b-4962-a2dc-0e84760abfd8");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "ee78c548-ab54-476b-8177-cd6fcac11f09");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "e5a54274-eb6f-488a-bf4d-4276f0a93c33");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "689e23d7-80aa-4873-8cf7-c1798d828394", "AQAAAAIAAYagAAAAENkwj9M48uZBk1E57AFNjA0u9ssvvMbDjhbuYnUpD1v6AnUcfU/aeXEO4+LCsv/c9w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29f5727f-70a3-4fdf-be68-11adb37798c0", "AQAAAAIAAYagAAAAELzLT0lI0Jj93NqA41PCZkJxD/SMJn4lo7zZXzDXKCKKb0CCWqTdDegcTz5dncKriQ==" });

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "9fa8e362-15c6-47a2-9cb3-6297d87829d4");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "4ab294c4-1d43-4ecc-84ca-83fb468cf173");

            migrationBuilder.UpdateData(
                table: "LabTestGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "b7800a32-f461-4043-bde6-4a89cb6d81bd");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "6f3e1457-8fea-4382-a748-2302a8546c79");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "2c0d827f-d5af-4fdf-b063-b596c2c75dd5");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "421137d3-c694-41b3-93af-946d5a35faf3");

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublicId",
                value: "9d3ab0a1-0a99-4b7b-874d-2f67e0f276e4");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicId",
                value: "42bd65f9-3503-4cd6-82a2-3e326b643582");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicId",
                value: "8405555c-6eda-4eec-8af5-0aed96c79c29");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicId",
                value: "cc290e42-e9ce-483b-9676-541422ccbc6b");
        }
    }
}
