using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class update_context_repository_addscope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tagReaders",
                table: "tagReaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLine",
                table: "ProductLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInstance",
                table: "ProductInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryOrderDetail",
                table: "DeliveryOrderDetail");

            migrationBuilder.RenameTable(
                name: "tagReaders",
                newName: "TagReaders");

            migrationBuilder.RenameTable(
                name: "ProductLine",
                newName: "ProductLines");

            migrationBuilder.RenameTable(
                name: "ProductInstance",
                newName: "ProductInstances");

            migrationBuilder.RenameTable(
                name: "DeliveryOrderDetail",
                newName: "DeliveryOrderDetails");

            migrationBuilder.RenameColumn(
                name: "product_intance_id",
                table: "ProductInstances",
                newName: "product_instance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagReaders",
                table: "TagReaders",
                column: "TagUii");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLines",
                table: "ProductLines",
                column: "product_line_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInstances",
                table: "ProductInstances",
                columns: new[] { "product_instance_id", "product_line_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryOrderDetails",
                table: "DeliveryOrderDetails",
                columns: new[] { "product_instance_id", "delivery_order_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TagReaders",
                table: "TagReaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLines",
                table: "ProductLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInstances",
                table: "ProductInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryOrderDetails",
                table: "DeliveryOrderDetails");

            migrationBuilder.RenameTable(
                name: "TagReaders",
                newName: "tagReaders");

            migrationBuilder.RenameTable(
                name: "ProductLines",
                newName: "ProductLine");

            migrationBuilder.RenameTable(
                name: "ProductInstances",
                newName: "ProductInstance");

            migrationBuilder.RenameTable(
                name: "DeliveryOrderDetails",
                newName: "DeliveryOrderDetail");

            migrationBuilder.RenameColumn(
                name: "product_instance_id",
                table: "ProductInstance",
                newName: "product_intance_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tagReaders",
                table: "tagReaders",
                column: "TagUii");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLine",
                table: "ProductLine",
                column: "product_line_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInstance",
                table: "ProductInstance",
                columns: new[] { "product_intance_id", "product_line_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryOrderDetail",
                table: "DeliveryOrderDetail",
                columns: new[] { "product_instance_id", "delivery_order_id" });
        }
    }
}
