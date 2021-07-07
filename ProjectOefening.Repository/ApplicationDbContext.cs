using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectOefening.Domain;
using ProjectOefening.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectOefening.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Media> Medias { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) // base nodig, anders doet hij niets
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Film>();
            builder.Entity<Music>();
            builder.Entity<Podcast>();
            builder.Entity<TVSerie>();

            base.OnModelCreating(builder);
        }
    }
}
