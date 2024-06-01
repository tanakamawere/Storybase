using Microsoft.EntityFrameworkCore;
using StorybaseLibrary.Models;

namespace StorybaseApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<StorybaseUser> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Payments> Payments { get; set; }
    }
}
