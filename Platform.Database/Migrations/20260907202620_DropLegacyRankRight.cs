using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Database.Migrations
{
    /// <inheritdoc />
    public partial class DropLegacyRankRight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankRights");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Rights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Entitled = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Entitled = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Right", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRank = table.Column<int>(type: "int", nullable: false),
                    IdRight = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankRights_Ranks",
                        column: x => x.IdRank,
                        principalTable: "Ranks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RankRights_Rights",
                        column: x => x.IdRight,
                        principalTable: "Rights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RankRights_IdRank",
                table: "RankRights",
                column: "IdRank");

            migrationBuilder.CreateIndex(
                name: "IX_RankRights_IdRight",
                table: "RankRights",
                column: "IdRight");
        }
    }
}
