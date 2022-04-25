﻿// <auto-generated />
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220425130946_change_table_detail")]
    partial class change_table_detail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.DeliveryOrder", b =>
                {
                    b.Property<string>("delivery_order_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("actual_quantity")
                        .HasColumnType("int");

                    b.Property<string>("delivery_order_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("expected_quantity")
                        .HasColumnType("int");

                    b.Property<string>("order_status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("delivery_order_id");

                    b.ToTable("DeliveryOrders");
                });

            modelBuilder.Entity("API.Entities.DeliveryOrderDetail", b =>
                {
                    b.Property<string>("product_line_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("delivery_order_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("product_line_id", "delivery_order_id");

                    b.ToTable("DeliveryOrderDetails");
                });

            modelBuilder.Entity("API.Entities.ProductInstance", b =>
                {
                    b.Property<string>("product_instance_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("product_line_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("product_instance_id", "product_line_id");

                    b.ToTable("ProductInstances");
                });

            modelBuilder.Entity("API.Entities.ProductLine", b =>
                {
                    b.Property<string>("product_line_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("product_line_id");

                    b.ToTable("ProductLines");
                });

            modelBuilder.Entity("API.Entities.TagReader", b =>
                {
                    b.Property<string>("TagUii")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("TagRssi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagUii");

                    b.ToTable("TagReaders");
                });
#pragma warning restore 612, 618
        }
    }
}
