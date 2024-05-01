using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkCinema.Persistance.Migrations
{
    public partial class AddBlogAuthorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogAuthorName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogAuthorName",
                table: "Blogs");
        }
    }
}
