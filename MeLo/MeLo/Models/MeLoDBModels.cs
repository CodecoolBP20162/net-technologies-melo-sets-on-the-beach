namespace MeLo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MeLoDBModels : DbContext
    {
        public MeLoDBModels()
            : base("name=MeLoDBModels")
        {
        }

        public virtual DbSet<ExtensionSet> ExtensionSet { get; set; }
        public virtual DbSet<MediaSet> MediaSet { get; set; }
        public virtual DbSet<PlaylistSet> PlaylistSet { get; set; }
        public virtual DbSet<TypeSet> TypeSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaSet>()
                .HasMany(e => e.PlaylistSet)
                .WithMany(e => e.MediaSet)
                .Map(m => m.ToTable("MediaPlaylist").MapLeftKey("Media_Id").MapRightKey("Playlist_Id"));

            modelBuilder.Entity<TypeSet>()
                .HasMany(e => e.ExtensionSet)
                .WithRequired(e => e.TypeSet)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeSet>()
                .HasMany(e => e.MediaSet)
                .WithRequired(e => e.TypeSet)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
