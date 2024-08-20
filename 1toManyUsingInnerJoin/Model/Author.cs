using System.ComponentModel.DataAnnotations;

namespace _1toManyUsingInnerJoin.Model
{
    public class Author
    {
        /* Declaring the Fields for Author */
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        /* Adding the navigation property */
        public ICollection<Book> Books { get; set; }
    }
}
