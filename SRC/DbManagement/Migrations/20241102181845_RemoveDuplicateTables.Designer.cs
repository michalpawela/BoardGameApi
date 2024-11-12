﻿// <auto-generated />
using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.DbManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGame_REST_API.Migrations
{
    [DbContext(typeof(BoardGameDbContext))]
    [Migration("20241102181845_RemoveDuplicateTables")]
    partial class RemoveDuplicateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoardGame_REST_API.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.AuthorGame", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("AuthorGames");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.CategoryGame", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("CategoryGames");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfScoreVotes")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfWeightVotes")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<int>("TimeOfPlayingInMinutes")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.AuthorGame", b =>
                {
                    b.HasOne("BoardGame_REST_API.Entities.Author", "Author")
                        .WithMany("AuthorGames")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGame_REST_API.Entities.Game", "Game")
                        .WithMany("AuthorGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.CategoryGame", b =>
                {
                    b.HasOne("BoardGame_REST_API.Entities.Category", "Category")
                        .WithMany("CategoryGames")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGame_REST_API.Entities.Game", "Game")
                        .WithMany("CategoryGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.Author", b =>
                {
                    b.Navigation("AuthorGames");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.Category", b =>
                {
                    b.Navigation("CategoryGames");
                });

            modelBuilder.Entity("BoardGame_REST_API.Entities.Game", b =>
                {
                    b.Navigation("AuthorGames");

                    b.Navigation("CategoryGames");
                });
#pragma warning restore 612, 618
        }
    }
}
