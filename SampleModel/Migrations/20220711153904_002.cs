using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleModel.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_groupinfos",
                columns: table => new
                {
                    groupid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    groupname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_groupinfos", x => x.groupid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_userinfos",
                columns: table => new
                {
                    userid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    groupid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_userinfos", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_viewinfos",
                columns: table => new
                {
                    viewid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    viewname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_viewinfos", x => x.viewid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_groupinfos");

            migrationBuilder.DropTable(
                name: "tbl_userinfos");

            migrationBuilder.DropTable(
                name: "tbl_viewinfos");
        }
    }
}
