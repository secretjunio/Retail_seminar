using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Retail_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryOrderDetail",
                columns: table => new
                {
                    delivery_order_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_instance_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderDetail", x => new { x.product_instance_id, x.delivery_order_id });
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrders",
                columns: table => new
                {
                    delivery_order_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    delivery_order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    order_status = table.Column<bool>(type: "bit", nullable: false),
                    expected_quantity = table.Column<int>(type: "int", nullable: false),
                    actual_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrders", x => x.delivery_order_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInstance",
                columns: table => new
                {
                    product_intance_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_line_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInstance", x => new { x.product_intance_id, x.product_line_id });
                });

            migrationBuilder.CreateTable(
                name: "ProductLine",
                columns: table => new
                {
                    product_line_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLine", x => x.product_line_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryOrderDetail");

            migrationBuilder.DropTable(
                name: "DeliveryOrders");

            migrationBuilder.DropTable(
                name: "ProductInstance");

            migrationBuilder.DropTable(
                name: "ProductLine");
        }
    }
}
