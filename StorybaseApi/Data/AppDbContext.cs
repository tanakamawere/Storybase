using Storybase.Core.Models;

namespace StorybaseApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<LiteraryWork> LiteraryWorks { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReadingProgress> ReadingProgress { get; set; }
    }
}
