namespace E_CommerceAPI.DTOs.OrderDTO
{
    public class EditOrderDTO
    {
        public List<OrderProductDTO> products { get; set; }
    }

    public class OrderProductDTO
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
