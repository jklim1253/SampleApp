using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleModel.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_group_view_relations",
                columns: table => new
                {
                    groupid = table.Column<int>(type: "INTEGER", nullable: false),
                    viewid = table.Column<int>(type: "INTEGER", nullable: false),
                    canread = table.Column<bool>(type: "INTEGER", nullable: false),
                    caninsert = table.Column<bool>(type: "INTEGER", nullable: false),
                    canupdate = table.Column<bool>(type: "INTEGER", nullable: false),
                    candelete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_group_view_relations", x => new { x.groupid, x.viewid });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_group_view_relations");
        }
    }
}
