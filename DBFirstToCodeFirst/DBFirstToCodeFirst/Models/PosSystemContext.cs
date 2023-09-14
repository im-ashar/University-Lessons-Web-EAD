using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstToCodeFirst.Models;

public partial class PosSystemContext : DbContext
{
    public PosSystemContext()
    {
    }

    public PosSystemContext(DbContextOptions<PosSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleLineItem> SaleLineItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=POS_System;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7D890203F2");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AmountPayable)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amountPayable");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RegistrationDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("registrationDate");
            entity.Property(e => e.SalesLimit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salesLimit");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__tmp_ms_x__56A128AA7C26E468");

            entity.ToTable("Item");

            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.CreationDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("creationDate");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quantity");
            entity.Property(e => e.UpdateDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptNo).HasName("PK__tmp_ms_x__CAA7A1A4B20CE74F");

            entity.ToTable("Receipt");

            entity.Property(e => e.ReceiptNo).HasColumnName("receiptNo");
            entity.Property(e => e.Amount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amount");
            entity.Property(e => e.ReceiptDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("receiptDate");
            entity.Property(e => e.SaleId).HasColumnName("saleId");

            entity.HasOne(d => d.Sale).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__Receipt__saleId__3A81B327");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__tmp_ms_x__FAE8F4F55070ED17");

            entity.ToTable("Sale");

            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.AmountLeft)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amountLeft");
            entity.Property(e => e.AmountPaid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amountPaid");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sale__customerId__3B75D760");
        });

        modelBuilder.Entity<SaleLineItem>(entity =>
        {
            entity.HasKey(e => e.LineNo).HasName("PK__tmp_ms_x__3249B90F56D5DA30");

            entity.ToTable("SaleLineItem");

            entity.Property(e => e.LineNo).HasColumnName("lineNo");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("quantity");
            entity.Property(e => e.SaleId).HasColumnName("saleId");

            entity.HasOne(d => d.Item).WithMany(p => p.SaleLineItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__SaleLineI__itemI__3D5E1FD2");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleLineItems)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SaleLineI__saleI__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
