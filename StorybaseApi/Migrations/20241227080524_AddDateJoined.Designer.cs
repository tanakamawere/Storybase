﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StorybaseApi.Data;

#nullable disable

namespace StorybaseApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241227080524_AddDateJoined")]
    partial class AddDateJoined
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenreLiteraryWork", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("LiteraryWorksId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "LiteraryWorksId");

                    b.HasIndex("LiteraryWorksId");

                    b.ToTable("LiteraryWorkGenres", (string)null);
                });

            modelBuilder.Entity("Storybase.Core.Models.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("LiteraryWorkId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LiteraryWorkId")
                        .HasDatabaseName("IX_Bookmark_LiteraryWorkId");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_Bookmark_UserId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("Storybase.Core.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .HasDatabaseName("IX_Chapter_BookId");

                    b.HasIndex("BookId", "ChapterNumber")
                        .IsUnique()
                        .HasDatabaseName("IX_Chapter_BookId_ChapterNumber");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Storybase.Core.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Storybase.Core.Models.LiteraryWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FreePreviewPercentage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ProgressiveWriting")
                        .HasColumnType("bit");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WriterId")
                        .HasDatabaseName("IX_LiteraryWork_WriterId");

                    b.ToTable("LiteraryWorks");
                });

            modelBuilder.Entity("Storybase.Core.Models.Pricing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LiteraryWorkId")
                        .HasColumnType("int");

                    b.Property<int>("PricingType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.HasIndex("PricingType")
                        .HasDatabaseName("IX_Pricing_PricingType");

                    b.HasIndex("LiteraryWorkId", "PricingType")
                        .HasDatabaseName("IX_Pricing_LiteraryWorkId_PricingType");

                    b.ToTable("Pricing");
                });

            modelBuilder.Entity("Storybase.Core.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<int?>("LiteraryWorkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PurchaseType")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId")
                        .HasDatabaseName("IX_Purchase_ChapterId");

                    b.HasIndex("LiteraryWorkId")
                        .HasDatabaseName("IX_Purchase_LiteraryWorkId");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_Purchase_UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Storybase.Core.Models.ReadingProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChapterNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastAccessed")
                        .HasColumnType("datetime2");

                    b.Property<int>("LiteraryWorkId")
                        .HasColumnType("int");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LiteraryWorkId")
                        .HasDatabaseName("IX_ReadingProgress_LiteraryWorkId");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_ReadingProgress_UserId");

                    b.ToTable("ReadingProgress");
                });

            modelBuilder.Entity("Storybase.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Auth0UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Auth0UserId")
                        .IsUnique()
                        .HasDatabaseName("IX_User_Auth0UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Storybase.Core.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("GenreLiteraryWork", b =>
                {
                    b.HasOne("Storybase.Core.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Storybase.Core.Models.LiteraryWork", null)
                        .WithMany()
                        .HasForeignKey("LiteraryWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Storybase.Core.Models.Bookmark", b =>
                {
                    b.HasOne("Storybase.Core.Models.LiteraryWork", "LiteraryWork")
                        .WithMany()
                        .HasForeignKey("LiteraryWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Storybase.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteraryWork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Storybase.Core.Models.Chapter", b =>
                {
                    b.HasOne("Storybase.Core.Models.LiteraryWork", "LiteraryWork")
                        .WithMany("Chapters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteraryWork");
                });

            modelBuilder.Entity("Storybase.Core.Models.LiteraryWork", b =>
                {
                    b.HasOne("Storybase.Core.Models.Writer", "Writer")
                        .WithMany("LiteraryWorks")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Storybase.Core.Models.Pricing", b =>
                {
                    b.HasOne("Storybase.Core.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId");

                    b.HasOne("Storybase.Core.Models.LiteraryWork", "LiteraryWork")
                        .WithMany()
                        .HasForeignKey("LiteraryWorkId");

                    b.Navigation("Chapter");

                    b.Navigation("LiteraryWork");
                });

            modelBuilder.Entity("Storybase.Core.Models.Purchase", b =>
                {
                    b.HasOne("Storybase.Core.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId");

                    b.HasOne("Storybase.Core.Models.LiteraryWork", "LiteraryWork")
                        .WithMany()
                        .HasForeignKey("LiteraryWorkId");

                    b.HasOne("Storybase.Core.Models.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chapter");

                    b.Navigation("LiteraryWork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Storybase.Core.Models.ReadingProgress", b =>
                {
                    b.HasOne("Storybase.Core.Models.LiteraryWork", "LiteraryWork")
                        .WithMany()
                        .HasForeignKey("LiteraryWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Storybase.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiteraryWork");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Storybase.Core.Models.Writer", b =>
                {
                    b.HasOne("Storybase.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Storybase.Core.Models.LiteraryWork", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("Storybase.Core.Models.User", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Storybase.Core.Models.Writer", b =>
                {
                    b.Navigation("LiteraryWorks");
                });
#pragma warning restore 612, 618
        }
    }
}
