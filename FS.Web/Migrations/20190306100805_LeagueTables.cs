using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.Web.Migrations
{
    public partial class LeagueTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    PlayedGames = table.Column<int>(nullable: false),
                    Won = table.Column<int>(nullable: false),
                    Draw = table.Column<int>(nullable: false),
                    Lost = table.Column<int>(nullable: false),
                    GoalsFor = table.Column<int>(nullable: false),
                    GoalsAgainst = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueTable_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTables_TeamId",
                table: "LeagueTables",
                column: "TeamId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueTables");
        }
    }
}
