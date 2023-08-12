using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acme.Bookstore.Migrations
{
    public partial class add_RelationBook_Author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        

        

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBooks_Authors_AuthorId",
                table: "AppBooks");

            migrationBuilder.DropIndex(
                name: "IX_AppBooks_AuthorId",
                table: "AppBooks");
        }
    }
}
