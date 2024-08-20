using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopingCartMVCui.Models
{
    [Table("CartDetail")]
    public class CartDetail
    {
        /* Declaring the Fields */
        public int Id { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Book Book { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
