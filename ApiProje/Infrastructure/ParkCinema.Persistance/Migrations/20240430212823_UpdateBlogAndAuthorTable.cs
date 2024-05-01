using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkCinema.Persistance.Migrations
{
    public partial class UpdateBlogAndAuthorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilImageUrl",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilImageUrl",
                table: "Authors");
        }
    }
}
