using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSCMasterGuide.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConsumable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    PP = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    NationalNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryType = table.Column<int>(type: "int", nullable: false),
                    SecondaryType = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    SpAttack = table.Column<int>(type: "int", nullable: false),
                    SpDefense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    PreEvolutionNationalNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.NationalNumber);
                    table.ForeignKey(
                        name: "FK_Pokemon_Pokemon_PreEvolutionNationalNumber",
                        column: x => x.PreEvolutionNationalNumber,
                        principalTable: "Pokemon",
                        principalColumn: "NationalNumber");
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PokemonNationalNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Happiness = table.Column<int>(type: "int", nullable: false),
                    IsShiny = table.Column<bool>(type: "bit", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    MoveSlot1Id = table.Column<int>(type: "int", nullable: true),
                    MoveSlot2Id = table.Column<int>(type: "int", nullable: true),
                    MoveSlot3Id = table.Column<int>(type: "int", nullable: true),
                    MoveSlot4Id = table.Column<int>(type: "int", nullable: true),
                    HPEV = table.Column<int>(type: "int", nullable: false),
                    AttackEV = table.Column<int>(type: "int", nullable: false),
                    DefenseEV = table.Column<int>(type: "int", nullable: false),
                    SpAttackEV = table.Column<int>(type: "int", nullable: false),
                    SpDefenseEV = table.Column<int>(type: "int", nullable: false),
                    SpeedEV = table.Column<int>(type: "int", nullable: false),
                    HPIV = table.Column<int>(type: "int", nullable: false),
                    AttackIV = table.Column<int>(type: "int", nullable: false),
                    DefenseIV = table.Column<int>(type: "int", nullable: false),
                    SpAttackIV = table.Column<int>(type: "int", nullable: false),
                    SpDefenseIV = table.Column<int>(type: "int", nullable: false),
                    SpeedIV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonMembers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonMembers_Moves_MoveSlot1Id",
                        column: x => x.MoveSlot1Id,
                        principalTable: "Moves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonMembers_Moves_MoveSlot2Id",
                        column: x => x.MoveSlot2Id,
                        principalTable: "Moves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonMembers_Moves_MoveSlot3Id",
                        column: x => x.MoveSlot3Id,
                        principalTable: "Moves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonMembers_Moves_MoveSlot4Id",
                        column: x => x.MoveSlot4Id,
                        principalTable: "Moves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonMembers_Pokemon_PokemonNationalNumber",
                        column: x => x.PokemonNationalNumber,
                        principalTable: "Pokemon",
                        principalColumn: "NationalNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonMoves",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "int", nullable: false),
                    PokemonNationalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonMoves", x => new { x.MoveId, x.PokemonNationalNumber });
                    table.ForeignKey(
                        name: "FK_PokemonMoves_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonMoves_Pokemon_PokemonNationalNumber",
                        column: x => x.PokemonNationalNumber,
                        principalTable: "Pokemon",
                        principalColumn: "NationalNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<long>(type: "bigint", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeadId = table.Column<long>(type: "bigint", nullable: true),
                    Member2Id = table.Column<long>(type: "bigint", nullable: true),
                    Member3Id = table.Column<long>(type: "bigint", nullable: true),
                    Member4Id = table.Column<long>(type: "bigint", nullable: true),
                    Member5Id = table.Column<long>(type: "bigint", nullable: true),
                    Member6Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonTeams_PokemonMembers_LeadId",
                        column: x => x.LeadId,
                        principalTable: "PokemonMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeams_PokemonMembers_Member2Id",
                        column: x => x.Member2Id,
                        principalTable: "PokemonMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeams_PokemonMembers_Member3Id",
                        column: x => x.Member3Id,
                        principalTable: "PokemonMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeams_PokemonMembers_Member4Id",
                        column: x => x.Member4Id,
                        principalTable: "PokemonMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeams_PokemonMembers_Member5Id",
                        column: x => x.Member5Id,
                        principalTable: "PokemonMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeams_PokemonMembers_Member6Id",
                        column: x => x.Member6Id,
                        principalTable: "PokemonMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonTeams_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PreEvolutionNationalNumber",
                table: "Pokemon",
                column: "PreEvolutionNationalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMembers_ItemId",
                table: "PokemonMembers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMembers_MoveSlot1Id",
                table: "PokemonMembers",
                column: "MoveSlot1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMembers_MoveSlot2Id",
                table: "PokemonMembers",
                column: "MoveSlot2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMembers_MoveSlot3Id",
                table: "PokemonMembers",
                column: "MoveSlot3Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMembers_MoveSlot4Id",
                table: "PokemonMembers",
                column: "MoveSlot4Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMembers_PokemonNationalNumber",
                table: "PokemonMembers",
                column: "PokemonNationalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonMoves_PokemonNationalNumber",
                table: "PokemonMoves",
                column: "PokemonNationalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_LeadId",
                table: "PokemonTeams",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_Member2Id",
                table: "PokemonTeams",
                column: "Member2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_Member3Id",
                table: "PokemonTeams",
                column: "Member3Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_Member4Id",
                table: "PokemonTeams",
                column: "Member4Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_Member5Id",
                table: "PokemonTeams",
                column: "Member5Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_Member6Id",
                table: "PokemonTeams",
                column: "Member6Id");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTeams_TrainerId",
                table: "PokemonTeams",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonMoves");

            migrationBuilder.DropTable(
                name: "PokemonTeams");

            migrationBuilder.DropTable(
                name: "PokemonMembers");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
