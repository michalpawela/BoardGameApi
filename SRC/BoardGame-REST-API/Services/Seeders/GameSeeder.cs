using BoardGame_REST_API.DbManagement.Entities;
using BoardGame_REST_API.DbManagement;
using System.Collections.Generic;
using System.Linq;

namespace BoardGame_REST_API.Services.Seeders
{
    public class GameSeeder
    {
        private readonly BoardGameDbContext _dbContext;

        public GameSeeder(BoardGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Games.Any())
                {
                    var games = GetGames();
                    _dbContext.Games.AddRange(games);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Game> GetGames()
        {
            var author1 = new Author
            {
                FirstName = "Krzysztof",
                LastName = "Wolicki",
                AuthorDescription = "Polish game designer",
            };

            var author2 = new Author
            {
                FirstName = "Dominik",
                LastName = "Kasprzycki",
                AuthorDescription = "Concept Artist and Illustrator - Board Games",
            };

            var category1 = new Category
            {
                Name = "Worker Placement",
                Description = "Placing dudes on board to make actions."
            };

            var category2 = new Category
            {
                Name = "Area Control",
                Description = "By controlling area, players can get an advantage and victory."
            };

            var games = new List<Game>()
            {
                new Game
                {
                    Name = "The Lord of the Ice Garden",
                    Description = "Mould the world to match your own twisted vision while avoiding the meddlesome hero.",
                    TimeOfPlayingInMinutes = 90,
                    Weight = 4.5f,
                    Score = 5f,
                    NumberOfScoreVotes = 1,
                    NumberOfWeightVotes = 2,
                    AuthorGames = new List<AuthorGame>
                    {
                        new AuthorGame { Author = author1 },
                        new AuthorGame { Author = author2 }
                    },
                    CategoryGames = new List<CategoryGame>
                    {
                        new CategoryGame { Category = category1 },
                        new CategoryGame { Category = category2 }
                    }
                }
            };
            return games;
        }
    }
}
