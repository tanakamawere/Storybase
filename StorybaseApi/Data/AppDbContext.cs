﻿using Storybase.Core.Models;
using Storybase.Core.Models.Payouts;

namespace StorybaseApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<LiteraryWork> LiteraryWorks { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Payments> Payments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ReadingProgress> ReadingProgress { get; set; }
    public DbSet<PayoutRequest> PayoutRequests { get; set; }
    public DbSet<PayoutMethod> PayoutMethods { get; set; }
    public DbSet<UserPayoutChoice> UserPayoutChoices { get; set; }
    public DbSet<PlatformSetting> PlatformSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //PayoutRequest relationships
        modelBuilder.Entity<PayoutRequest>()
            .HasOne(pr => pr.User)
            .WithMany(u => u.PayoutRequests)
            .HasForeignKey(pr => pr.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PayoutRequest>()
            .HasOne(pr => pr.UserPayoutMethod)
            .WithMany()
            .HasForeignKey(pr => pr.PayoutMethodId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure many-to-many relationships
        modelBuilder.Entity<LiteraryWork>()
            .HasMany(l => l.Genres)
            .WithMany(g => g.LiteraryWorks)
            .UsingEntity(j => j.ToTable("LiteraryWorkGenres"));

        // Writer relationship
        modelBuilder.Entity<LiteraryWork>()
            .HasOne(l => l.Writer)
            .WithMany(w => w.LiteraryWorks)
            .HasForeignKey(l => l.WriterId);

        // Bookmark relationships
        modelBuilder.Entity<Bookmark>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Bookmark>()
            .HasOne(b => b.LiteraryWork)
            .WithMany()
            .HasForeignKey(b => b.LiteraryWorkId);

        // Chapter relationship
        modelBuilder.Entity<Chapter>()
            .HasOne(c => c.LiteraryWork)
            .WithMany(l => l.Chapters)
            .HasForeignKey(c => c.BookId);

        modelBuilder.Entity<Chapter>()
            .HasIndex(c => new { c.BookId, c.ChapterNumber })
            .IsUnique()
            .HasDatabaseName("IX_Chapter_BookId_ChapterNumber");

        // Purchase relationships
        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.LiteraryWork)
            .WithMany()
            .HasForeignKey(p => p.LiteraryWorkId);

        // ReadingProgress relationships
        modelBuilder.Entity<ReadingProgress>()
            .HasOne(rp => rp.User)
            .WithMany()
            .HasForeignKey(rp => rp.UserId);

        modelBuilder.Entity<ReadingProgress>()
            .HasOne(rp => rp.LiteraryWork)
            .WithMany()
            .HasForeignKey(rp => rp.LiteraryWorkId);

        // Pricing relationships
        modelBuilder.Entity<Pricing>()
            .HasOne(p => p.LiteraryWork)
            .WithMany()
            .HasForeignKey(p => p.LiteraryWorkId);

        modelBuilder.Entity<Pricing>()
            .HasOne(p => p.Chapter)
            .WithMany()
            .HasForeignKey(p => p.ChapterId);

        // Indexes for frequently queried fields in Pricing
        modelBuilder.Entity<Pricing>()
            .HasIndex(p => p.PricingType)
            .HasDatabaseName("IX_Pricing_PricingType");

        modelBuilder.Entity<Pricing>()
            .HasIndex(p => new { p.LiteraryWorkId, p.PricingType })
            .HasDatabaseName("IX_Pricing_LiteraryWorkId_PricingType");
        // Configure the relationship between Writer and User
        modelBuilder.Entity<Writer>()
            .HasOne(w => w.User)
            .WithMany() // Assuming User does not have a navigation property for Writer
            .HasForeignKey(w => w.UserId) // Explicitly map the foreign key
            .OnDelete(DeleteBehavior.NoAction);

        //INDEXING

        // Index on Auth0UserId for Users table
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Auth0UserId)
            .HasDatabaseName("IX_User_Auth0UserId")
            .IsUnique();

        // Index on UserId in related entities
        modelBuilder.Entity<Bookmark>()
            .HasIndex(b => b.UserId)
            .HasDatabaseName("IX_Bookmark_UserId");

        modelBuilder.Entity<Purchase>()
            .HasIndex(p => p.UserId)
            .HasDatabaseName("IX_Purchase_UserId");

        modelBuilder.Entity<ReadingProgress>()
            .HasIndex(rp => rp.UserId)
            .HasDatabaseName("IX_ReadingProgress_UserId");

        // Index on LiteraryWorkId
        modelBuilder.Entity<Bookmark>()
            .HasIndex(b => b.LiteraryWorkId)
            .HasDatabaseName("IX_Bookmark_LiteraryWorkId");

        modelBuilder.Entity<ReadingProgress>()
            .HasIndex(rp => rp.LiteraryWorkId)
            .HasDatabaseName("IX_ReadingProgress_LiteraryWorkId");

        modelBuilder.Entity<Purchase>()
            .HasIndex(p => p.LiteraryWorkId)
            .HasDatabaseName("IX_Purchase_LiteraryWorkId");
        
        // Index on frequently queried field for Chapter
        modelBuilder.Entity<Chapter>()
            .HasIndex(c => c.BookId)
            .HasDatabaseName("IX_Chapter_BookId");

        // Index for WriterId on LiteraryWork
        modelBuilder.Entity<LiteraryWork>()
            .HasIndex(l => l.WriterId)
            .HasDatabaseName("IX_LiteraryWork_WriterId");

        modelBuilder.Entity<Payments>()
            .HasIndex(p => p.TransactionId)
            .HasDatabaseName("IX_Payments_TransactionId")
            .IsUnique();
        modelBuilder.Entity<Payments>()
            .HasIndex(p => p.PollUrl)
            .HasDatabaseName("IX_Payments_PollUrl");
        //Indexing by paynow reference
        modelBuilder.Entity<Payments>()
            .HasIndex(p => p.PayNowReference)
            .HasDatabaseName("IX_Payments_PaynowReference");
        modelBuilder.Entity<Payments>()
            .HasIndex(p => p.UserId)
            .HasDatabaseName("IX_Payments_UserId");
        modelBuilder.Entity<Payments>()
            .HasIndex(p => p.PaymentStatus)
            .HasDatabaseName("IX_Payments_Status");
        //Index for the UserPayoutChoice table
        modelBuilder.Entity<UserPayoutChoice>()
            .HasIndex(upc => upc.UserId)
            .HasDatabaseName("IX_UserPayoutChoice_UserId");

        modelBuilder.Entity<PayoutRequest>()
            .HasIndex(pr => pr.UserId)
            .HasDatabaseName("IX_PayoutRequest_UserId");

        //Base cut percentage for storybase
        modelBuilder.Entity<PlatformSetting>().HasData(
            new PlatformSetting { Id = 1, SettingKey = "PlatformCutPercentage", SettingValue = "25" }
        );

    }
}
