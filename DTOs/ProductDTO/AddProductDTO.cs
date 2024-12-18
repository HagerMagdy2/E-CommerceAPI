using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.DTOs.ProductDTO
{
    public class AddProductDTO
    {
        [Required]
        public string producr_name { get; set; }
        [Range(20, 1000, ErrorMessage = "Invalid Price, Price Must between 20 to 1000")]
        public decimal price { get; set; }
        [Range(0, 500, ErrorMessage = "Invalid Stock number")]

        public int srock { get; set; }

        public int cat_id { get; set; }

    }
}
