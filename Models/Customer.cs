using Microsoft.AspNetCore.Identity;

namespace E_CommerceAPI.Models
{
    public class Customer:IdentityUser
    {
        public string fullname { get; set; }
        public string Address { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
