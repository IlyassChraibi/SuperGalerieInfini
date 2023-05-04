using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

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

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPublic",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16a42d53-21d6-4e21-abe8-fc83a2d3f61f", "AQAAAAEAACcQAAAAEI7ggGAyX2SLYifa4UvdGmytjbgxX6TCCzbRvIAyEs7abmDjiN1/nJYpcBJRL/fd6Q==", "90347545-2b37-4141-80a3-862075b51956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "778147fd-84c8-4956-a901-4dbd6788a44d", "AQAAAAEAACcQAAAAELxBgK6YMcQSTZ06sCBGqOgTeURPUveF6ReoPXUTDxnujienzuA9EBsFIhEcC6uLCg==", "f0c5bd2f-6864-4522-bedb-1dbfb46ce200" });

            migrationBuilder.UpdateData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsPublic",
                value: false);
        }
    }
}
