using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Unis.Migrations
{
    public partial class remove_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Universities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Universities",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
