using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    public partial class CreatePaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ec0d54b-477e-4a65-9fc3-774ed952387b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a948f53c-bedf-46ac-8c61-3a30c069012a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e13b54e5-550e-4458-8f65-b08a77c00f4b");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "031ca604-22bd-410d-bbd3-6402cb5864c4", "aaea2cc5-bec2-4bb1-bbec-de0ed4e94ce8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a9d26e1-97aa-40ca-8491-de1dd0aee39a", "93201c28-a1a3-47a1-a34b-00318cb583de", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de0cb2ee-2fdd-459b-a325-745143d6a241", "6d2aad8a-1834-4556-8b5f-33c17f66cee0", "Personel", "PERSONEL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "031ca604-22bd-410d-bbd3-6402cb5864c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a9d26e1-97aa-40ca-8491-de1dd0aee39a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0cb2ee-2fdd-459b-a325-745143d6a241");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ec0d54b-477e-4a65-9fc3-774ed952387b", "1e565073-c0c3-49bb-a523-df7214bf8260", "Personel", "PERSONEL" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a948f53c-bedf-46ac-8c61-3a30c069012a", "f9095376-6c34-4d74-b1b2-0191aa1ef1b5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e13b54e5-550e-4458-8f65-b08a77c00f4b", "901f64a4-bc2a-4b15-8d09-dfa0c655ad1e", "User", "USER" });
        }
    }
}
