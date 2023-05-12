using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class seedImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a907b44-82ea-4e20-81a1-778787660896", "AQAAAAEAACcQAAAAEIr6/iE4tGQYQAUd2YF2MrST53nlrQS3hZkSF/4i2mHKbvqFvDqKRJBm0OHy/gjg5g==", "3cbf6e6b-3ed4-4f3d-9da1-ff51e787c94d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1810bc4f-1ec8-4bf8-b496-947a9e2143b4", "AQAAAAEAACcQAAAAEFpl5cXy8uc3cyW3brGo/0Z8SjNXopLSCR1jbfUE092oid6U9aJxS5MvaBs0/7uRJQ==", "39154754-8e9f-4eb5-9d88-8beeee5e0c30" });

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1,
                column: "MimeType",
                value: "image/jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Picture",
                keyColumn: "Id",
                keyValue: 1,
                column: "MimeType",
                value: "image/jfif");
        }
    }
}
