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
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateTable(
                name: "BeerUser",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BeerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerUser", x => new { x.BeerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BeerUser_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                table: "User",
                columns: new[] { "UserId", "Firstname", "Name" },
                values: new object[,]
                {
                    { 1, "Thibault", "D'Haese" },
                    { 2, "Robin", "Claeys" },
                    { 3, "Niels", "Onderbeke" }
                });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerId", "BitternessId", "BrewerId", "Name", "Origin", "Percentage" },
                values: new object[] { 1, 1, 1, "Stella Artois", "Leuven", "5.2" });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerId", "BitternessId", "BrewerId", "Name", "Origin", "Percentage" },
                values: new object[] { 3, 1, 1, "Heineken", "Amsterdam", "5" });

            migrationBuilder.InsertData(
                table: "Beer",
                columns: new[] { "BeerId", "BitternessId", "BrewerId", "Name", "Origin", "Percentage" },
                values: new object[] { 2, 2, 2, "Jupiler", "Jupille-sur-Meuse", "5.2" });

            migrationBuilder.InsertData(
                table: "BeerUser",
                columns: new[] { "BeerId", "UserId", "BeerUserId" },
                values: new object[] { 1, 1, new Guid("b5e82d11-a5f8-425d-b3c2-dda710fbdcbb") });

            migrationBuilder.InsertData(
                table: "BeerUser",
                columns: new[] { "BeerId", "UserId", "BeerUserId" },
                values: new object[] { 3, 1, new Guid("f7c22c1b-f740-45b3-b77d-5f884aae7f63") });

            migrationBuilder.InsertData(
                table: "BeerUser",
                columns: new[] { "BeerId", "UserId", "BeerUserId" },
                values: new object[] { 2, 1, new Guid("4cf44a0a-397d-4dcd-a556-cf7ca4fe7919") });

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BitternessId",
                table: "Beer",
                column: "BitternessId");

            migrationBuilder.CreateIndex(
                name: "IX_Beer_BrewerId",
                table: "Beer",
                column: "BrewerId");

            migrationBuilder.CreateIndex(
                name: "IX_BeerUser_UserId",
                table: "BeerUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerUser");

            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Bitterness");

            migrationBuilder.DropTable(
                name: "Brewer");
        }
    }
}
