using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO ProductLines
                               VALUES('1',N'Ti Vi Sony 32 INCH',1500000,0)");
            migrationBuilder.Sql(@"INSERT INTO ProductLines
                               VALUES('2',N'Honda Vision',1900000,0)");
            migrationBuilder.Sql(@"INSERT INTO ProductLines
                               VALUES('3',N'Moto Phân Khối lớn',3500000,0)");
            migrationBuilder.Sql(@"INSERT INTO ProductLines
                               VALUES('4',N'Máy Lạnh RSSA',1500000,0)");
            migrationBuilder.Sql(@"INSERT INTO ProductLines
                               VALUES('5',N'Lò Vi Sóng',1500000,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(@"DELETE FROM ProductLines
                               WHERE product_line_id='1'");
            migrationBuilder.Sql(@"DELETE FROM ProductLines
                               WHERE product_line_id='2'");
            migrationBuilder.Sql(@"DELETE FROM ProductLines
                               WHERE product_line_id='3'");
            migrationBuilder.Sql(@"DELETE FROM ProductLines
                               WHERE product_line_id='4'");
            migrationBuilder.Sql(@"DELETE FROM ProductLines
                               WHERE product_line_id='5'");
        }
    }
}
