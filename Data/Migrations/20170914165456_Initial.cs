using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BierTier.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ABV = table.Column<double>(nullable: false),
                    Brewery = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IBU = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                });

            migrationBuilder.CreateTable(
                name: "BlacklistBeer",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    IsBlacklisted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlacklistBeer", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_BlacklistBeer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBeer",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    IsFavorited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteBeer", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_FavoriteBeer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishlistBeer",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    IsWishlisted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistBeer", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_WishlistBeer_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlacklistBeer_ApplicationUserId",
                table: "BlacklistBeer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBeer_ApplicationUserId",
                table: "FavoriteBeer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistBeer_ApplicationUserId",
                table: "WishlistBeer",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "BlacklistBeer");

            migrationBuilder.DropTable(
                name: "FavoriteBeer");

            migrationBuilder.DropTable(
                name: "WishlistBeer");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
