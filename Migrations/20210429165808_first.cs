using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBackend.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitterness",
                columns: table => new
                {
                    BitternessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountIBU = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitterness", x => x.BitternessId);
                });

            migrationBuilder.CreateTable(
                name: "Brewer",
                columns: table => new
                {
                    BrewerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadOffice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewer", x => x.BrewerId);
                });

            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    BeerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BitternessId = table.Column<int>(type: "int", nullable: false),
                    BrewerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_Beer_Bitterness_BitternessId",
                        column: x => x.BitternessId,
                        principalTable: "Bitterness",
                        principalColumn: "BitternessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beer_Brewer_BrewerId",
                        column: x => x.BrewerId,
                        principalTable: "Brewer",
                        principalColumn: "BrewerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bitterness",
                columns: new[] { "BitternessId", "AmountIBU" },
                values: new object[,]
                {
                    { 1, 25 },
                    { 2, 20 }
                });

            migrationBuilder.InsertData(
                table: "Brewer",
                columns: new[] { "BrewerId", "HeadOffice", "Name" },
                values: new object[,]
                {
                    { 1, "Leuven", "AB InBev" },
                    { 2, "Luik", "Piedboeuf" }
                });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerId", "BitternessId", "BrewerId", "Name", "Origin", "Percentage" },
                values: new object[] { new Guid("a479f7b7-e969-4a5c-b4ff-eb09b934427e"), 1, 1, "Stella Artois", "Leuven", "5.2" });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerId", "BitternessId", "BrewerId", "Name", "Origin", "Percentage" },
                values: new object[] { new Guid("3c9c62b4-10c5-4fe2-b31e-efe4177d0ac1"), 1, 1, "Heineken", "Amsterdam", "5" });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerId", "BitternessId", "BrewerId", "Name", "Origin", "Percentage" },
                values: new object[] { new Guid("6f92eca8-e714-4e40-9fe0-9598b2e82b93"), 2, 2, "Jupiler", "Jupille-sur-Meuse", "5.2" });

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BitternessId",
                table: "Beer",
                column: "BitternessId");

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BrewerId",
                table: "Beer",
                column: "BrewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Bitterness");

            migrationBuilder.DropTable(
                name: "Brewer");
        }
    }
}
