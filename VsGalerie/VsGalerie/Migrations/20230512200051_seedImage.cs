using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class seedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62d1196f-f9bc-4a8f-9f3a-b0e7b938473d", "AQAAAAEAACcQAAAAEPghSTYUuW27Mr+9GWi2HSGethUxHVa0gMYM1bl/KkEH4IYNa6Kq0QKNp6Mx3PLffg==", "1f5ed277-e142-46ff-b917-17484034285f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30995958-0de1-4630-bec7-bd69de920d49", "AQAAAAEAACcQAAAAEDYLcxpXkTY9g9ioOm8z+S7V929eDy4iRin9KinyxryFO0PTQAYORUKRiECsp/B32A==", "796b2167-106a-47af-b0ae-388a73f915ec" });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "FileName", "GalerieId", "MimeType" },
                values: new object[] { 1, "0d0c401a-046e-42ff-a5cf-d8551fd4e7c2.jfif", null, "image/jfif" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c1f166c-3005-4504-9b18-a6bbb93ac709", "AQAAAAEAACcQAAAAENDjMWCrJyGvv+NBLZ2pOlvP8mltVbTPQzoxMaDwHUbGrtsKtw0v8cwolYHnLgXP1Q==", "a28744ff-d552-4a5f-936c-a62cf2313222" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b90d29-4b62-45d4-ba4d-19a285ef7300", "AQAAAAEAACcQAAAAEMabx9d0RzyV7eYCF6AePRthDc399iIr7XFORGd93+hu4T53yQsOR0W4pe0t0ISz8A==", "311b7a56-29e2-48b4-810b-705a11e0ffa9" });
        }
    }
}
