using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class picture2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd53a7c0-6c8d-4881-a201-0e0d1a4ab400", "AQAAAAEAACcQAAAAEDfimlrp1I+sXbroHsKfoKPqMkO9qNHGUVYtYfYqS7IDcGtNzpek9XN/n+UOI0UDcw==", "9dde62dd-5ffa-450c-ac26-a4460faea0bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23bdc6c5-031f-4db6-982f-11b58c1ac054", "AQAAAAEAACcQAAAAECaiZ5JkKe5V8mwV6IgmW3Dm3a8/9ylyXkfaBKA9SqxhoIzJZRLgvUi7cGgNBIO8VA==", "9a153d62-1ac6-4e1a-9a9f-e8a1103027b0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21726d61-81d4-49e0-86be-6651484568a9", "AQAAAAEAACcQAAAAEIys0QZaFBZazsP49TeIuP4AGGjxj8n1vhxXwuVp14ljZKQfsGedO3WlUEIZSKV1Fw==", "eae55f91-f976-45b8-b654-ed317a66063f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fe07e4d-28c9-4088-9290-f0370400e01e", "AQAAAAEAACcQAAAAEDgfaZsJsxjNhbFy8mfT+raS5OdmQ86k6cWVhgZJNdY2jgV2ws9v6vK24jTHSMtNGA==", "fe718d7f-a8c7-4a12-94f7-f0389cb0fa64" });
        }
    }
}
