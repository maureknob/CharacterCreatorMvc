using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CharacterCreatorMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharactersTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HealthPoints = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_CharactersTypes_CharacterTypeId",
                        column: x => x.CharacterTypeId,
                        principalTable: "CharactersTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CharactersTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2dd2e18b-ddc7-4132-a859-d722a04d755c"), "Barbarian" },
                    { new Guid("9dd0fb19-336c-4b4a-ba1f-9ed2637b3175"), "Sorcerer" },
                    { new Guid("c4ffa9fd-11f0-47cd-84b5-1af2302b8451"), "Mage" },
                    { new Guid("d70ed593-9d8c-4453-8fc3-df6221d152d7"), "Warrior" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterTypeId",
                table: "Characters",
                column: "CharacterTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "CharactersTypes");
        }
    }
}
