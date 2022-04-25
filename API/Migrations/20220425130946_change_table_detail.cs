using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class change_table_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_checked",
                table: "DeliveryOrderDetails");

            migrationBuilder.RenameColumn(
                name: "product_instance_id",
                table: "DeliveryOrderDetails",
                newName: "product_line_id");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "DeliveryOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "DeliveryOrderDetails");

            migrationBuilder.RenameColumn(
                name: "product_line_id",
                table: "DeliveryOrderDetails",
                newName: "product_instance_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_checked",
                table: "DeliveryOrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
