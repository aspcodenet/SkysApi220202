using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkysApi220202.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ean13 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastBought = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PopularityPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
