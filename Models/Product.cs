using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class Product
    {
        public int id { get; set; }
        [StringLength(150)]
        public string product_name { get; set; }
        [Column(TypeName = "money")]
        public decimal price { get; set; }
        public int stock { get; set; }
        [ForeignKey("category")]
        public int cat_id { get; set; }
        public virtual Category? category { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
