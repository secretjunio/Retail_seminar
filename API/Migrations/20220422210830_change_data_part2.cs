using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class change_data_part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "stock",
               table: "ProductLines",
               type: "int",
               nullable: true,
               oldClrType: typeof(string),
               oldType: "nvarchar(max)",
               oldNullable: true);
            migrationBuilder.AlterColumn<float>(
              name: "price",
              table: "ProductLines",
              type: "real",
              nullable: true,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)",
              oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "stock",
              table: "ProductLines",
              type: "string",
              nullable: true,
              oldClrType: typeof(int),
              oldType: "int",
              oldNullable: true);
            migrationBuilder.AlterColumn<string>(
             name: "price",
             table: "ProductLines",
             type: "nvarchar(max)",
             nullable: true,
             oldClrType: typeof(float),
             oldType: "real",
             oldNullable: true);
        }
    }
}
