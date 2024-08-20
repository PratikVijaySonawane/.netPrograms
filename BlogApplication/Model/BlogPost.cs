using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Model
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
       

        public ICollection<Comment> Comments { get; set; }  
        public ICollection<Category> Categories { get; set; }

    }
}
