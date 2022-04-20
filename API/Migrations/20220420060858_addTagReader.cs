using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addTagReader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tagReaders",
                columns: table => new
                {
                    TagUii = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagRssi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tagReaders", x => x.TagUii);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tagReaders");
        }
    }
}
