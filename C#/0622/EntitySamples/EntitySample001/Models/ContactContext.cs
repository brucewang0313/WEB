using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntitySample001.Models;

public partial class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactsTable> ContactsTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactsTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC07C4BCF6ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
