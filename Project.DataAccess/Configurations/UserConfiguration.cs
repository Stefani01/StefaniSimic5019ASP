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
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(15);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();

            builder.HasMany(x => x.Likes).WithOne(x => x.User)
                   .HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UseCases).WithOne(x => x.User)
                .HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
