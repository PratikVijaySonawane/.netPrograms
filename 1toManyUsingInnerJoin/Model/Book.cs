using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1toManyUsingInnerJoin.Model
{
    public class Book
    {
        /* Adding the Fields */
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }

        /* Foreign Key*/
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        /* Adding the navigation Property */
        public Author Author { get; set; }
    }
}
