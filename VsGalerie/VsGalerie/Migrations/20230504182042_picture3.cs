using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class picture3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Picture");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0735c14-58b7-4c1a-b38a-4ef35b5f24ee", "AQAAAAEAACcQAAAAEAwUbVv+u5iWEzwtds+VOE5qFI/aXEPqnJIYCrz24qOPLjQID2ZVw6l4xDIrfYyvxA==", "9071b363-d164-4056-861d-21dbc4dd90f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cde263fe-be9a-4e06-8175-d8292ff7f987", "AQAAAAEAACcQAAAAEHJ5J14CAET7N769FIqkztp25W+SxZzijT4OIzQtVOXVN93AFlazryi+OVcFLNwaog==", "c2c87f93-66b0-4248-a350-2d9988653b98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Picture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
