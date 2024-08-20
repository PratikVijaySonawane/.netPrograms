using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopingCartMVCui.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int Id { get; set; }

        [Required]
        public int StatusId { get; set; }

        /* Declaring the Fields */
        [Required,MaxLength(29)]
        public string?  StatusName { get; set; }
    }
}
