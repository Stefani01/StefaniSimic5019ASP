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
    public class ArtistConfiguration : EntityConfiguration<Artist>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(x => x.Fullname).IsRequired().HasMaxLength(70);
            builder.HasIndex(x => x.Fullname).IsUnique();
            builder.HasMany(x => x.Albums).WithOne(x => x.Artist)
                   .HasForeignKey(x => x.ArtistID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Songs).WithOne(x => x.Artist).HasForeignKey(x => x.ArtistID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
