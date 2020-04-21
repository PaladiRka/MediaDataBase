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
        public virtual DbSet<Podcast> Podcast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
                {
                    entity.Property(a => a.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(a => a.Name).IsRequired();
                    entity.Property(a => a.Address).IsRequired();
                });

            modelBuilder.Entity<Track>(entity =>
                {
                    entity.Property(t => t.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(t => t.Title).IsRequired();
                    entity.Property(t => t.Author).IsRequired();
                    entity.Property((t => t.Duration)).IsRequired();
                    entity.HasOne(t => t.Album)
                        .WithMany(a => a.Track)
                        .HasForeignKey(t => t.AlbumId)
                        .HasConstraintName("FK_Track_Album");
                });

            modelBuilder.Entity<Podcast>(entity =>
                {
                    entity.Property(p => p.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(p => p.Title).IsRequired();
                    entity.Property(p => p.Author).IsRequired();
                    entity.Property((p => p.Duration)).IsRequired();
                    entity.HasOne(p => p.Album)
                        .WithMany(a => a.Podcast)
                        .HasForeignKey(p => p.AlbumId)
                        .HasConstraintName("FK_Podcast_Album");
                });
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}