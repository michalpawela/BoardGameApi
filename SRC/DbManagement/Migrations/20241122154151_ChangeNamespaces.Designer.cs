﻿// <auto-generated />
using DbManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbManagement.Migrations
{
    [DbContext(typeof(BoardGameDbContext))]
    [Migration("20241122154151_ChangeNamespaces")]
    partial class ChangeNamespaces
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbManagement.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DbManagement.Entities.AuthorGame", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("AuthorGames");
                });

            modelBuilder.Entity("DbManagement.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DbManagement.Entities.CategoryGame", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("CategoryGames");
                });

            modelBuilder.Entity("DbManagement.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
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

            modelBuilder.Entity("DbManagement.Entities.AuthorGame", b =>
                {
                    b.HasOne("DbManagement.Entities.Author", "Author")
                        .WithMany("AuthorGames")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbManagement.Entities.Game", "Game")
                        .WithMany("AuthorGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DbManagement.Entities.CategoryGame", b =>
                {
                    b.HasOne("DbManagement.Entities.Category", "Category")
                        .WithMany("CategoryGames")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbManagement.Entities.Game", "Game")
                        .WithMany("CategoryGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DbManagement.Entities.Author", b =>
                {
                    b.Navigation("AuthorGames");
                });

            modelBuilder.Entity("DbManagement.Entities.Category", b =>
                {
                    b.Navigation("CategoryGames");
                });

            modelBuilder.Entity("DbManagement.Entities.Game", b =>
                {
                    b.Navigation("AuthorGames");

                    b.Navigation("CategoryGames");
                });
#pragma warning restore 612, 618
        }
    }
}