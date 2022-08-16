using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreServices.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SLUG = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    POST_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.POST_ID);
                    table.ForeignKey(
                        name: "FK__Post__CATEGORY_I__1273C1CD",
                        column: x => x.CATEGORY_ID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CATEGORY_ID",
                table: "Post",
                column: "CATEGORY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
