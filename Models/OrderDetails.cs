using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceAPI.Models
{
    public class OrderDetails
    {
        [ForeignKey("order")]
        public virtual int order_id { get; set; }
        public virtual Order order { get; set; }
        [ForeignKey("product")]
        public virtual int product_id { get; set; }
        public virtual Product product { get; set; }
        public int quantity { get; set; }
        [Column(TypeName = "money")]

        public decimal unitprice { get; set; }
    }
}
