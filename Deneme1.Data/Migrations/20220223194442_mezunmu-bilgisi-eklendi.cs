using Microsoft.EntityFrameworkCore.Migrations;

namespace Deneme1.Data.Migrations
{
    public partial class mezunmubilgisieklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGraduate",
                table: "Student",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGraduate",
                table: "Student");
        }
    }
}
