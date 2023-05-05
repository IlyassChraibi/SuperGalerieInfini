using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class GalPic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalerieId",
                table: "Picture",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Picture_GalerieId",
                table: "Picture",
                column: "GalerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Galerie_GalerieId",
                table: "Picture",
                column: "GalerieId",
                principalTable: "Galerie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Galerie_GalerieId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_GalerieId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "GalerieId",
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
    }
}
