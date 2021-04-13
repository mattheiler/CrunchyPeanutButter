using Microsoft.EntityFrameworkCore.Migrations;

namespace CrunchyPeanutButter.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Bars",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Fum_Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Bars", x => x.Id); });

            migrationBuilder.CreateTable(
                "Foos",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Foos", x => x.Id); });

            migrationBuilder.CreateTable(
                "Ack",
                table => new
                {
                    BarId = table.Column<int>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ack", x => x.BarId);
                    table.ForeignKey(
                        "FK_Ack_Bars_BarId",
                        x => x.BarId,
                        "Bars",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Baz",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FooId = table.Column<int>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baz", x => x.Id);
                    table.ForeignKey(
                        "FK_Baz_Foos_FooId",
                        x => x.FooId,
                        "Foos",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "FooBar",
                table => new
                {
                    FooId = table.Column<int>(),
                    BarId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooBar", x => new {x.FooId, x.BarId});
                    table.ForeignKey(
                        "FK_FooBar_Bars_BarId",
                        x => x.BarId,
                        "Bars",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_FooBar_Foos_FooId",
                        x => x.FooId,
                        "Foos",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Qux",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BazId = table.Column<int>(),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qux", x => x.Id);
                    table.ForeignKey(
                        "FK_Qux_Baz_BazId",
                        x => x.BazId,
                        "Baz",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Baz_FooId",
                "Baz",
                "FooId");

            migrationBuilder.CreateIndex(
                "IX_FooBar_BarId",
                "FooBar",
                "BarId");

            migrationBuilder.CreateIndex(
                "IX_Qux_BazId",
                "Qux",
                "BazId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Ack");

            migrationBuilder.DropTable(
                "FooBar");

            migrationBuilder.DropTable(
                "Qux");

            migrationBuilder.DropTable(
                "Bars");

            migrationBuilder.DropTable(
                "Baz");

            migrationBuilder.DropTable(
                "Foos");
        }
    }
}