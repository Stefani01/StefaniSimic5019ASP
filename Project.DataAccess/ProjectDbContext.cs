using Microsoft.EntityFrameworkCore;
using Project.Domen;
using System;

namespace Project.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        private IApplicationUser _user;
        //public ProjectDbContext() { }
        public ProjectDbContext(DbContextOptions options, IApplicationUser user) : base(options) 
        {
            _user = user;
        }

        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<SongArtist>().HasKey(x => new { x.SongID, x.ArtistID });
            modelBuilder.Entity<AlbumGenre>().HasKey(x => new { x.AlbumID, x.GenreID });
            modelBuilder.Entity<Like>().Property(x => x.LikedAt).HasDefaultValueSql("GETDATE()");
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=SIMICPC\SQLEXPRESS;Initial Catalog=ProjectASP;Integrated Security=True");
        //}

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreateBy = _user.Identity;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = _user.Identity;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            e.IsActive = false;
                            e.DeletedAt = DateTime.UtcNow;
                            e.DeletedBy = _user.Identity;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        #endregion

        #region DbSet
        public DbSet<Artist> Artists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        #endregion
    }
}
