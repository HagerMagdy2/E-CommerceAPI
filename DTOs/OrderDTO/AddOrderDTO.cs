namespace E_CommerceAPI.DTOs.OrderDTO
{
    public class AddOrderDTO
    {


        public string cust_id { get; set; }
        public List<AddOrderDetailsDTO> products { get; set; } = new List<AddOrderDetailsDTO>();
    }
}
