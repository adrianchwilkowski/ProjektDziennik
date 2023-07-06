using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektDziennik.Migrations
{
    public partial class LittleChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
