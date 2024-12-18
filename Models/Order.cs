using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceAPI.Models
{
    public class Order
    {
        public int id { get; set; }
        [Column(TypeName = "date")]

        public DateOnly orderDate { get; set; }
        [Column(TypeName = "money")]
        public decimal totalprice { get; set; }
        public string status { get; set; }
        [ForeignKey("customer")]
        public string cust_id { get; set; }
        public virtual Customer customer { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
