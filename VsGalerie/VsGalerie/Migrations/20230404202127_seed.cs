using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "16a42d53-21d6-4e21-abe8-fc83a2d3f61f", "i.i@i.ca", false, false, null, "I.I@I.CA", "ILYASS", "AQAAAAEAACcQAAAAEI7ggGAyX2SLYifa4UvdGmytjbgxX6TCCzbRvIAyEs7abmDjiN1/nJYpcBJRL/fd6Q==", null, false, "90347545-2b37-4141-80a3-862075b51956", false, "ilyass" },
                    { "21111111-1111-1111-1111-111111111112", 0, "778147fd-84c8-4956-a901-4dbd6788a44d", "i.i@i.ca", false, false, null, "I.I@I.CA", "ILYAS", "AQAAAAEAACcQAAAAELxBgK6YMcQSTZ06sCBGqOgTeURPUveF6ReoPXUTDxnujienzuA9EBsFIhEcC6uLCg==", null, false, "f0c5bd2f-6864-4522-bedb-1dbfb46ce200", false, "ilyas" }
                });

            migrationBuilder.InsertData(
                table: "Galerie",
                columns: new[] { "Id", "IsPublic", "Name" },
                values: new object[,]
                {
                    { 1, true, "tableau" },
                    { 2, false, "tableau2" },
                    { 3, false, "sym1" },
                    { 4, false, "sym2" }
                });

            migrationBuilder.InsertData(
                table: "GalerieUser",
                columns: new[] { "GaleriesId", "UserId" },
                values: new object[,]
                {
                    { 1, "11111111-1111-1111-1111-111111111111" },
                    { 2, "11111111-1111-1111-1111-111111111111" },
                    { 3, "21111111-1111-1111-1111-111111111112" },
                    { 4, "21111111-1111-1111-1111-111111111112" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GalerieUser",
                keyColumns: new[] { "GaleriesId", "UserId" },
                keyValues: new object[] { 1, "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "GalerieUser",
                keyColumns: new[] { "GaleriesId", "UserId" },
                keyValues: new object[] { 2, "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.DeleteData(
                table: "GalerieUser",
                keyColumns: new[] { "GaleriesId", "UserId" },
                keyValues: new object[] { 3, "21111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "GalerieUser",
                keyColumns: new[] { "GaleriesId", "UserId" },
                keyValues: new object[] { 4, "21111111-1111-1111-1111-111111111112" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112");

            migrationBuilder.DeleteData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Galerie",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
