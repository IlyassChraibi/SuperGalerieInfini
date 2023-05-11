using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class erreurCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e64c6a65-13b2-4468-8e66-7d7ee19df9e5", "AQAAAAEAACcQAAAAEOl0HBDC8EaFrNYr+LQoCnRUrYO1HWz/AT4uiMnuVN4+QBnQvRjjJufNB3TfvIbW1g==", "561e14ea-dbe3-44fb-a89e-dada60d431ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a24b91c1-2c0c-425c-832d-f89fd9577aaa", "AQAAAAEAACcQAAAAEJm9UAPp3Ieq6frZqmzGTPx9CBQMcA175w36jYEy1ZWHXN5nyefQqPliF8buyKlosw==", "61ad8d4b-1578-4f83-af18-d5ea9295ab6b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
