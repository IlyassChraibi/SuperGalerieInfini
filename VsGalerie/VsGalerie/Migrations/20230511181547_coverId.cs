using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class coverId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverId",
                table: "Galerie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4bba636-e55e-4c57-8c9e-027794d852b5", "AQAAAAEAACcQAAAAEDMgmC0yomtJrxqVJ5PGgCF+S+D0yyrIUw8qrdApw2i5LQXik2hZjs58aFvl9x8W0g==", "e4fb980f-9968-45ed-87a6-a21f679d5725" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3dd264c-4f03-4f0e-8e3c-e5feba740349", "AQAAAAEAACcQAAAAECHscSJ3hkX1ojIOKkiMKvNEQhBDbzwzzpg7+BGq1qNxJB+eTTqbhOfvASZg0bfWwA==", "641df2f0-ef87-4dd2-8efc-792066c62780" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Galerie");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9addba7-4d5a-4cf1-a954-8856b375ca58", "AQAAAAEAACcQAAAAEHuSa8ogN+hfgXGL9ffSiLA0Ciu2v8y0BLWMCXZwE2NoAJvEFdSsTuk3wWUTBd7QSw==", "0ae04629-76f3-4c12-9a17-9552f2118c6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8157c46-2c50-4cf8-a60e-ad6c41277efb", "AQAAAAEAACcQAAAAEFnNmhYmEwGrFOY2HvK6VYMj5Iqns3qZDZ93grV0xaYwzaL2QWX4K53NytpCY3xDDA==", "de682384-be76-46a4-afe7-e259266ef85c" });
        }
    }
}
