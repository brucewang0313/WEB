using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BizDataLibrary.Models;

public partial class BizContext : DbContext
{
    public BizContext(DbContextOptions<BizContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Procurement> Procurements { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Salesman> Salesmen { get; set; }

    public virtual DbSet<Selling> Sellings { get; set; }

    public virtual DbSet<SellingSource> SellingSources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Procurement>(entity =>
        {
            entity.HasKey(e => e.ProcurementId).HasName("PK__tmp_ms_x__95B451ECF2B16CBB");

            entity.Property(e => e.ProcurementId).HasComment("進貨單號，自動增加，不可重複");
            entity.Property(e => e.InvetoryQuantity).HasComment("庫存數量");
            entity.Property(e => e.PartNo)
                .HasComment("所採購的貨品編號")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PurchasingDay).HasComment("進貨日期");
            entity.Property(e => e.Quantity).HasComment("採購數量");
            entity.Property(e => e.UintPrice).HasComment("進貨單價");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PartNo).HasName("PK__Product__7C3FF6B7527C26BB");

            entity.Property(e => e.PartNo)
                .HasComment("貨品的料號，不可以重複")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PartName)
                .HasComment("貨品的名稱")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Salesman>(entity =>
        {
            entity.Property(e => e.JobNumber).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Selling>(entity =>
        {
            entity.HasKey(e => e.SellingId).HasName("PK__Selling__4706784FC9D51CE5");

            entity.Property(e => e.SellingId).HasComment("銷售單編號，自動新增，不可重複");
            entity.Property(e => e.PartNo)
                .HasComment("銷售的貨品編號")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Quantity).HasComment("出貨數量");
            entity.Property(e => e.SalesJobNumber).HasComment("業務員的員工編號");
            entity.Property(e => e.SellingDay).HasComment("銷售日期");
            entity.Property(e => e.UnitPrice).HasComment("出貨單價");
        });

        modelBuilder.Entity<SellingSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SellingS__3214EC076E6FC8D8");

            entity.Property(e => e.Id).HasComment("作為自動索引，不可重複");
            entity.Property(e => e.ProcurementId).HasComment("進貨單編號，表示從哪個進貨單出的貨");
            entity.Property(e => e.Quantity).HasComment("表示從特定進貨單出了多少貨");
            entity.Property(e => e.SellingId).HasComment("銷售單編號");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
