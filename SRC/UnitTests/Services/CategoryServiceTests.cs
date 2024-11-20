using AutoMapper;
using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.Services;
using BoardGame_REST_API.Services.Interfaces;
using BoardGame_REST_API.Services.Seeders;
using BoardGame_REST_API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Services
{
    public class CategoryServiceTests : IDisposable
    {
        private readonly BoardGameDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IMapper mapper;
        private readonly GameSeeder _gameSeeder;
        private readonly string _databaseName;

        public CategoryServiceTests()
        {
            _databaseName = $"TestBoardGameDb_{Guid.NewGuid()}";

            // Arrange
            var options = new DbContextOptionsBuilder<BoardGameDbContext>()
            .UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database={_databaseName};Trusted_Connection=True;")
            .Options;

            _context = new BoardGameDbContext(options);
            _gameSeeder = new GameSeeder(_context);
            
            // Ensure the database is fresh for testing
            _context.Database.EnsureDeleted();
            _context.Database.Migrate(); // Applies migrations if there are any.

            _gameSeeder.Seed();

            // Initialize the repository with the context
            _categoryService = new CategoryService(_context, mapper);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetAllAsync()
        {
            // Act
            var categories = await _categoryService.GetAllAsync();

            // Assert
            Assert.NotNull(categories);
            Assert.Equal(2, categories.Count());

            var workerPlacementCategory = categories.First(c => c.Name == "Worker Placement");
            Assert.Equal(1, workerPlacementCategory.CategoryId);
            Assert.Single(workerPlacementCategory.Games);
            Assert.Equal("The Lord of the Ice Garden", workerPlacementCategory.Games.First().Name);

            var areaControl = categories.First(c => c.Name == "Area Control");
            Assert.Equal(2, areaControl.CategoryId);
            Assert.Single(areaControl.Games);
            Assert.Equal("The Lord of the Ice Garden", areaControl.Games.First().Name);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var category = await _categoryService.GetByIDAsync(1);

            // Assert
            Assert.NotNull(category);

            Assert.Equal(1, category.CategoryId);
            Assert.Single(category.Games);
            Assert.Equal("The Lord of the Ice Garden", category.Games.First().Name);
        }
    }
}