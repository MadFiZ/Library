using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Library.DAL.Migrations
{
    public partial class Library123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationHouseBooks");

            migrationBuilder.CreateTable(
                name: "PublicationHouseBook",
                columns: table => new
                {
                    PublicationHouseId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationHouseBook", x => new { x.PublicationHouseId, x.BookId });
                    table.ForeignKey(
                        name: "FK_PublicationHouseBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationHouseBook_PublicationHouses_PublicationHouseId",
                        column: x => x.PublicationHouseId,
                        principalTable: "PublicationHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationHouseBook_BookId",
                table: "PublicationHouseBook",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationHouseBook");

            migrationBuilder.CreateTable(
                name: "PublicationHouseBooks",
                columns: table => new
                {
                    PublicationHouseId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationHouseBooks", x => new { x.PublicationHouseId, x.BookId });
                    table.ForeignKey(
                        name: "FK_PublicationHouseBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationHouseBooks_PublicationHouses_PublicationHouseId",
                        column: x => x.PublicationHouseId,
                        principalTable: "PublicationHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationHouseBooks_BookId",
                table: "PublicationHouseBooks",
                column: "BookId");
        }
    }
}
