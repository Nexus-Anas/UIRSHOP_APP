using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UIRSHOP.DAL;

public  class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DetailsFacture> DetailsFactures { get; set; }

    public virtual DbSet<Facture> Factures { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderproduct> Orderproducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_date");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.DateCreation)
                .HasColumnType("datetime")
                .HasColumnName("Date_Creation");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Tel).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<DetailsFacture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("details_factures");

            entity.HasIndex(e => e.FactureId, "FK_Details_Factures_Factures");

            entity.HasIndex(e => e.ProductId, "FK_Details_Factures_Products");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FactureId)
                .HasColumnType("int(11)")
                .HasColumnName("Facture_Id");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("Product_Id");
            entity.Property(e => e.ProductPu)
                .HasPrecision(7, 2)
                .HasColumnName("Product_PU");
            entity.Property(e => e.ProductQty)
                .HasColumnType("int(11)")
                .HasColumnName("Product_Qty");

            entity.HasOne(d => d.Facture).WithMany(p => p.DetailsFactures)
                .HasForeignKey(d => d.FactureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Details_Factures_Factures");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailsFactures)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Details_Factures_Products");
        });

        modelBuilder.Entity<Facture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("factures");

            entity.HasIndex(e => e.OrderId, "FK_Factures_Orders");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DateFacture)
                .HasColumnType("datetime")
                .HasColumnName("Date_Facture");
            entity.Property(e => e.Num).HasMaxLength(50);
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("Order_Id");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(7, 2)
                .HasColumnName("Total_Amount");

            entity.HasOne(d => d.Order).WithMany(p => p.Factures)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factures_Orders");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.ClientId, "FK_Orders_Clients");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(11)")
                .HasColumnName("Client_Id");
            entity.Property(e => e.DateCreate)
                .HasColumnType("datetime")
                .HasColumnName("Date_Create");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Clients");
        });

        modelBuilder.Entity<Orderproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orderproducts");

            entity.HasIndex(e => e.CategoryId, "FK_OrderProducts_Categories");

            entity.HasIndex(e => e.ProductId, "FK_OrderProducts_Products");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("Category_Id");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("Product_Id");
            entity.Property(e => e.Qty).HasColumnType("int(11)");

            entity.HasOne(d => d.Category).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProducts_Categories");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderproducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProducts_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "FK_Products_Categories");

            entity.HasIndex(e => e.SupplierId, "FK_Products_Suppliers");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("Category_Id");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(200)
                .HasColumnName("Image_path");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasPrecision(7, 2);
            entity.Property(e => e.Size).HasMaxLength(50);
            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("Supplier_Id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("stocks");

            entity.HasIndex(e => e.ProductId, "FK_Stocks_Products");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.Price).HasPrecision(7, 2);
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("Product_Id");
            entity.Property(e => e.Qty).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Date");

            entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stocks_Products");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sub_categories");

            entity.HasIndex(e => e.CategoryId, "FK_SubCategories_Categories");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("Category_Id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Updated_date");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubCategories_Categories");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.FacebookUrl)
                .HasMaxLength(150)
                .HasColumnName("Facebook_url");
            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.InstagramUrl)
                .HasMaxLength(150)
                .HasColumnName("Instagram_url");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TikTokUrl)
                .HasMaxLength(150)
                .HasColumnName("TikTok_url");
            entity.Property(e => e.TwitterUrl)
                .HasMaxLength(150)
                .HasColumnName("Twitter_url");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

    }

}
