using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopingCartMVCui.Models
{
    [Table("Book")]
    public class Book
    {
        /* Declaring the Fields */
        /* BookId */
        public int Id { get; set; }

        /* Book-Name */
        [Required]
        [MaxLength(50)]
        public string? BookName { get; set; }

        /* Author-Name */
        [Required]
        [MaxLength(40)]
        public string? BAuthorName { get; set; }

        /* Price */
        [Required]
        public double Price { get; set; }

        /* Adding the Book to Image Field */
        public  string? Image { get; set; }

        /* Foreign Key*/
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
        public  List<CartDetail> CartDetails { get; set; }

        /* Genere-Name */
        [NotMapped]
        public string GenreName { get; set; }
    }
}
