using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guild.Migrations
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Workers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Workers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
