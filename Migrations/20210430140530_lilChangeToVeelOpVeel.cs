using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBackend.Migrations
{
    public partial class lilChangeToVeelOpVeel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beer_Bitterness_BitternessId",
                table: "Beer");

            migrationBuilder.DropForeignKey(
                name: "FK_Beer_Brewer_BrewerId",
                table: "Beer");

            migrationBuilder.DropForeignKey(
                name: "FK_BeerUser_Beer_BeerId",
                table: "BeerUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BeerUser_User_UserId",
                table: "BeerUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brewer",
                table: "Brewer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bitterness",
                table: "Bitterness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerUser",
                table: "BeerUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beer",
                table: "Beer");

            migrationBuilder.DropColumn(
                name: "BeerUserId",
                table: "BeerUser");

            migrationBuilder.RenameTable(
                name: "Brewer",
                newName: "Brewers");

            migrationBuilder.RenameTable(
                name: "Bitterness",
                newName: "Bitternesss");

            migrationBuilder.RenameTable(
                name: "BeerUser",
                newName: "BeerUsers");

            migrationBuilder.RenameTable(
                name: "Beer",
                newName: "Beers");

            migrationBuilder.RenameIndex(
                name: "IX_BeerUser_UserId",
                table: "BeerUsers",
                newName: "IX_BeerUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Beer_BrewerId",
                table: "Beers",
                newName: "IX_Beers_BrewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Beer_BitternessId",
                table: "Beers",
                newName: "IX_Beers_BitternessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brewers",
                table: "Brewers",
                column: "BrewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bitternesss",
                table: "Bitternesss",
                column: "BitternessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerUsers",
                table: "BeerUsers",
                columns: new[] { "BeerId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beers",
                table: "Beers",
                column: "BeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Bitternesss_BitternessId",
                table: "Beers",
                column: "BitternessId",
                principalTable: "Bitternesss",
                principalColumn: "BitternessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "BrewerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeerUsers_Beers_BeerId",
                table: "BeerUsers",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "BeerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeerUsers_User_UserId",
                table: "BeerUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Bitternesss_BitternessId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_BeerUsers_Beers_BeerId",
                table: "BeerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BeerUsers_User_UserId",
                table: "BeerUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brewers",
                table: "Brewers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bitternesss",
                table: "Bitternesss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerUsers",
                table: "BeerUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beers",
                table: "Beers");

            migrationBuilder.RenameTable(
                name: "Brewers",
                newName: "Brewer");

            migrationBuilder.RenameTable(
                name: "Bitternesss",
                newName: "Bitterness");

            migrationBuilder.RenameTable(
                name: "BeerUsers",
                newName: "BeerUser");

            migrationBuilder.RenameTable(
                name: "Beers",
                newName: "Beer");

            migrationBuilder.RenameIndex(
                name: "IX_BeerUsers_UserId",
                table: "BeerUser",
                newName: "IX_BeerUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Beers_BrewerId",
                table: "Beer",
                newName: "IX_Beer_BrewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Beers_BitternessId",
                table: "Beer",
                newName: "IX_Beer_BitternessId");

            migrationBuilder.AddColumn<Guid>(
                name: "BeerUserId",
                table: "BeerUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brewer",
                table: "Brewer",
                column: "BrewerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bitterness",
                table: "Bitterness",
                column: "BitternessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerUser",
                table: "BeerUser",
                columns: new[] { "BeerId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beer",
                table: "Beer",
                column: "BeerId");

            migrationBuilder.UpdateData(
                table: "BeerUser",
                keyColumns: new[] { "BeerId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "BeerUserId",
                value: new Guid("b5e82d11-a5f8-425d-b3c2-dda710fbdcbb"));

            migrationBuilder.UpdateData(
                table: "BeerUser",
                keyColumns: new[] { "BeerId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "BeerUserId",
                value: new Guid("4cf44a0a-397d-4dcd-a556-cf7ca4fe7919"));

            migrationBuilder.UpdateData(
                table: "BeerUser",
                keyColumns: new[] { "BeerId", "UserId" },
                keyValues: new object[] { 3, 1 },
                column: "BeerUserId",
                value: new Guid("f7c22c1b-f740-45b3-b77d-5f884aae7f63"));

            migrationBuilder.AddForeignKey(
                name: "FK_Beer_Bitterness_BitternessId",
                table: "Beer",
                column: "BitternessId",
                principalTable: "Bitterness",
                principalColumn: "BitternessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beer_Brewer_BrewerId",
                table: "Beer",
                column: "BrewerId",
                principalTable: "Brewer",
                principalColumn: "BrewerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeerUser_Beer_BeerId",
                table: "BeerUser",
                column: "BeerId",
                principalTable: "Beer",
                principalColumn: "BeerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeerUser_User_UserId",
                table: "BeerUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
