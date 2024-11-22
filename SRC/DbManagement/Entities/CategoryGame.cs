namespace DbManagement.Entities
{
    public class CategoryGame
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
