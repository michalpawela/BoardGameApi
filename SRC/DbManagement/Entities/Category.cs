using System.Collections.Generic;

namespace DbManagement.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<CategoryGame> CategoryGames { get; set; }

    }
}
