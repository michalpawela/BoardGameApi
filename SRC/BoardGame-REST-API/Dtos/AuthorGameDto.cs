using BoardGame_REST_API.Dtos;

namespace BoardGame_REST_API.Dtos
{
    public class AuthorGameDto
    {
        public AuthorDto Author { get; set; }
        public int AuthorId { get; set; }
        public GameDto Game { get; set; }
        public int GameId { get; set; }
    }
}
