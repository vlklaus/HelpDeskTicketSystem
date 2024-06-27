using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskBackend.Models;

public partial class HelpdeskDbContext : DbContext
{
    public HelpdeskDbContext()
    {
    }

    public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=HelpdeskDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC077DCDB325");

            entity.Property(e => e.UserId).HasMaxLength(255);

            entity.HasOne(d => d.Ticket).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Favorites__Ticke__4BAC3F29");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC074FF117C4");

            entity.Property(e => e.Problem).HasMaxLength(255);
            entity.Property(e => e.Resolution).HasMaxLength(255);
            entity.Property(e => e.User).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
