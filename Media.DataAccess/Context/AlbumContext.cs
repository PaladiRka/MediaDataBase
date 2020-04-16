using Media.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Media.DataAccess.Context
{
    public partial class AlbumContext : DbContext
    {
        public AlbumContext()
        {
        }

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Track> Track { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.Name).IsRequired();
                    entity.Property(c => c.Address).IsRequired();
                });

            modelBuilder.Entity<Track>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Title).IsRequired();
                    entity.Property(m => m.Author).IsRequired();
                    entity.Property((m => m.Duration)).IsRequired();
                    entity.HasOne(s => s.Album)
                        .WithMany(c => c.Track)
                        .HasForeignKey(s => s.AlbumId)
                        .HasConstraintName("FK_Track_Album");
                });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}