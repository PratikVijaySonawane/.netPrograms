using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopingCartMVCui.Models
{
    [Table("Order")]
    public class Order
    {
        /* Adding the Fields */
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int OrderStatusId { get; set; }

        public bool IsDeleted { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
    }
}
