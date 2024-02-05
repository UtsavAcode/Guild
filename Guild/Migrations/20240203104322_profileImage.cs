using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guild.Migrations
{
    public partial class profileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "Workers",
                newName: "ProfileImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImageUrl",
                table: "Workers",
                newName: "ProfileImage");
        }
    }
}
