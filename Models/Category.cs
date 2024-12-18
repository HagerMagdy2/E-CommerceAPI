using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.Models
{
    public class Category
    {
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
