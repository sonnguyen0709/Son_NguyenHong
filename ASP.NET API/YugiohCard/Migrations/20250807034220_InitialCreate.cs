using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YugiohCard.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonsterCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Race = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Link = table.Column<int>(type: "int", nullable: true),
                    ATK = table.Column<int>(type: "int", nullable: false),
                    DEF = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrapCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrapCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefeshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "MonsterCards",
                columns: new[] { "Id", "ATK", "DEF", "Effect", "ImageUrl", "Level", "Link", "Name", "Race", "Rank", "Type" },
                values: new object[,]
                {
                    { "BLC1-EN039", 2500, 2000, "2 Level 4 monsters \n When a monster declares an attack: You can detach 1 material from this card; negate the attack. If this card is targeted for an attack, while it has no material: Destroy this card.", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=9575", null, null, "Number 39: Utopia", 1, 4, 5 },
                    { "DUDE-EN022", 2600, 0, "2+ monsters", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=13090", null, 3, "Gaia Saber, the Lightning Shadow", 7, null, 6 },
                    { "RA04-EN001", 2500, 2100, "The ultimate wizard in terms of attack and defense.", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4041", 7, null, "Dark Magician", 2, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SpellCards",
                columns: new[] { "Id", "Effect", "ImageUrl", "Name", "Type" },
                values: new object[,]
                {
                    { "LOB-EN119", "Draw 2 cards.", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4844", "Pot of Greed", 0 },
                    { "MGED-EN047", "If your opponent controls more monsters than you do, your opponent cannot activate monster effects or declare an attack. If you control more monsters than your opponent does, you cannot activate monster effects or declare an attack. Once per turn, during the End Phase, if both players control the same number of monsters: Destroy this card.", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=14314", "Mystic Mine", 4 }
                });

            migrationBuilder.InsertData(
                table: "TrapCards",
                columns: new[] { "Id", "Effect", "ImageUrl", "Name", "Type" },
                values: new object[,]
                {
                    { "RA02-EN075", "When a monster(s) would be Summoned, OR a Spell/Trap Card is activated: Pay half your LP; negate the Summon or activation, and if you do, destroy that card.", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4861", "Solemn Judgment", 2 },
                    { "RA03-EN093", "When an opponent's monster declares an attack: Destroy all your opponent's Attack Position monsters.", "https://www.db.yugioh-card.com/yugiohdb/card_search.action?ope=2&cid=4887", "Mirror Force", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterCards");

            migrationBuilder.DropTable(
                name: "SpellCards");

            migrationBuilder.DropTable(
                name: "TrapCards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
