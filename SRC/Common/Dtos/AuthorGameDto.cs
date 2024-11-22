using Common.Dtos;

namespace Common.Dtos
{
    public class AuthorGameDto
    {
        public AuthorDto Author { get; set; }
        public int AuthorId { get; set; }
        public GameDto Game { get; set; }
        public int GameId { get; set; }
    }
}
