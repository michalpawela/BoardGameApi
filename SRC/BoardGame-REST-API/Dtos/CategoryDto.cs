using BoardGame_REST_API.DbManagement.Entities;

namespace BoardGame_REST_API.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<GameDto>? Games { get; set; }
    }
}
