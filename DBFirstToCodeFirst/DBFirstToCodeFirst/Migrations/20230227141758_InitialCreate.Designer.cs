﻿// <auto-generated />
using System;
using DBFirstToCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBFirstToCodeFirst.Migrations
{
    [DbContext(typeof(PosSystemContext))]
    [Migration("20230227141758_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("AmountPayable")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("amountPayable");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone");

                    b.Property<string>("RegistrationDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("registrationDate");

                    b.Property<string>("SalesLimit")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("salesLimit");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__B611CB7D890203F2");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("itemId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("CreationDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("creationDate");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Price")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("price");

                    b.Property<string>("Quantity")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("quantity");

                    b.Property<string>("UpdateDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("updateDate");

                    b.HasKey("ItemId")
                        .HasName("PK__tmp_ms_x__56A128AA7C26E468");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Receipt", b =>
                {
                    b.Property<int>("ReceiptNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("receiptNo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptNo"));

                    b.Property<string>("Amount")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("amount");

                    b.Property<string>("ReceiptDate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("receiptDate");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int")
                        .HasColumnName("saleId");

                    b.HasKey("ReceiptNo")
                        .HasName("PK__tmp_ms_x__CAA7A1A4B20CE74F");

                    b.HasIndex("SaleId");

                    b.ToTable("Receipt", (string)null);
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("saleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<string>("AmountLeft")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("amountLeft");

                    b.Property<string>("AmountPaid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("amountPaid");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerId");

                    b.Property<string>("Date")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("date");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.Property<string>("TotalAmount")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("totalAmount");

                    b.HasKey("SaleId")
                        .HasName("PK__tmp_ms_x__FAE8F4F55070ED17");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.SaleLineItem", b =>
                {
                    b.Property<int>("LineNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("lineNo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineNo"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("itemId");

                    b.Property<string>("Quantity")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("quantity");

                    b.Property<int?>("SaleId")
                        .HasColumnType("int")
                        .HasColumnName("saleId");

                    b.HasKey("LineNo")
                        .HasName("PK__tmp_ms_x__3249B90F56D5DA30");

                    b.HasIndex("ItemId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleLineItem", (string)null);
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Receipt", b =>
                {
                    b.HasOne("DBFirstToCodeFirst.Models.Sale", "Sale")
                        .WithMany("Receipts")
                        .HasForeignKey("SaleId")
                        .HasConstraintName("FK__Receipt__saleId__3A81B327");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Sale", b =>
                {
                    b.HasOne("DBFirstToCodeFirst.Models.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Sale__customerId__3B75D760");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.SaleLineItem", b =>
                {
                    b.HasOne("DBFirstToCodeFirst.Models.Item", "Item")
                        .WithMany("SaleLineItems")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__SaleLineI__itemI__3D5E1FD2");

                    b.HasOne("DBFirstToCodeFirst.Models.Sale", "Sale")
                        .WithMany("SaleLineItems")
                        .HasForeignKey("SaleId")
                        .HasConstraintName("FK__SaleLineI__saleI__3C69FB99");

                    b.Navigation("Item");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Item", b =>
                {
                    b.Navigation("SaleLineItems");
                });

            modelBuilder.Entity("DBFirstToCodeFirst.Models.Sale", b =>
                {
                    b.Navigation("Receipts");

                    b.Navigation("SaleLineItems");
                });
#pragma warning restore 612, 618
        }
    }
}
