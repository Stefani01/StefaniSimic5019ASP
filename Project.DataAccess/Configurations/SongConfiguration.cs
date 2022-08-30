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
    public class SongConfiguration : EntityConfiguration<Song>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Song> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Duration).IsRequired(false);

            builder.HasIndex(x => x.Name);

            builder.HasOne(x => x.Album).WithMany(x => x.Songs).HasForeignKey(x => x.AlbumID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.Artists).WithOne(x=>x.Song).HasForeignKey(x => x.SongID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
