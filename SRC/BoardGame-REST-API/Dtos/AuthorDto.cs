using BoardGame_REST_API.DbManagement.Entities;


namespace BoardGame_REST_API.Dtos
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorDescription { get; set; }
        public ICollection<GameDto>? Games { get; set; }
    }
}
