using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AvatarUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    CrestUrl = table.Column<string>(nullable: true),
                    SquadMarketValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FanClubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanClubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FanClub_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteTeams",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTeams", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_FavoriteTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteTeams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueTables",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    TeamCode = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UsersFanClubs",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FanClubId = table.Column<int>(nullable: false),
                    UserIsCreator = table.Column<bool>(nullable: true),
                    MemberStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFanClubs", x => new { x.UserId, x.FanClubId });
                    table.ForeignKey(
                        name: "FK_UsersFanClubs_FanClubs_FanClubId",
                        column: x => x.FanClubId,
                        principalTable: "FanClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersFanClubs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Code", "CrestUrl", "Name", "ShortName", "SquadMarketValue" },
                values: new object[,]
                {
                    { 758, 758, null, "Uruguay", "Uruguay", null },
                    { 6146, 6146, null, "PAOK FC", "PAOK FC", null },
                    { 5961, 5961, null, "MOL Vidi FC", "MOL Vidi", null },
                    { 5945, 5945, null, "KF Valur Reykjavík", "Valur", null },
                    { 5819, 5819, null, "FK Sūduva Marijampolė", "FK Sūduva", null },
                    { 5813, 5813, null, "Valletta FC", "Valletta", null },
                    { 5740, 5740, null, "Crusaders FC", "Crusaders", null },
                    { 5520, 5520, null, "Cork City FC", "Cork City FC", null },
                    { 5515, 5515, null, "FC CFR 1907 Cluj", "CFR 1907 Cluj", null },
                    { 5455, 5455, null, "FK Lokomotiv Moskva", "Lok Moskva", null },
                    { 5123, 5123, null, "HJK", "HJK", null },
                    { 5100, 5100, null, "FC Flora", "Flora", null },
                    { 4485, 4485, null, "FC Midtjylland", "Midtjylland", null },
                    { 2021, 2021, null, "SK Sturm Graz", "Sturm Graz", null },
                    { 1905, 1905, null, "Víkingur Gøta", "Víkingur Gøta", null },
                    { 1904, 1904, null, "The New Saints FC", "The New Saints", null },
                    { 1903, 1903, null, "Sport Lisboa e Benfica", "SL Benfica", null },
                    { 1902, 1902, null, "SP La Fiorita", "La Fiorita", null },
                    { 1875, 1875, null, "F91 Diddeleng", "F91 Dudelange", null },
                    { 1877, 1877, null, "FC Red Bull Salzburg", "RB Salzburg", null },
                    { 1879, 1879, null, "FC Santa Coloma", "Santa Coloma", null },
                    { 1880, 1880, null, "FC Sheriff Tiraspol", "Sheriff", null },
                    { 1881, 1881, null, "FC Viktoria Plzeň", "Viktoria Plzeň", null },
                    { 1884, 1884, null, "Astana FK", "Astana FK", null },
                    { 7281, 7281, null, "Lincoln Red Imps FC", "Lincoln", null },
                    { 1886, 1886, null, "FK Kukësi", "Kukësi", null },
                    { 1888, 1888, null, "FK Spartaks Jūrmala", "Spartaks Jūr", null },
                    { 1891, 1891, null, "Hapoel Be'er Sheva FC", "Hapoel BS", null },
                    { 1894, 1894, null, "HŠK Zrinjski Mostar", "Zrinjski", null },
                    { 1899, 1899, null, "PAE AEK", "PAE AEK", null },
                    { 1900, 1900, null, "PFC CSKA Moskva", "CSKA Moskva", null },
                    { 1901, 1901, null, "PFK Ludogorets 1945 Razgrad", "Ludgorets", null },
                    { 1887, 1887, null, "FK Shakhtar Donetsk", "Shak Donetsk", null },
                    { 7282, 7282, null, "Drita KF Gjilan", "Drita Gjilan", null },
                    { 7283, 7283, null, "FK Crvena Zvezda", "Crvena Zvedza", null },
                    { 7284, 7284, null, "FK Sutjeska Nikšić", "Sutjeska Nik", null },
                    { 668, 668, null, "VVV Venlo", "VVV Venlo", null },
                    { 670, 670, "https://upload.wikimedia.org/wikipedia/en/f/f5/SBV_Excelsior_logo.png", "SBV Excelsior", "Excelsior", null },
                    { 671, 671, "https://upload.wikimedia.org/wikipedia/de/d/d8/Heracles_Almelo.svg", "Heracles Almelo", "Heracles", null },
                    { 672, 672, "https://upload.wikimedia.org/wikipedia/de/7/7c/Willem_II_Tilburg.svg", "Willem II Tilburg", "Willem II", null },
                    { 673, 673, "https://upload.wikimedia.org/wikipedia/de/e/e7/SC_Heerenveen.svg", "SC Heerenveen", "Heerenveen", null },
                    { 675, 675, "https://upload.wikimedia.org/wikipedia/de/2/24/Logo_Feyenoord_Rotterdam.svg", "Feyenoord Rotterdam", "Feyenoord", null },
                    { 721, 721, "https://upload.wikimedia.org/wikipedia/en/0/04/RB_Leipzig_2014_logo.svg", "RB Leipzig", "RB Leipzig", null },
                    { 676, 676, "https://upload.wikimedia.org/wikipedia/de/4/48/FC_Utrecht.svg", "FC Utrecht", "Utrecht", null },
                    { 679, 679, "https://upload.wikimedia.org/wikipedia/de/4/41/Vitesse_Arnheim.svg", "SBV Vitesse", "Vitesse", null },
                    { 680, 680, "https://upload.wikimedia.org/wikipedia/de/4/45/ADO_Den_Haag.svg", "ADO Den Haag", "ADO Den Haag", null },
                    { 681, 681, "https://upload.wikimedia.org/wikipedia/en/7/76/Breda.png", "NAC Breda", "NAC Breda", null },
                    { 682, 682, "https://upload.wikimedia.org/wikipedia/commons/e/e0/AZ_Alkmaar.svg", "AZ", "AZ", null },
                    { 684, 684, "https://upload.wikimedia.org/wikipedia/de/2/28/PEC_Zwolle_2012.svg", "PEC Zwolle", "Zwolle", null },
                    { 1913, 1913, null, "VBV De Graafschap", "Graafschap", null },
                    { 677, 677, "https://upload.wikimedia.org/wikipedia/de/e/ef/FC_Groningen.svg", "FC Groningen", "Groningen", null },
                    { 1871, 1871, null, "BSC Young Boys", "Young Boys", null },
                    { 24, 24, "https://upload.wikimedia.org/wikipedia/commons/9/94/Fortuna_D%C3%BCsseldorf.svg", "TSV Fortuna 95 Düsseldorf", "Düsseldorf", null },
                    { 18, 18, "https://upload.wikimedia.org/wikipedia/commons/8/81/Borussia_M%C3%B6nchengladbach_logo.svg", "Borussia Mönchengladbach", "M'gladbach", null },
                    { 7285, 7285, null, "KF Shkëndija 79", "Shkëndija 79", null },
                    { 7286, 7286, null, "FC Torpedo Kutaisi", "Torp Kutaisi", null },
                    { 7287, 7287, null, "NK Olimpija Ljubljana", "Olimpija Ljubl", null },
                    { 7288, 7288, null, "FC Spartak Trnava", "Spartak Trnava", null },
                    { 3, 3, "https://upload.wikimedia.org/wikipedia/en/5/59/Bayer_04_Leverkusen_logo.svg", "Bayer 04 Leverkusen", "Leverkusen", null },
                    { 8, 8, "https://upload.wikimedia.org/wikipedia/commons/c/cd/Hannover_96_Logo.svg", "Hannover 96", "Hannover", null },
                    { 19, 19, "https://upload.wikimedia.org/wikipedia/commons/0/04/Eintracht_Frankfurt_Logo.svg", "Eintracht Frankfurt", "Frankfurt", null },
                    { 9, 9, "https://upload.wikimedia.org/wikipedia/commons/8/81/Hertha_BSC_Logo_2012.svg", "Hertha BSC", "Hertha BSC", null },
                    { 11, 11, "https://upload.wikimedia.org/wikipedia/commons/f/f3/Logo-VfL-Wolfsburg.svg", "VfL Wolfsburg", "Wolfsburg", null },
                    { 12, 12, "https://upload.wikimedia.org/wikipedia/commons/b/be/SV-Werder-Bremen-Logo.svg", "SV Werder Bremen", "Bremen", null },
                    { 14, 14, "https://upload.wikimedia.org/wikipedia/commons/f/fa/1._FC_N%C3%BCrnberg_logo.svg", "1. FC Nürnberg", "Nürnberg", null },
                    { 15, 15, "https://upload.wikimedia.org/wikipedia/commons/9/9e/Logo_Mainz_05.svg", "1. FSV Mainz 05", "Mainz", null },
                    { 16, 16, "https://upload.wikimedia.org/wikipedia/de/b/b5/Logo_FC_Augsburg.svg", "FC Augsburg", "Augsburg", null },
                    { 17, 17, "https://upload.wikimedia.org/wikipedia/de/f/f1/SC-Freiburg_Logo-neu.svg", "SC Freiburg", "Freiburg", null },
                    { 10, 10, "https://upload.wikimedia.org/wikipedia/commons/a/ab/VfB_Stuttgart_Logo.svg", "VfB Stuttgart", "Stuttgart", null },
                    { 1914, 1914, null, "FC Emmen", "Emmen", null },
                    { 1870, 1870, null, "Alashkert FC", "Alashkert", null },
                    { 1105, 1105, "https://upload.wikimedia.org/wikipedia/commons/b/b5/Legia_Warszawa.svg", "Legia Warszawa", "Legia", null },
                    { 1836, 1836, null, "Panama", "Panama", null },
                    { 1066, 1066, "https://upload.wikimedia.org/wikipedia/commons/c/ce/Flag_of_Iceland.svg", "Iceland", "Iceland", null },
                    { 840, 840, null, "Iran", "Iran", null },
                    { 832, 832, null, "Peru", "Peru", null },
                    { 825, 825, null, "Egypt", "Egypt", null },
                    { 818, 818, null, "Colombia", "Colombia", null },
                    { 815, 815, null, "Morocco", "Morocco", null },
                    { 808, 808, "https://upload.wikimedia.org/wikipedia/en/f/f3/Flag_of_Russia.svg", "Russia", "Russia", null },
                    { 805, 805, "https://upload.wikimedia.org/wikipedia/commons/6/65/Flag_of_Belgium.svg", "Belgium", "Belgium", null },
                    { 804, 804, null, "Senegal", "Senegal", null },
                    { 802, 802, null, "Tunisia", "Tunisia", null },
                    { 801, 801, null, "Saudi Arabia", "Saudi Arabia", null },
                    { 799, 799, "https://upload.wikimedia.org/wikipedia/commons/1/1b/Flag_of_Croatia.svg", "Croatia", "Croatia", null },
                    { 794, 794, "https://upload.wikimedia.org/wikipedia/en/1/12/Flag_of_Poland.svg", "Poland", "Poland", null },
                    { 793, 793, null, "Costa Rica", "Costa Rica", null },
                    { 792, 792, "https://upload.wikimedia.org/wikipedia/en/4/4c/Flag_of_Sweden.svg", "Sweden", "Sweden", null },
                    { 788, 788, null, "Switzerland", "Switzerland", null },
                    { 759, 759, "https://upload.wikimedia.org/wikipedia/en/b/ba/Flag_of_Germany.svg", "Germany", "Germany", null },
                    { 760, 760, "https://upload.wikimedia.org/wikipedia/en/9/9a/Flag_of_Spain.svg", "Spain", "Spain", null },
                    { 762, 762, null, "Argentina", "Argentina", null },
                    { 764, 764, null, "Brazil", "Brazil", null },
                    { 765, 765, "https://upload.wikimedia.org/wikipedia/commons/5/5c/Flag_of_Portugal.svg", "Portugal", "Portugal", null },
                    { 766, 766, null, "Japan", "Japan", null },
                    { 2, 2, "https://upload.wikimedia.org/wikipedia/commons/e/e7/Logo_TSG_Hoffenheim.svg", "TSG 1899 Hoffenheim", "Hoffenheim", null },
                    { 769, 769, null, "Mexico", "Mexico", null },
                    { 772, 772, null, "Korea Republic", "Korea Rep", null },
                    { 773, 773, "https://upload.wikimedia.org/wikipedia/en/c/c3/Flag_of_France.svg", "France", "France", null },
                    { 776, 776, null, "Nigeria", "Nigeria", null },
                    { 779, 779, null, "Australia", "Australia", null },
                    { 780, 780, null, "Serbia", "Serbia", null },
                    { 782, 782, null, "Denmark", "Denmark", null },
                    { 770, 770, "https://upload.wikimedia.org/wikipedia/en/b/be/Flag_of_England.svg", "England", "England", null },
                    { 4, 4, "https://upload.wikimedia.org/wikipedia/commons/6/67/Borussia_Dortmund_logo.svg", "BV Borussia 09 Dortmund", "Dortmund", null },
                    { 5, 5, "https://upload.wikimedia.org/wikipedia/commons/1/1b/FC_Bayern_M%C3%BCnchen_logo_%282017%29.svg", "FC Bayern München", "Bayern M", null },
                    { 6, 6, "https://upload.wikimedia.org/wikipedia/commons/6/6d/FC_Schalke_04_Logo.svg", "FC Schalke 04", "Schalke", null },
                    { 613, 613, null, "Fenerbahçe SK", "Fenerbahçe", null },
                    { 674, 674, "https://upload.wikimedia.org/wikipedia/de/0/05/PSV_Eindhoven.svg", "PSV", "PSV", null },
                    { 678, 678, "https://upload.wikimedia.org/wikipedia/de/7/79/Ajax_Amsterdam.svg", "AFC Ajax", "Ajax", null },
                    { 729, 729, "https://upload.wikimedia.org/wikipedia/commons/c/c5/FC_Basel.png", "FC Basel 1893", "Basel", null },
                    { 732, 732, "https://upload.wikimedia.org/wikipedia/en/3/35/Celtic_FC.svg", "Celtic FC", "Celtic", null },
                    { 748, 748, "https://upload.wikimedia.org/wikipedia/de/thumb/0/0a/Logo_BATE_Baryssau.svg/150px-Logo_BATE_Baryssau.svg.png", "FK BATE Borisov", "BATE", null },
                    { 611, 611, null, "Qarabağ Ağdam FK", "Qarabağ Ağdam", null },
                    { 749, 749, "https://upload.wikimedia.org/wikipedia/de/1/17/Logo_Malm%C3%B6_FF.svg", "Malmö FF", "Malmö FF", null },
                    { 754, 754, null, "FK Spartak Moskva", "Spartak Moskva", null },
                    { 755, 755, "https://www.gnkdinamo.hr/Content/Images/main-logo.png", "GNK Dinamo Zagreb", "Dinamo Zagreb", null },
                    { 842, 842, "https://upload.wikimedia.org/wikipedia/commons/5/5b/FC_Dynamo_Kyiv_logo.png", "FK Dynamo Kyiv", "Dynamo Kyiv", null },
                    { 851, 851, null, "Club Brugge KV", "Club Brugge", null },
                    { 889, 889, null, "Rosenborg BK", "Rosenborg", null },
                    { 930, 930, null, "SK Slavia Praha", "Slavia Praha", null },
                    { 752, 752, "https://upload.wikimedia.org/wikipedia/en/0/06/APOELnew.png", "APOEL FC", "APOEL", null },
                    { 1866, 1866, null, "Royal Standard de Liège", "Standard Liège", null },
                    { 610, 610, "https://upload.wikimedia.org/wikipedia/commons/f/f6/Galatasaray_Sports_Club_Logo.png", "Galatasaray SK", "Galatasaray", null },
                    { 524, 524, "https://upload.wikimedia.org/wikipedia/fr/thumb/8/86/Paris_Saint-Germain_Logo.svg/130px-Paris_Saint-Germain_Logo.svg", "Paris Saint-Germain FC", "PSG", null },
                    { 64, 64, "https://upload.wikimedia.org/wikipedia/de/0/0a/FC_Liverpool.svg", "Liverpool FC", "Liverpool", null },
                    { 65, 65, "https://upload.wikimedia.org/wikipedia/en/e/eb/Manchester_City_FC_badge.svg", "Manchester City FC", "Man City", null },
                    { 66, 66, "https://upload.wikimedia.org/wikipedia/de/d/da/Manchester_United_FC.svg", "Manchester United FC", "Man United", null },
                    { 73, 73, "https://upload.wikimedia.org/wikipedia/de/b/b4/Tottenham_Hotspur.svg", "Tottenham Hotspur FC", "Tottenham", null },
                    { 78, 78, "https://upload.wikimedia.org/wikipedia/de/c/c1/Atletico_Madrid_logo.svg", "Club Atlético de Madrid", "Club Atlético", null },
                    { 81, 81, "https://upload.wikimedia.org/wikipedia/de/a/aa/Fc_barcelona.svg", "FC Barcelona", "Barcelona", null },
                    { 548, 548, "https://upload.wikimedia.org/wikipedia/fr/thumb/b/ba/AS_Monaco_FC.svg/130px-AS_Monaco_FC.svg", "AS Monaco FC", "AS Monaco", null },
                    { 86, 86, "https://upload.wikimedia.org/wikipedia/de/3/3f/Real_Madrid_Logo.svg", "Real Madrid CF", "Real Madrid", null },
                    { 100, 100, "https://upload.wikimedia.org/wikipedia/de/3/32/AS_Rom.svg", "AS Roma", "Roma", null },
                    { 108, 108, "https://upload.wikimedia.org/wikipedia/en/thumb/0/0b/Inter_Milan.svg/316px-Inter_Milan.svg", "FC Internazionale Milano", "Inter", null },
                    { 109, 109, "https://upload.wikimedia.org/wikipedia/de/d/d2/Juventus_Turin.svg", "Juventus FC", "Juventus", null },
                    { 113, 113, "https://upload.wikimedia.org/wikipedia/commons/2/28/S.S.C._Napoli_logo.svg", "SSC Napoli", "Napoli", null },
                    { 503, 503, "https://upload.wikimedia.org/wikipedia/de/e/ed/FC_Porto_1922-2005.svg", "FC Porto", "Porto", null },
                    { 523, 523, "https://upload.wikimedia.org/wikipedia/fr/thumb/e/e2/Olympique_lyonnais_%28logo%29.svg/130px-Olympique_lyonnais_%28logo%29.svg", "Olympique Lyonnais", "Olympique Lyon", null },
                    { 95, 95, "https://upload.wikimedia.org/wikipedia/de/7/75/FC_Valencia.svg", "Valencia CF", "Valencia", null },
                    { 1920, 1920, null, "Fortuna Sittard", "F Sittard", null }
                });

            migrationBuilder.InsertData(
                table: "LeagueTables",
                columns: new[] { "Id", "Code", "Draw", "GoalsAgainst", "GoalsFor", "Lost", "PlayedGames", "Points", "Position", "TeamCode", "TeamId", "TeamName", "Won" },
                values: new object[,]
                {
                    { "d8736808-7255-47f9-8fa8-f6c67964c699", 2000, 0, 0, 5, 0, 3, 9, 1, 758, 758, "Uruguay", 3 },
                    { "7ec8be0a-4120-48e2-a6e3-1784758e5bb0", 2001, 0, 8, 4, 2, 3, 3, 3, 1903, 1903, "Sport Lisboa e Benfica", 1 },
                    { "64dacc32-e772-4f4e-b77a-79bd7c9d8c2c", 2001, 1, 3, 2, 1, 3, 4, 3, 1903, 1903, "Sport Lisboa e Benfica", 1 },
                    { "b3e0123f-bc2d-4a46-88a6-1aded9db5665", 2001, 1, 11, 6, 3, 6, 7, 3, 1903, 1903, "Sport Lisboa e Benfica", 2 },
                    { "7dc313d3-74f0-48f5-99a0-4c120ad58179", 2001, 1, 5, 5, 1, 3, 4, 2, 1900, 1900, "PFC CSKA Moskva", 1 },
                    { "e604ba7c-2d54-4903-8dce-72994ce8a2b8", 2001, 0, 4, 3, 2, 3, 3, 4, 1900, 1900, "PFC CSKA Moskva", 1 },
                    { "ba3375bd-fea6-42cb-ab4f-32166dcddab0", 2001, 1, 9, 8, 3, 6, 7, 4, 1900, 1900, "PFC CSKA Moskva", 2 },
                    { "db68b298-cb6b-4a0a-836a-7cd704ed0626", 2001, 0, 12, 4, 5, 6, 3, 4, 5455, 5455, "FK Lokomotiv Moskva", 1 },
                    { "4b065122-10fb-43f0-8768-2decaae03252", 2001, 0, 6, 0, 3, 3, 0, 4, 1899, 1899, "PAE AEK", 0 },
                    { "ce5339d8-9225-4f5e-910e-590f3bfa9a8b", 2001, 0, 13, 2, 6, 6, 0, 4, 1899, 1899, "PAE AEK", 0 },
                    { "fd34de02-ff1c-4c7c-8444-6a8201e65f2c", 2001, 1, 10, 5, 1, 3, 4, 3, 1887, 1887, "FK Shakhtar Donetsk", 1 },
                    { "5946220d-9282-48ef-86f6-584c4023f324", 2001, 2, 6, 3, 1, 3, 2, 3, 1887, 1887, "FK Shakhtar Donetsk", 0 },
                    { "7ba2aab1-f6dd-4451-95df-d739507a9e48", 2001, 3, 16, 8, 2, 6, 6, 3, 1887, 1887, "FK Shakhtar Donetsk", 1 },
                    { "b23f67ce-8d58-442c-847a-92660b4b9848", 2001, 0, 8, 3, 2, 3, 3, 4, 1881, 1881, "FC Viktoria Plzeň", 1 },
                    { "401e5911-53aa-4758-ba77-94afa29ecfcf", 2001, 1, 8, 4, 1, 3, 4, 3, 1881, 1881, "FC Viktoria Plzeň", 1 },
                    { "dc43f615-ee81-4c3b-bc95-d10ac87322ff", 2001, 0, 7, 2, 3, 3, 0, 4, 1899, 1899, "PAE AEK", 0 },
                    { "89dd0061-075c-467e-b7c0-93ba27a8f0ec", 2001, 0, 4, 3, 2, 3, 3, 4, 5455, 5455, "FK Lokomotiv Moskva", 1 },
                    { "30413b17-f235-401e-a1fd-f38cc7083678", 2001, 0, 8, 1, 3, 3, 0, 4, 5455, 5455, "FK Lokomotiv Moskva", 0 },
                    { "cf100f23-11e4-4ec4-9d11-404e6fd876a3", 2001, 1, 17, 5, 4, 6, 4, 4, 7283, 7283, "FK Crvena Zvezda", 1 },
                    { "7a6e8f67-8c7c-48ec-a380-c48a4c29a6a1", 2002, 6, 37, 39, 8, 25, 39, 7, 11, 11, "VfL Wolfsburg", 11 },
                    { "9fce078e-3afb-430d-87ef-0aee6703e826", 2002, 2, 31, 9, 10, 13, 5, 16, 10, 10, "VfB Stuttgart", 1 },
                    { "47764d00-741a-45a8-88a0-337c15c36769", 2002, 2, 24, 16, 6, 12, 14, 14, 10, 10, "VfB Stuttgart", 4 },
                    { "65e55597-76f5-4533-b495-d34fc4b76b34", 2002, 4, 55, 25, 16, 25, 19, 16, 10, 10, "VfB Stuttgart", 5 },
                    { "120eda15-1222-4f90-af08-2442ce962845", 2002, 3, 20, 19, 6, 13, 15, 10, 9, 9, "Hertha BSC", 4 },
                    { "3dc47ce3-1ed7-4f7b-8e5b-f374f5aeb57a", 2002, 5, 16, 19, 2, 12, 20, 10, 9, 9, "Hertha BSC", 5 },
                    { "c11858ea-80f2-4a06-b52e-09e70bcb4bb4", 2002, 8, 36, 38, 8, 25, 35, 10, 9, 9, "Hertha BSC", 9 },
                    { "cad0c868-710e-4787-a813-02e282ce1db7", 2002, 4, 34, 12, 8, 12, 4, 17, 8, 8, "Hannover 96", 0 },
                    { "b2331050-d6e7-4495-a0d8-8d44f54df0f8", 2002, 1, 24, 11, 9, 13, 10, 18, 8, 8, "Hannover 96", 3 },
                    { "86138773-a07f-422e-83a8-024a6120fa99", 2002, 5, 58, 23, 17, 25, 14, 17, 8, 8, "Hannover 96", 3 },
                    { "285cca00-5c34-4237-8a67-24a376922235", 2002, 2, 21, 26, 5, 13, 20, 6, 3, 3, "Bayer 04 Leverkusen", 6 },
                    { "5f80bbca-ff6a-46c8-a195-858b54619d3f", 2002, 1, 16, 20, 4, 12, 22, 5, 3, 3, "Bayer 04 Leverkusen", 7 },
                    { "e8afd0e6-d342-4643-9cdd-cd86daf38765", 2002, 3, 37, 46, 9, 25, 42, 6, 3, 3, "Bayer 04 Leverkusen", 13 },
                    { "317d760c-d5b5-4011-9061-fb847c7d5efe", 2001, 0, 13, 2, 3, 3, 0, 4, 7283, 7283, "FK Crvena Zvezda", 0 },
                    { "b7495462-2584-4c81-bf7e-82029fb2665d", 2001, 1, 4, 3, 1, 3, 4, 4, 7283, 7283, "FK Crvena Zvezda", 1 },
                    { "fd16e489-018f-400f-8483-3c7d09ba510c", 2001, 1, 16, 7, 3, 6, 7, 3, 1881, 1881, "FC Viktoria Plzeň", 2 },
                    { "897478bc-aef6-4329-9ad2-8594a05b2890", 2001, 0, 7, 1, 3, 3, 0, 4, 1871, 1871, "BSC Young Boys", 0 },
                    { "87d36c38-aa50-4151-b046-28eeed5966b9", 2001, 1, 5, 3, 1, 3, 4, 4, 1871, 1871, "BSC Young Boys", 1 },
                    { "2924b172-71ef-46bc-b88e-9d9ca123369a", 2001, 1, 12, 4, 4, 6, 4, 4, 1871, 1871, "BSC Young Boys", 1 },
                    { "bf8efef5-7498-49d0-9057-95e303c14c13", 2001, 0, 8, 1, 3, 3, 0, 4, 548, 548, "AS Monaco FC", 0 },
                    { "9f8c3a5b-c00b-4bf5-8481-fb0d2741f882", 2001, 1, 14, 2, 5, 6, 1, 4, 548, 548, "AS Monaco FC", 0 },
                    { "a5d6f94b-7849-4491-ad3d-6ee960cdb979", 2001, 1, 5, 7, 1, 3, 4, 1, 524, 524, "Paris Saint-Germain FC", 1 },
                    { "48ef351a-95c3-436e-b42d-3b422fb1a568", 2001, 1, 4, 10, 0, 3, 7, 2, 524, 524, "Paris Saint-Germain FC", 2 },
                    { "7794f993-325e-484f-ac77-9a5e14aad75e", 2001, 2, 9, 17, 1, 6, 11, 1, 524, 524, "Paris Saint-Germain FC", 3 },
                    { "9af74416-680e-4f40-b106-e29e994c5de0", 2001, 2, 5, 6, 0, 3, 5, 2, 523, 523, "Olympique Lyonnais", 1 },
                    { "33012e5e-e10c-4490-b365-1cef105b22da", 2001, 3, 6, 6, 0, 3, 3, 2, 523, 523, "Olympique Lyonnais", 0 },
                    { "e881714f-3e50-464b-b8f2-5916b75f3508", 2001, 5, 11, 12, 0, 6, 8, 2, 523, 523, "Olympique Lyonnais", 1 },
                    { "2b666335-5b55-4a64-8316-abcfa6ddef67", 2001, 1, 4, 7, 0, 3, 7, 1, 503, 503, "FC Porto", 2 },
                    { "7f72e675-7332-4f5a-b5ff-dc6990e1139c", 2001, 0, 2, 8, 0, 3, 9, 1, 503, 503, "FC Porto", 3 },
                    { "a2b22c2e-3940-448e-af11-9b64c0b5d962", 2001, 1, 6, 15, 0, 6, 16, 1, 503, 503, "FC Porto", 5 },
                    { "48f8d265-c946-4dad-9e15-35561d8d96cd", 2001, 2, 3, 2, 1, 3, 2, 2, 113, 113, "SSC Napoli", 0 },
                    { "7f24d213-d80b-461d-b877-5416b3590b2c", 2001, 1, 2, 5, 0, 3, 7, 3, 113, 113, "SSC Napoli", 2 },
                    { "7651729b-1fb9-499a-9536-18193df6232f", 2001, 3, 5, 7, 1, 6, 9, 3, 113, 113, "SSC Napoli", 2 },
                    { "d9a727dc-f5f4-44bb-ac30-f77150114101", 2001, 0, 2, 4, 1, 3, 6, 2, 109, 109, "Juventus FC", 2 },
                    { "ecd304c3-5507-4b81-8e0b-41f5880248a8", 2001, 1, 6, 1, 2, 3, 1, 4, 548, 548, "AS Monaco FC", 0 },
                    { "dcdebeb4-a26a-475d-b770-928d9f510d4e", 2002, 4, 18, 17, 4, 12, 16, 13, 11, 11, "VfL Wolfsburg", 4 },
                    { "c458f878-0c23-4135-bf93-33fdc46c32c4", 2001, 1, 8, 5, 4, 6, 4, 3, 610, 610, "Galatasaray SK", 1 },
                    { "f801c39f-c748-4628-81b7-6699ed595bcf", 2001, 0, 5, 0, 3, 3, 0, 3, 610, 610, "Galatasaray SK", 0 },
                    { "c2dcf577-d614-43e4-baa1-5d0dbfbd5451", 2001, 1, 3, 5, 1, 3, 4, 2, 851, 851, "Club Brugge KV", 1 },
                    { "5136bf09-c05d-41ac-bdf1-d14212a28704", 2001, 2, 2, 1, 1, 3, 2, 3, 851, 851, "Club Brugge KV", 0 },
                    { "37a54569-161d-411c-852a-fa99b54c0445", 2001, 3, 5, 6, 2, 6, 6, 3, 851, 851, "Club Brugge KV", 1 },
                    { "be53f6e2-479c-4c23-b578-ceb69462b0e9", 2003, 0, 14, 35, 3, 12, 27, 1, 678, 678, "AFC Ajax", 9 },
                    { "e6f9cd01-3003-45cd-bc2b-3760dfa6255d", 2003, 2, 6, 51, 0, 12, 32, 3, 678, 678, "AFC Ajax", 10 },
                    { "04af351d-870e-4ee7-8955-f64dae260c09", 2003, 2, 20, 86, 3, 24, 59, 2, 678, 678, "AFC Ajax", 19 },
                    { "e5372e56-0c98-4afa-8d59-1bad13c81cff", 2001, 2, 2, 4, 0, 3, 5, 2, 678, 678, "AFC Ajax", 1 },
                    { "ec633269-04ad-4d84-8fb9-927ade56b253", 2001, 1, 3, 7, 0, 3, 7, 2, 678, 678, "AFC Ajax", 2 },
                    { "6f713497-91d7-42b7-84db-14672e1d7e07", 2001, 3, 5, 11, 0, 6, 12, 2, 678, 678, "AFC Ajax", 3 },
                    { "ffcc279f-4ffa-446d-bcf5-66a28029556a", 2003, 3, 12, 32, 1, 12, 27, 2, 674, 674, "PSV", 8 },
                    { "5cf543bf-7336-47ae-8799-605cca2846f2", 2003, 1, 4, 46, 0, 13, 37, 1, 674, 674, "PSV", 12 },
                    { "b4951811-a970-47b2-bb51-8e399270dbcd", 2003, 4, 16, 78, 1, 25, 64, 1, 674, 674, "PSV", 20 },
                    { "b0dd5764-e9ac-485e-a6a7-7a3539f9a1df", 2001, 1, 7, 2, 2, 3, 1, 4, 674, 674, "PSV", 0 },
                    { "fe2277f1-2c82-4686-aac9-9e05e309d540", 2001, 1, 6, 4, 2, 3, 1, 4, 674, 674, "PSV", 0 },
                    { "4261d66f-5114-4a5c-8a14-151d81349719", 2001, 2, 13, 6, 4, 6, 2, 4, 674, 674, "PSV", 0 },
                    { "397e7010-0614-448c-8348-c7764ba81a3e", 2001, 1, 3, 5, 1, 3, 4, 3, 610, 610, "Galatasaray SK", 1 },
                    { "b929d58a-dc38-46f7-b060-ff90297d85b4", 2001, 0, 2, 5, 1, 3, 6, 1, 109, 109, "Juventus FC", 2 },
                    { "81d457bd-520c-43df-b590-097a5e74bb25", 2002, 2, 19, 22, 4, 13, 23, 2, 11, 11, "VfL Wolfsburg", 7 },
                    { "7e00cdcd-4956-4da4-82f3-442e00b06c00", 2002, 5, 21, 26, 3, 13, 20, 8, 12, 12, "SV Werder Bremen", 5 },
                    { "ece145ad-b6c8-400e-9678-559894c8babe", 2003, 3, 15, 15, 6, 12, 12, 12, 679, 679, "SBV Vitesse", 3 },
                    { "fb07036b-6ba5-4435-9245-231d48bf288d", 2003, 4, 18, 30, 1, 13, 28, 4, 679, 679, "SBV Vitesse", 8 },
                    { "4a399168-c2c0-42bc-b3bc-0ae1351f13f6", 2003, 7, 33, 45, 7, 25, 40, 5, 679, 679, "SBV Vitesse", 11 },
                    { "90266e9b-b9e5-42dd-a78b-3da711ee7cde", 2003, 4, 19, 10, 6, 13, 13, 11, 677, 677, "FC Groningen", 3 },
                    { "6bdf0b24-e7ce-4730-af2b-acdf7a0e2040", 2003, 1, 15, 20, 5, 12, 19, 9, 677, 677, "FC Groningen", 6 },
                    { "b95a9cae-13f8-4b5a-8221-2852330cec43", 2003, 5, 34, 30, 11, 25, 32, 9, 677, 677, "FC Groningen", 9 },
                    { "5e75db0e-8c3f-446d-ac04-7476a27aeeb1", 2003, 7, 51, 35, 11, 25, 28, 12, 680, 680, "ADO Den Haag", 7 },
                    { "981ff5b1-29ee-4a0b-8163-ee9a414b6f4e", 2003, 3, 22, 19, 5, 12, 15, 6, 676, 676, "FC Utrecht", 4 },
                    { "0af037e1-c423-4e96-94ab-fc0ad5dd0ec0", 2003, 7, 34, 41, 8, 25, 37, 6, 676, 676, "FC Utrecht", 10 },
                    { "f57f336e-aab6-47fe-82ab-2f6b6ae23eb0", 2003, 5, 21, 19, 5, 13, 14, 7, 675, 675, "Feyenoord Rotterdam", 3 },
                    { "c75fe34c-00a4-4ad5-b34e-c6c04fd993f3", 2003, 0, 9, 34, 1, 12, 33, 2, 675, 675, "Feyenoord Rotterdam", 11 },
                    { "960637f0-84c7-4fee-82e1-b5841cf137dc", 2003, 5, 30, 53, 6, 25, 47, 3, 675, 675, "Feyenoord Rotterdam", 14 },
                    { "b9e8b4d2-247e-4a5e-b1de-97d90b0d9284", 2003, 4, 28, 35, 3, 13, 22, 3, 673, 673, "SC Heerenveen", 6 },
                    { "4ff340d9-9c20-4c9c-ae2d-1daf353a4798", 2003, 5, 28, 21, 5, 12, 11, 17, 673, 673, "SC Heerenveen", 2 },
                    { "9d57298f-c64b-47d7-84c6-4e7fd8b85539", 2003, 4, 12, 22, 3, 13, 22, 7, 676, 676, "FC Utrecht", 6 },
                    { "f43adab4-6031-482d-ba31-222228f80c1d", 2003, 3, 26, 16, 6, 13, 15, 14, 680, 680, "ADO Den Haag", 4 },
                    { "a3ce984b-14ac-4e4b-af91-062f31d105f0", 2003, 4, 25, 19, 5, 12, 13, 10, 680, 680, "ADO Den Haag", 3 },
                    { "7a02ebfe-26d7-47bd-96ad-918c84aa9924", 2003, 5, 58, 23, 16, 25, 17, 18, 681, 681, "NAC Breda", 4 },
                    { "844ee857-e9a0-4ebc-ab7d-83acaed365c9", 2003, 5, 60, 40, 13, 25, 26, 14, 1920, 1920, "Fortuna Sittard", 7 },
                    { "368a2870-1019-4d0a-a546-9519b6e11dfa", 2003, 2, 31, 13, 6, 12, 14, 9, 1914, 1914, "FC Emmen", 4 },
                    { "59e08b43-cbef-4bca-bfa7-f25346696b82", 2003, 5, 26, 16, 6, 13, 11, 18, 1914, 1914, "FC Emmen", 2 },
                    { "ae3a0e8b-dec4-46a5-a245-9dc9a5e585bd", 2003, 7, 57, 29, 12, 25, 25, 16, 1914, 1914, "FC Emmen", 6 },
                    { "1d1e053a-22d4-411a-bc07-f3055ddddb94", 2003, 2, 34, 7, 9, 12, 5, 17, 1913, 1913, "VBV De Graafschap", 1 },
                    { "de603f95-ac0a-4b8e-819a-0ee373901436", 2003, 2, 21, 21, 6, 13, 17, 12, 1913, 1913, "VBV De Graafschap", 5 },
                    { "503e1ace-38fd-4a14-9216-d31b215de7bc", 2003, 4, 55, 28, 15, 25, 22, 17, 1913, 1913, "VBV De Graafschap", 6 },
                    { "5e4c72d1-a8b2-45c8-84c6-1c3622b3cd90", 2003, 2, 14, 9, 5, 11, 14, 8, 684, 684, "PEC Zwolle", 4 },
                    { "d419c98a-bf02-48be-87b6-03fb644d9a95", 2003, 3, 25, 18, 7, 13, 12, 16, 684, 684, "PEC Zwolle", 3 },
                    { "f806a0fa-56b6-445f-bce0-76d4bb5a8595", 2003, 5, 39, 27, 12, 24, 26, 13, 684, 684, "PEC Zwolle", 7 },
                    { "50d033e1-005a-45d8-9a71-da78a11ae5cc", 2003, 2, 19, 23, 5, 13, 20, 4, 682, 682, "AZ", 6 },
                    { "2c6bcb5b-2d49-4d10-89a2-03d975f15aa9", 2003, 3, 11, 28, 2, 12, 24, 5, 682, 682, "AZ", 7 },
                    { "6dd86e8d-25af-4d68-ace4-9ee0ffc83c00", 2003, 5, 30, 51, 7, 25, 44, 4, 682, 682, "AZ", 13 },
                    { "0f3c2ae8-4945-4eca-825c-eca171a7cd53", 2003, 2, 38, 7, 11, 13, 2, 18, 681, 681, "NAC Breda", 0 },
                    { "13ac9007-01be-4082-a27a-2ae268812ef4", 2003, 3, 20, 16, 5, 12, 15, 13, 681, 681, "NAC Breda", 4 },
                    { "4e030efe-52d1-48ad-b209-e674a4bd807d", 2003, 9, 56, 56, 8, 25, 33, 8, 673, 673, "SC Heerenveen", 8 },
                    { "2709bf43-5073-45e5-914d-9d658d708595", 2003, 2, 27, 22, 6, 13, 17, 5, 672, 672, "Willem II Tilburg", 5 },
                    { "d2aa840d-0694-4e36-a5a6-96ff0eca34b4", 2003, 2, 21, 18, 6, 12, 14, 15, 672, 672, "Willem II Tilburg", 4 },
                    { "abcb26e8-a353-41a0-8d4b-1da5fea1f878", 2003, 4, 48, 40, 12, 25, 31, 11, 672, 672, "Willem II Tilburg", 9 },
                    { "9bc37793-3204-4240-8d10-6c8e7b520f70", 2002, 0, 14, 26, 3, 12, 27, 3, 18, 18, "Borussia Mönchengladbach", 9 },
                    { "90981dba-f31e-467a-ad4b-60e6b541c669", 2002, 4, 30, 44, 7, 25, 46, 4, 18, 18, "Borussia Mönchengladbach", 14 },
                    { "4d583b69-8408-49df-beab-21cf14f38755", 2002, 4, 21, 11, 6, 12, 10, 14, 17, 17, "SC Freiburg", 2 },
                    { "5250a811-3668-4e10-9d83-ee9734ddbf47", 2002, 5, 20, 25, 3, 13, 20, 9, 17, 17, "SC Freiburg", 5 },
                    { "8c8338f4-d3ff-4b06-ab5b-6cd0a85f16dc", 2002, 9, 41, 36, 9, 25, 30, 12, 17, 17, "SC Freiburg", 7 },
                    { "e77d8012-18cb-4209-aa45-20f76692d829", 2002, 3, 26, 13, 8, 13, 9, 15, 16, 16, "FC Augsburg", 2 },
                    { "fcf8af45-8f72-4c1a-9418-08f853bb3ebd", 2002, 4, 20, 21, 5, 12, 13, 15, 16, 16, "FC Augsburg", 3 },
                    { "40251ead-19fb-4cce-a9a2-661982de5640", 2002, 7, 46, 34, 13, 25, 22, 15, 16, 16, "FC Augsburg", 5 },
                    { "c4532cf6-1475-4156-85a3-cffc81501e1c", 2002, 2, 23, 11, 7, 12, 11, 12, 15, 15, "1. FSV Mainz 05", 3 },
                    { "8d14639e-a4e4-4936-94a4-0f25801b469f", 2002, 4, 16, 16, 4, 13, 19, 11, 15, 15, "1. FSV Mainz 05", 5 },
                    { "ee0c015f-0478-431d-8a33-8537055eb2e5", 2002, 6, 39, 27, 11, 25, 30, 13, 15, 15, "1. FSV Mainz 05", 8 },
                    { "dca22ec1-ec7a-42b4-ba40-f9e4051df7a3", 2002, 2, 35, 8, 10, 12, 2, 18, 14, 14, "1. FC Nürnberg", 0 },
                    { "72bdfcc4-a778-451f-b7a6-29701cf3c77b", 2002, 5, 16, 11, 6, 13, 11, 17, 14, 14, "1. FC Nürnberg", 2 },
                    { "0d4963b2-9699-430b-b57b-cbf6b9545957", 2002, 7, 51, 19, 16, 25, 13, 18, 14, 14, "1. FC Nürnberg", 2 },
                    { "4c213179-33d0-40bd-834f-fc002bb33af8", 2002, 4, 16, 17, 4, 12, 16, 9, 12, 12, "SV Werder Bremen", 4 },
                    { "b87a61e8-6ab2-4d21-a044-680ead4985f3", 2002, 4, 16, 18, 4, 13, 19, 7, 18, 18, "Borussia Mönchengladbach", 5 },
                    { "24fcbae0-2432-4d64-b03b-d55a0a16f059", 2002, 9, 37, 43, 7, 25, 36, 9, 12, 12, "SV Werder Bremen", 9 },
                    { "9c65c74d-5fb6-4276-8884-58a8da0d2bcc", 2002, 7, 30, 50, 6, 25, 43, 5, 19, 19, "Eintracht Frankfurt", 12 },
                    { "3f7ffcb5-2ce1-4658-be85-1ac1184d0d5b", 2002, 4, 14, 23, 3, 13, 22, 3, 19, 19, "Eintracht Frankfurt", 6 },
                    { "828aa3b7-cd50-48ba-b636-cfeaa6cbcca8", 2003, 3, 28, 14, 7, 13, 12, 13, 671, 671, "Heracles Almelo", 3 },
                    { "9330ac86-1740-4f83-a343-f705008d4afb", 2003, 0, 20, 29, 4, 12, 24, 6, 671, 671, "Heracles Almelo", 8 },
                    { "af56117b-16c4-464c-bc56-d88268171eb7", 2003, 3, 48, 43, 11, 25, 36, 7, 671, 671, "Heracles Almelo", 11 },
                    { "a3e2bf03-fe36-4af0-b5e2-5709e0aabf78", 2003, 2, 28, 11, 8, 12, 8, 15, 670, 670, "SBV Excelsior", 2 },
                    { "20ff690d-63af-4286-baf8-fc62811ac3ee", 2003, 3, 29, 21, 5, 13, 18, 11, 670, 670, "SBV Excelsior", 5 },
                    { "79988024-3f42-43c3-a503-6bee64251052", 2003, 5, 57, 32, 13, 25, 26, 15, 670, 670, "SBV Excelsior", 7 },
                    { "6a975d6c-06e6-4129-9e9a-aa7e7c29a974", 2003, 2, 32, 14, 8, 13, 11, 14, 668, 668, "VVV Venlo", 3 },
                    { "22d9493e-c271-41ce-8590-6e999869e8b3", 2003, 3, 11, 18, 3, 12, 21, 8, 668, 668, "VVV Venlo", 6 },
                    { "7db5b630-1063-4bf4-80a5-7c1ac359e29c", 2003, 5, 43, 32, 11, 25, 32, 10, 668, 668, "VVV Venlo", 9 },
                    { "7cc92d5d-10e1-4bbb-9c93-adc129688adf", 2002, 2, 12, 18, 4, 12, 20, 5, 721, 721, "RB Leipzig", 6 },
                    { "05a63281-222c-41bb-9a87-c335850bedeb", 2002, 5, 8, 25, 1, 13, 26, 4, 721, 721, "RB Leipzig", 7 },
                    { "328981e4-5c67-4afc-99d8-fc96c088fe4b", 2002, 7, 20, 43, 5, 25, 46, 3, 721, 721, "RB Leipzig", 13 },
                    { "622ca851-7cb3-48bf-bc8c-19e95b8ce519", 2002, 4, 24, 14, 5, 12, 13, 11, 24, 24, "TSV Fortuna 95 Düsseldorf", 3 },
                    { "531fec61-de9e-43c0-a4ab-dc4ce4c9c341", 2002, 0, 21, 17, 7, 13, 18, 12, 24, 24, "TSV Fortuna 95 Düsseldorf", 6 },
                    { "1063877d-a7f4-42da-a66f-89d64c08a169", 2002, 4, 45, 31, 12, 25, 31, 11, 24, 24, "TSV Fortuna 95 Düsseldorf", 9 },
                    { "12dcb913-bb0e-40b7-91e8-0760c8bb0dff", 2002, 3, 16, 27, 3, 12, 21, 6, 19, 19, "Eintracht Frankfurt", 6 },
                    { "af10e78c-450f-4960-ad8f-519c515142ae", 2001, 0, 4, 9, 2, 6, 12, 1, 109, 109, "Juventus FC", 4 },
                    { "e06593dc-3aaf-4b78-afb6-3c0f6ce10dde", 2001, 0, 4, 2, 2, 3, 3, 2, 108, 108, "FC Internazionale Milano", 1 },
                    { "31748ae5-ee3e-4483-b17f-3b274a99641d", 2001, 2, 3, 4, 0, 3, 5, 3, 108, 108, "FC Internazionale Milano", 1 },
                    { "6eeb6b77-47b6-4e2c-869a-1dcf6f64de30", 2000, 0, 0, 0, 0, 0, 0, 2, 793, 793, "Costa Rica", 0 },
                    { "a4c04335-d03a-4a02-a5b4-34f643ae0fa7", 2000, 1, 5, 2, 2, 3, 1, 4, 793, 793, "Costa Rica", 0 },
                    { "fc4133b1-1af9-4c45-abdf-b0309b6324dd", 2000, 0, 0, 0, 0, 0, 0, 4, 792, 792, "Sweden", 0 },
                    { "9f2e1813-af33-4aaf-b1b1-90dac5166b50", 2000, 0, 0, 0, 0, 0, 0, 4, 792, 792, "Sweden", 0 },
                    { "69ae201e-8c2d-461b-8b2d-49610969573f", 2000, 0, 2, 5, 1, 3, 6, 1, 792, 792, "Sweden", 2 },
                    { "f3d9bbb2-fbff-4e6c-9152-6b1de2d4a8da", 2000, 0, 0, 0, 0, 0, 0, 4, 788, 788, "Switzerland", 0 },
                    { "9e95ebbd-2fa4-4645-b76c-f6dcf164fc14", 2000, 0, 0, 0, 0, 0, 0, 2, 793, 793, "Costa Rica", 0 },
                    { "48edbef3-8f60-4119-8f50-e74f981a249e", 2000, 0, 0, 0, 0, 0, 0, 4, 788, 788, "Switzerland", 0 },
                    { "e6097837-8771-4548-b430-8ec884356b15", 2000, 0, 0, 0, 0, 0, 0, 2, 782, 782, "Denmark", 0 },
                    { "82e5f0a8-e228-46c3-b295-67d730d65679", 2000, 0, 0, 0, 0, 0, 0, 2, 782, 782, "Denmark", 0 }
                });

            migrationBuilder.InsertData(
                table: "LeagueTables",
                columns: new[] { "Id", "Code", "Draw", "GoalsAgainst", "GoalsFor", "Lost", "PlayedGames", "Points", "Position", "TeamCode", "TeamId", "TeamName", "Won" },
                values: new object[,]
                {
                    { "bd90e84a-9531-4d54-bad2-5bbe897ac4c9", 2000, 2, 1, 2, 0, 3, 5, 2, 782, 782, "Denmark", 1 },
                    { "7393250b-66d9-4302-a027-6cfd9e70cfc5", 2000, 0, 0, 0, 0, 0, 0, 3, 780, 780, "Serbia", 0 },
                    { "a08b2a75-211a-4c9a-a862-367203bd9d37", 2000, 0, 0, 0, 0, 0, 0, 3, 780, 780, "Serbia", 0 },
                    { "f95bf1a1-a567-476c-a1fe-5a067efb321b", 2000, 0, 4, 2, 2, 3, 3, 3, 780, 780, "Serbia", 1 },
                    { "f5c1d547-c557-4e53-83c9-259b6a5cb0f9", 2000, 2, 4, 5, 0, 3, 5, 2, 788, 788, "Switzerland", 1 },
                    { "bf701296-fde3-48a6-867e-7156be69dd17", 2000, 0, 5, 2, 2, 3, 3, 4, 794, 794, "Poland", 1 },
                    { "7b03938d-a49f-4d30-b21c-f908b65e5941", 2000, 0, 0, 0, 0, 0, 0, 3, 794, 794, "Poland", 0 },
                    { "acfe87ab-97fe-4aa1-b73e-d1575b4a7843", 2000, 0, 0, 0, 0, 0, 0, 3, 794, 794, "Poland", 0 },
                    { "487fa402-3e04-470d-8e69-f5c21474d865", 2000, 0, 0, 0, 0, 0, 0, 1, 805, 805, "Belgium", 0 },
                    { "cd68381f-8eb6-4341-a78d-75c9e5f946e0", 2000, 0, 0, 0, 0, 0, 0, 1, 805, 805, "Belgium", 0 },
                    { "dd863a14-1235-4b40-9d21-a062d3ad05c2", 2000, 0, 2, 9, 0, 3, 9, 1, 805, 805, "Belgium", 3 },
                    { "87db552b-45a2-46db-9e51-2b65a79f351c", 2000, 0, 0, 0, 0, 0, 0, 4, 804, 804, "Senegal", 0 },
                    { "94337f57-91ac-4d92-9101-d6c2d2c3193d", 2000, 0, 0, 0, 0, 0, 0, 4, 804, 804, "Senegal", 0 },
                    { "8e6e61bd-f0bc-4c58-8c8d-e708c357c3b3", 2000, 1, 4, 4, 1, 3, 4, 3, 804, 804, "Senegal", 1 },
                    { "a0fbf7bf-c136-410f-97ea-5ea42aea8c51", 2000, 0, 0, 0, 0, 0, 0, 3, 802, 802, "Tunisia", 0 },
                    { "b99f27a4-875a-45d9-83fa-fb91b8aa04fb", 2000, 0, 0, 0, 0, 0, 0, 3, 802, 802, "Tunisia", 0 },
                    { "d4a7a1d5-8b52-4b92-a5b4-b9a8c5b06fd7", 2000, 0, 8, 5, 2, 3, 3, 3, 802, 802, "Tunisia", 1 },
                    { "c31b5215-785e-4238-9f7c-cfa19ce161a2", 2000, 0, 0, 0, 0, 0, 0, 3, 801, 801, "Saudi Arabia", 0 },
                    { "008792a6-6ee3-435b-a3de-143aa71393d2", 2000, 0, 0, 0, 0, 0, 0, 3, 801, 801, "Saudi Arabia", 0 },
                    { "149482aa-32a5-46f1-8509-0e8edbea8b4f", 2000, 0, 7, 2, 2, 3, 3, 3, 801, 801, "Saudi Arabia", 1 },
                    { "d19c6f8b-2bbd-4caa-a24d-f5a5284ef3d5", 2000, 0, 0, 0, 0, 0, 0, 2, 799, 799, "Croatia", 0 },
                    { "eebe512f-4c31-400b-986a-0e7d30aa59e4", 2000, 0, 0, 0, 0, 0, 0, 2, 799, 799, "Croatia", 0 },
                    { "3db79ab2-f25a-4985-92c4-aeeafb6fbb09", 2000, 0, 1, 7, 0, 3, 9, 1, 799, 799, "Croatia", 3 },
                    { "68e7699b-6c0d-420a-9f5a-5df7d0a5b477", 2000, 0, 0, 0, 0, 0, 0, 1, 779, 779, "Australia", 0 },
                    { "a532be46-5395-470b-8e9a-fb11fa5e11de", 2000, 0, 0, 0, 0, 0, 0, 1, 779, 779, "Australia", 0 },
                    { "4a42f57f-4491-4480-936d-bd090d930b39", 2000, 1, 5, 2, 2, 3, 1, 4, 779, 779, "Australia", 0 },
                    { "4de2c439-b989-45b8-96be-b254833e013f", 2000, 0, 0, 0, 0, 0, 0, 3, 776, 776, "Nigeria", 0 },
                    { "68908069-3e92-409b-9d25-640fdf2dc908", 2000, 2, 4, 5, 0, 3, 5, 2, 765, 765, "Portugal", 1 },
                    { "4f3c61bc-cc57-4861-8c05-6a9fd77957a5", 2000, 0, 0, 0, 0, 0, 0, 1, 764, 764, "Brazil", 0 },
                    { "6b1d0282-0dba-4e94-9c73-84767fa4e35f", 2000, 0, 0, 0, 0, 0, 0, 1, 764, 764, "Brazil", 0 },
                    { "e860b7b8-b2b2-4bbb-a28d-585ec6b6d397", 2000, 1, 1, 5, 0, 3, 7, 1, 764, 764, "Brazil", 2 },
                    { "9d54f35c-4698-4836-8035-0ff748a8d558", 2000, 0, 0, 0, 0, 0, 0, 1, 762, 762, "Argentina", 0 },
                    { "6a5f3b44-9b43-498a-bf01-54ca3c986739", 2000, 0, 0, 0, 0, 0, 0, 1, 762, 762, "Argentina", 0 },
                    { "551e073b-f937-4da0-8a6e-c39f983bd786", 2000, 1, 5, 3, 1, 3, 4, 2, 762, 762, "Argentina", 1 },
                    { "2a9fb39d-c39f-43f4-84cf-441a423d40bd", 2000, 0, 0, 0, 0, 0, 0, 4, 760, 760, "Spain", 0 },
                    { "ce2fdbbe-fb02-4de9-8600-6b4e4a439dc2", 2000, 0, 0, 0, 0, 0, 0, 4, 760, 760, "Spain", 0 },
                    { "08a8aa1f-1841-4b00-9608-b7e56048efa5", 2000, 2, 5, 6, 0, 3, 5, 1, 760, 760, "Spain", 1 },
                    { "88c36308-8d73-49f3-801f-0df4c14a76eb", 2000, 0, 0, 0, 0, 0, 0, 1, 759, 759, "Germany", 0 },
                    { "d9633226-1c6f-4a6d-a839-5b702d7ea77e", 2000, 0, 0, 0, 0, 0, 0, 1, 759, 759, "Germany", 0 },
                    { "a4cfe8dd-d0a0-4aa1-af00-29e11c658d7f", 2000, 0, 4, 2, 2, 3, 3, 4, 759, 759, "Germany", 1 },
                    { "d013c335-ffab-4c22-9080-11a162782054", 2000, 0, 0, 0, 0, 0, 0, 4, 758, 758, "Uruguay", 0 },
                    { "1dd727fb-be0b-4464-a3cb-348908d855d1", 2000, 0, 0, 0, 0, 0, 0, 4, 758, 758, "Uruguay", 0 },
                    { "5bb74649-5722-404b-a667-7d6ff37c7220", 2000, 0, 0, 0, 0, 0, 0, 3, 765, 765, "Portugal", 0 },
                    { "e00857b9-5f2a-4ddf-a0d2-5d450738b4c0", 2000, 0, 4, 8, 1, 3, 6, 2, 808, 808, "Russia", 2 },
                    { "5a1cea0d-8cff-4593-982d-c4664981a2d2", 2000, 0, 0, 0, 0, 0, 0, 3, 765, 765, "Portugal", 0 },
                    { "45de7b58-4a2b-4412-8b3a-0bfdb462143d", 2000, 0, 0, 0, 0, 0, 0, 2, 766, 766, "Japan", 0 },
                    { "b747b238-ee91-4f3e-8f41-6416de507c27", 2000, 0, 0, 0, 0, 0, 0, 3, 776, 776, "Nigeria", 0 },
                    { "bf89d484-7a51-4167-b161-21cf7508f686", 2000, 0, 4, 3, 2, 3, 3, 3, 776, 776, "Nigeria", 1 },
                    { "abff12db-4299-4df0-8594-ef13720f02ea", 2000, 0, 0, 0, 0, 0, 0, 3, 773, 773, "France", 0 },
                    { "b121bdfc-6958-4e9f-8468-1a6df27628d3", 2000, 0, 0, 0, 0, 0, 0, 3, 773, 773, "France", 0 },
                    { "da28aa90-e116-407e-b14a-73bcc4aa4f91", 2000, 1, 1, 3, 0, 3, 7, 1, 773, 773, "France", 2 },
                    { "0434caa9-fc78-4816-97ed-49609d1dd308", 2000, 0, 0, 0, 0, 0, 0, 2, 772, 772, "Korea Republic", 0 },
                    { "50165700-dd0a-4d34-89b0-e8bfd8c2b6df", 2000, 0, 0, 0, 0, 0, 0, 2, 772, 772, "Korea Republic", 0 },
                    { "5649fe25-572e-40fe-a838-2c5e60102dfc", 2000, 0, 3, 3, 2, 3, 3, 3, 772, 772, "Korea Republic", 1 },
                    { "bb9348a0-f7eb-4b66-be99-6ac2f3cb3de8", 2000, 0, 0, 0, 0, 0, 0, 2, 770, 770, "England", 0 },
                    { "daf9e684-5c24-46ef-bdcf-dbab3c1a190f", 2000, 0, 0, 0, 0, 0, 0, 2, 770, 770, "England", 0 },
                    { "23d5e53f-c593-4a52-a8f7-f02c86ef28f2", 2000, 0, 3, 8, 1, 3, 6, 2, 770, 770, "England", 2 },
                    { "60628457-46c3-41d7-9735-8246c8c9ef2c", 2000, 0, 0, 0, 0, 0, 0, 3, 769, 769, "Mexico", 0 },
                    { "d6bd5aba-e4a7-4852-9f44-3501181df75c", 2000, 0, 0, 0, 0, 0, 0, 3, 769, 769, "Mexico", 0 },
                    { "f58098ef-47c2-4b18-ae16-88e3ba23548f", 2000, 0, 4, 3, 1, 3, 6, 2, 769, 769, "Mexico", 2 },
                    { "edd30c53-7eda-4395-9d73-7762af459642", 2000, 0, 0, 0, 0, 0, 0, 2, 766, 766, "Japan", 0 },
                    { "9be879ce-7196-4d18-8231-697e9a6da3a4", 2000, 1, 4, 4, 1, 3, 4, 2, 766, 766, "Japan", 1 },
                    { "3170356f-8ea6-4740-a3de-db761800dcfe", 2000, 0, 0, 0, 0, 0, 0, 2, 808, 808, "Russia", 0 },
                    { "4b26e7a7-0844-425a-85a1-6270b7a29f1a", 2000, 0, 0, 0, 0, 0, 0, 2, 808, 808, "Russia", 0 },
                    { "b1a94ade-9675-4197-ad4e-770986f7a20d", 2000, 1, 4, 2, 2, 3, 1, 4, 815, 815, "Morocco", 0 },
                    { "83b02910-f26a-469f-b585-2d05c90fe785", 2001, 0, 3, 6, 1, 3, 6, 1, 66, 66, "Manchester United FC", 2 },
                    { "2bee8f24-2f74-48fa-8130-1b7821cad44f", 2001, 1, 1, 1, 1, 3, 4, 3, 66, 66, "Manchester United FC", 1 },
                    { "39992b47-4386-4fda-840f-075fcbe6d5c7", 2001, 1, 4, 7, 2, 6, 10, 2, 66, 66, "Manchester United FC", 3 },
                    { "9ac303d4-9228-4d67-8448-8b9f930536a7", 2001, 1, 3, 7, 0, 3, 7, 1, 65, 65, "Manchester City FC", 2 },
                    { "d91f2148-d84c-4801-8cf1-e98f0b7a9897", 2001, 0, 3, 9, 1, 3, 6, 1, 65, 65, "Manchester City FC", 2 },
                    { "b0be3cb1-1414-48bb-a770-6b9b8cd0a726", 2001, 1, 6, 16, 1, 6, 13, 1, 65, 65, "Manchester City FC", 4 },
                    { "44a719ad-da2e-4e33-8b35-65a32a45d6c8", 2001, 0, 5, 1, 3, 3, 0, 3, 64, 64, "Liverpool FC", 0 },
                    { "9e395ec2-eee0-4334-9ad0-57db75fddf14", 2001, 0, 2, 8, 0, 3, 9, 1, 64, 64, "Liverpool FC", 3 },
                    { "8d7489f4-2172-413e-8daf-c0596cbd3b0c", 2001, 0, 7, 9, 3, 6, 9, 2, 64, 64, "Liverpool FC", 3 },
                    { "18684d10-acf9-4449-b643-47fcb052c211", 2002, 4, 23, 14, 7, 13, 10, 13, 6, 6, "FC Schalke 04", 2 },
                    { "750e79c8-c133-46b4-ad1b-ac83ee180fdd", 2002, 1, 20, 13, 7, 12, 13, 16, 6, 6, "FC Schalke 04", 4 },
                    { "df573d68-1acf-47a6-8aad-7e646a34328a", 2002, 5, 43, 27, 14, 25, 23, 14, 6, 6, "FC Schalke 04", 6 },
                    { "49efc8e9-ccdb-4681-9910-b0ba33dbf351", 2001, 1, 3, 2, 1, 3, 4, 2, 6, 6, "FC Schalke 04", 1 },
                    { "cfaa2f8b-e1f7-41b5-9d94-1f5fde706152", 2001, 1, 1, 4, 0, 3, 7, 2, 6, 6, "FC Schalke 04", 2 },
                    { "a156ba75-4dd4-4e4c-bcca-466927e4dfb7", 2001, 2, 4, 6, 1, 6, 11, 2, 6, 6, "FC Schalke 04", 3 },
                    { "2dd6e3d5-9c43-47b7-bcd2-dda43fb9efde", 2001, 2, 10, 9, 2, 6, 8, 2, 73, 73, "Tottenham Hotspur FC", 2 },
                    { "385f04af-15d6-4514-9354-6bc285531905", 2002, 0, 15, 33, 3, 13, 30, 1, 5, 5, "FC Bayern München", 10 },
                    { "fdcb4a72-10fb-4f35-92d5-e8a2549d7fa1", 2001, 0, 5, 5, 1, 3, 6, 2, 73, 73, "Tottenham Hotspur FC", 2 },
                    { "46b1c396-bfca-43d4-8796-31942ccaf60c", 2001, 1, 6, 9, 1, 6, 13, 2, 78, 78, "Club Atlético de Madrid", 4 },
                    { "3b0579e9-d26a-4379-8e1e-15e8e8c586a7", 2001, 2, 7, 6, 2, 6, 8, 3, 108, 108, "FC Internazionale Milano", 2 },
                    { "be4450b1-d788-40ea-9456-11b7a5135d08", 2001, 0, 6, 3, 2, 3, 3, 3, 100, 100, "AS Roma", 1 },
                    { "62e55e16-9e69-4966-aefa-e0b6fbfa2b31", 2001, 0, 2, 8, 1, 3, 6, 1, 100, 100, "AS Roma", 2 },
                    { "5663555e-ff67-4fba-ad3e-12b55fd483b1", 2001, 0, 8, 11, 3, 6, 9, 2, 100, 100, "AS Roma", 3 },
                    { "01ea72ac-d1c3-4ec4-9326-347cdf3250be", 2001, 2, 2, 1, 1, 3, 2, 3, 95, 95, "Valencia CF", 0 },
                    { "03591876-f6c0-4bb9-a9d1-57fa4102b9c8", 2001, 0, 4, 5, 1, 3, 6, 2, 95, 95, "Valencia CF", 2 },
                    { "cb63baee-d2fa-48b5-abca-38da05b56904", 2001, 2, 6, 6, 2, 6, 8, 3, 95, 95, "Valencia CF", 2 },
                    { "b5e0b32f-8d8c-49de-84b0-f61fc4ff6edf", 2001, 0, 1, 7, 1, 3, 6, 1, 86, 86, "Real Madrid CF", 2 },
                    { "109f9156-2060-4b52-b24a-726407b1ce0d", 2001, 0, 4, 5, 1, 3, 6, 2, 86, 86, "Real Madrid CF", 2 },
                    { "af2e77b3-5da7-49fe-9208-13ed4dba1532", 2001, 0, 5, 12, 2, 6, 12, 1, 86, 86, "Real Madrid CF", 4 },
                    { "55ab2551-391a-4dab-827d-7d9ecba0a416", 2001, 1, 4, 7, 0, 3, 7, 1, 81, 81, "FC Barcelona", 2 },
                    { "680c8584-ef22-4a94-8294-7619bf8e49a4", 2001, 1, 1, 7, 0, 3, 7, 1, 81, 81, "FC Barcelona", 2 },
                    { "e6198497-4d18-40b1-b684-b06ea04df87b", 2001, 2, 5, 14, 0, 6, 14, 1, 81, 81, "FC Barcelona", 4 },
                    { "c397fd6e-4014-4039-b08b-4a02d19e4912", 2001, 1, 5, 2, 1, 3, 4, 3, 78, 78, "Club Atlético de Madrid", 1 },
                    { "10b1e114-4bd6-41eb-85b0-1b48b547304d", 2001, 0, 1, 7, 0, 3, 9, 1, 78, 78, "Club Atlético de Madrid", 3 },
                    { "301de006-8554-4885-a590-9ddb4fa91960", 2001, 2, 5, 4, 1, 3, 2, 3, 73, 73, "Tottenham Hotspur FC", 0 },
                    { "d37b5a38-641d-4310-b524-76e49792fd56", 2003, 3, 19, 23, 4, 12, 18, 10, 1920, 1920, "Fortuna Sittard", 5 },
                    { "042b8a28-d37a-4797-8d96-6c3dc8646892", 2002, 3, 12, 29, 1, 12, 27, 2, 5, 5, "FC Bayern München", 8 },
                    { "324b477f-53a2-49ab-8e37-9ac75b3a49a1", 2001, 1, 3, 7, 0, 3, 7, 1, 5, 5, "FC Bayern München", 2 },
                    { "2a986400-a90c-4b8d-b4ec-c5fdc285c30a", 2000, 1, 5, 2, 2, 3, 1, 4, 1066, 1066, "Iceland", 0 },
                    { "a285f186-f9eb-42a4-8813-61a1374fd772", 2000, 0, 0, 0, 0, 0, 0, 1, 840, 840, "Iran", 0 },
                    { "69e5b81c-6d67-4ec1-a807-a0f996bd59ca", 2000, 0, 0, 0, 0, 0, 0, 1, 840, 840, "Iran", 0 },
                    { "224ef6d5-ab33-4c87-b519-7b1c292dd09f", 2000, 1, 2, 2, 1, 3, 4, 3, 840, 840, "Iran", 1 },
                    { "306521fb-246a-412e-a33b-f81ea6942dac", 2000, 0, 0, 0, 0, 0, 0, 4, 832, 832, "Peru", 0 },
                    { "a2a14462-0774-4c72-89ca-864b9792758f", 2000, 0, 0, 0, 0, 0, 0, 4, 832, 832, "Peru", 0 },
                    { "c8b97f41-91d6-4508-b392-491e5cd3f08f", 2000, 0, 2, 2, 2, 3, 3, 3, 832, 832, "Peru", 1 },
                    { "b0f0cf0a-1f2b-42b7-bfac-d7ac77299e2f", 2000, 0, 0, 0, 0, 0, 0, 1, 825, 825, "Egypt", 0 },
                    { "7f16004c-4aa9-42fa-ba70-c2a3d2ea76b8", 2000, 0, 0, 0, 0, 0, 0, 1, 825, 825, "Egypt", 0 },
                    { "8e670629-ea4b-43b3-85d9-3837957754d8", 2000, 0, 6, 2, 3, 3, 0, 4, 825, 825, "Egypt", 0 },
                    { "9c7a071a-d6ab-4455-866d-220ab249ace2", 2000, 0, 0, 0, 0, 0, 0, 1, 818, 818, "Colombia", 0 },
                    { "fc0f0378-a069-42d7-8533-284b30ab1953", 2000, 0, 0, 0, 0, 0, 0, 1, 818, 818, "Colombia", 0 },
                    { "2f0ad571-f8bf-433b-8d3a-de134cccfec3", 2000, 0, 2, 5, 1, 3, 6, 1, 818, 818, "Colombia", 2 },
                    { "9b811398-cbf5-4a72-84e1-17f7bd90bae6", 2000, 0, 0, 0, 0, 0, 0, 2, 815, 815, "Morocco", 0 },
                    { "159bcff5-4aad-4e7b-8c96-c2a6f872adf4", 2000, 0, 0, 0, 0, 0, 0, 2, 815, 815, "Morocco", 0 },
                    { "e0076e8b-3ea5-44a3-84e4-d826d9d7196e", 2000, 0, 0, 0, 0, 0, 0, 4, 1066, 1066, "Iceland", 0 },
                    { "913130fd-3ec1-40b1-8d4d-382c5c44ab6c", 2002, 3, 27, 62, 4, 25, 57, 1, 5, 5, "FC Bayern München", 18 },
                    { "8c961a1a-d205-47a1-bf9d-a0c0c7d7162f", 2000, 0, 0, 0, 0, 0, 0, 4, 1066, 1066, "Iceland", 0 },
                    { "c7fe9bdb-f298-45f3-a831-151313085128", 2000, 0, 0, 0, 0, 0, 0, 4, 1836, 1836, "Panama", 0 },
                    { "3db74738-e652-4231-b0ed-02d18565df83", 2001, 1, 2, 8, 0, 3, 7, 1, 5, 5, "FC Bayern München", 2 },
                    { "14efff6f-c877-434a-8758-28c0d55323f4", 2001, 2, 5, 15, 0, 6, 14, 1, 5, 5, "FC Bayern München", 4 },
                    { "8dc7d8c7-cfd7-4045-aff0-d5b76e11ed6d", 2002, 4, 10, 18, 2, 12, 22, 4, 4, 4, "BV Borussia 09 Dortmund", 6 },
                    { "7f92b50d-cf61-4e75-8c58-1612085cc5bf", 2002, 2, 18, 43, 0, 13, 35, 1, 4, 4, "BV Borussia 09 Dortmund", 11 },
                    { "ebf9919d-7b5a-460f-b9bd-f052d316ee4d", 2002, 6, 28, 61, 2, 25, 57, 2, 4, 4, "BV Borussia 09 Dortmund", 17 },
                    { "641e3c31-f89b-40fb-8417-edd066eabf37", 2001, 0, 2, 3, 1, 3, 6, 1, 4, 4, "BV Borussia 09 Dortmund", 2 },
                    { "8b47062a-5d35-45ad-8a71-3935cccc9389", 2001, 1, 0, 7, 0, 3, 7, 2, 4, 4, "BV Borussia 09 Dortmund", 2 },
                    { "c63ce584-a3da-4ed2-9643-7336012ee896", 2001, 1, 2, 10, 1, 6, 13, 1, 4, 4, "BV Borussia 09 Dortmund", 4 },
                    { "54adc5f6-4854-4bae-8a38-91b61e64f424", 2002, 5, 23, 28, 3, 12, 17, 8, 2, 2, "TSG 1899 Hoffenheim", 4 },
                    { "d11fa1b4-34ce-443e-ae15-79afe04b96cd", 2002, 5, 14, 21, 3, 13, 20, 7, 2, 2, "TSG 1899 Hoffenheim", 5 },
                    { "31f75838-b114-4cf7-9093-9dcdd2cea357", 2002, 10, 37, 49, 6, 25, 37, 8, 2, 2, "TSG 1899 Hoffenheim", 9 },
                    { "069745fa-91a8-441f-8bbe-df078cc87d9d", 2001, 2, 6, 5, 1, 3, 2, 4, 2, 2, "TSG 1899 Hoffenheim", 0 },
                    { "fa007b97-fbfc-4892-b4fa-8db8449914f5", 2001, 1, 8, 6, 2, 3, 1, 4, 2, 2, "TSG 1899 Hoffenheim", 0 },
                    { "b7b5642b-8cbc-4547-8350-a62dc436e348", 2001, 3, 14, 11, 3, 6, 3, 4, 2, 2, "TSG 1899 Hoffenheim", 0 },
                    { "b22ab10d-c0c2-4bd7-a30f-0367372ba201", 2000, 0, 0, 0, 0, 0, 0, 4, 1836, 1836, "Panama", 0 },
                    { "13ca0c5b-4b33-4f76-a121-c24975a585db", 2000, 0, 11, 2, 3, 3, 0, 4, 1836, 1836, "Panama", 0 },
                    { "0654a8c8-09b0-4da8-b944-2e006764aee6", 2003, 2, 41, 17, 9, 13, 8, 16, 1920, 1920, "Fortuna Sittard", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FanClubs_TeamId",
                table: "FanClubs",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTeams_TeamId",
                table: "FavoriteTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTables_TeamId",
                table: "LeagueTables",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFanClubs_FanClubId",
                table: "UsersFanClubs",
                column: "FanClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavoriteTeams");

            migrationBuilder.DropTable(
                name: "LeagueTables");

            migrationBuilder.DropTable(
                name: "UsersFanClubs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FanClubs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
