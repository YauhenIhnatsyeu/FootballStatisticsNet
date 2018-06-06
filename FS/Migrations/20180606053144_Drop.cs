using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.Migrations
{
    public partial class Drop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "FavoriteTeams",
                table => new
                {
                    UserId = table.Column<string>(),
                    TeamId = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_TeamId", x => new {x.UserId, x.TeamId}); }
            );
            migrationBuilder.AddForeignKey("FK_UserId", "FavoriteTeams", "UserId", "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_UserId", "AspNetUsers");
            migrationBuilder.DropTable("FavoriteTeams");
        }
    }
}