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
    public class GenreConfiguration : EntityConfiguration<Genre>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Albums).WithOne(x => x.Genre).HasForeignKey(x => x.GenreID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
