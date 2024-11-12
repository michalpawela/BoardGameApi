using System.Collections.Generic;

namespace BoardGame_REST_API.DbManagement.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeOfPlayingInMinutes { get; set; }
        public float Weight { get; set; }
        public float Score { get; set; }
        public int NumberOfWeightVotes { get; set; }
        public int NumberOfScoreVotes { get; set; }

        // Navigation property for many-to-many with Author through AuthorGame
        public ICollection<AuthorGame> AuthorGames { get; set; }

        // If you have a similar setup with Category
        public ICollection<CategoryGame> CategoryGames { get; set; }

    }
}
