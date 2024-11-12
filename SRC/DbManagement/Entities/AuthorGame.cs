namespace BoardGame_REST_API.DbManagement.Entities
{
    public class AuthorGame
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
