using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Configurations
{
    public class LikeConfiguration : EntityConfiguration<Like>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Like> builder)
        {
            builder.Property(x => x.LikedAt).IsRequired();
        }
    }
}
