using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopingCartMVCui.Models
{
    [Table("Genre")]
    public class Genre
    {
        /* Id*/
        public int Id { get; set; }

        /* Genre Name */
        [Required]
        [StringLength(50)]
        public string? GenreName { get; set; }

        /* Book Field in the Genre class */
        public List<Book> Books { get; set; }
    }
}
