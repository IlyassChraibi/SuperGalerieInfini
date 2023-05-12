using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class pictureUndef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Galerie_GalerieId",
                table: "Picture");

            migrationBuilder.AlterColumn<int>(
                name: "GalerieId",
                table: "Picture",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Galerie_GalerieId",
                table: "Picture",
                column: "GalerieId",
                principalTable: "Galerie",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Galerie_GalerieId",
                table: "Picture");

            migrationBuilder.AlterColumn<int>(
                name: "GalerieId",
                table: "Picture",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Galerie_GalerieId",
                table: "Picture",
                column: "GalerieId",
                principalTable: "Galerie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
