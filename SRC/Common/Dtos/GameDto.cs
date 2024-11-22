namespace Common.Dtos
{
    public class GameDto
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeOfPlayingInMinutes { get; set; }
        public float? Weight { get; set; }
        public float? Score { get; set; }
        public ICollection<AuthorDto>? Authors { get; set; }
        public ICollection<CategoryDto>? Categories { get; set; }
    }
}
