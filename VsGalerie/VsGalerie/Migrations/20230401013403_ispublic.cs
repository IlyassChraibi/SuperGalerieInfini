using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VsGalerie.Migrations
{
    public partial class ispublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Public",
                table: "Galerie",
                newName: "IsPublic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Galerie",
                newName: "Public");
        }
    }
}
