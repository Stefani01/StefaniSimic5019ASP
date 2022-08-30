using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Configurations
{
    public class AlbumConfiguration : EntityConfiguration<Album>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Album> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Published).IsRequired();

            builder.HasIndex(x => x.Name);

            builder.HasMany(x => x.Songs).WithOne(x => x.Album).HasForeignKey(x => x.AlbumID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Likes).WithOne(x => x.Album).HasForeignKey(x => x.AlbumID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Genres).WithOne(x => x.Album).HasForeignKey(x => x.AlbumID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Artist).WithMany(x => x.Albums).HasForeignKey(x => x.ArtistID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
