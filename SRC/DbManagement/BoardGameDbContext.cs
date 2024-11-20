using BoardGame_REST_API.DbManagement.Entities;
using DbManagement;
using Microsoft.EntityFrameworkCore;

namespace BoardGame_REST_API.DbManagement
{
    public class BoardGameDbContext : DbContext
    {
        
        public DbSet<Game> Games { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryGame> CategoryGames { get; set; }
        public DbSet<AuthorGame> AuthorGames { get; set; }

        public BoardGameDbContext(DbContextOptions<BoardGameDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorGame>()
                .HasKey(ag => new { ag.AuthorId, ag.GameId }); // Composite key

            modelBuilder.Entity<CategoryGame>()
                .HasKey(ag => new { ag.CategoryId, ag.GameId });

            modelBuilder.Entity<AuthorGame>()
                .HasOne(ag => ag.Author)
                .WithMany(a => a.AuthorGames) // Ensure this navigation property exists on Author
                .HasForeignKey(ag => ag.AuthorId);

            modelBuilder.Entity<AuthorGame>()
                .HasOne(ag => ag.Game)
                .WithMany(g => g.AuthorGames) // Ensure this navigation property exists on Game
                .HasForeignKey(ag => ag.GameId);

            modelBuilder.Entity<CategoryGame>()
                .HasOne(ag => ag.Category)
                .WithMany(a => a.CategoryGames) // Ensure this navigation property exists on Author
                .HasForeignKey(ag => ag.CategoryId);

            modelBuilder.Entity<CategoryGame>()
                .HasOne(ag => ag.Game)
                .WithMany(a => a.CategoryGames) // Ensure this navigation property exists on Author
                .HasForeignKey(ag => ag.GameId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings._connectionString); //Will be changed to enviroment varieble
            }
        }

    }
}
