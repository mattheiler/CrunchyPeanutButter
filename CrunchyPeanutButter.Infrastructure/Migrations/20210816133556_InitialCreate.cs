using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrunchyPeanutButter.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ack",
                columns: table => new
                {
                    BarId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ack", x => x.BarId);
                    table.ForeignKey(
                        name: "FK_Ack_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    FooId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baz_Foos_FooId",
                        column: x => x.FooId,
                        principalTable: "Foos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FooBar",
                columns: table => new
                {
                    FooId = table.Column<Guid>(nullable: false),
                    BarId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooBar", x => new { x.FooId, x.BarId });
                    table.ForeignKey(
                        name: "FK_FooBar_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FooBar_Foos_FooId",
                        column: x => x.FooId,
                        principalTable: "Foos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baz_FooId",
                table: "Baz",
                column: "FooId");

            migrationBuilder.CreateIndex(
                name: "IX_FooBar_BarId",
                table: "FooBar",
                column: "BarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ack");

            migrationBuilder.DropTable(
                name: "Baz");

            migrationBuilder.DropTable(
                name: "FooBar");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Foos");
        }
    }
}
