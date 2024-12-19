namespace E_CommerceAPI.DTOs.ProductDTO
{
    public class DisplayProductDTO
    {
        public int id { get; set; }

        public string product_name { get; set; }

        public decimal price { get; set; }
        public int stock { get; set; }
        public string category { get; set; }
    }
}
