using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopingCartMVCui.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        /* Declaring the Fields */
        public int Id { get; set; }

        /* ForeignKey of user */
        [Required]
        public string UserId { get; set; }

        /* Declaring the boolean Field */
        public bool IsDeleted { get; set; } = false;
    }
}
