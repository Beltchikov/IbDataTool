using Microsoft.EntityFrameworkCore.Migrations;

namespace IbDataTool.Migrations
{
    public partial class NotResolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotResolved",
                columns: table => new
                {
                    Company = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotResolved", x => x.Company);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotResolved");
        }
    }
}
