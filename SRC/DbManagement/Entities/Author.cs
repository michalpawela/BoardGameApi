﻿using System.Collections.Generic;

namespace BoardGame_REST_API.DbManagement.Entities
{
    public class Author
    {
        public int AuthorId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorDescription { get; set; }
        public ICollection<AuthorGame> AuthorGames { get; set; }
    }
}
