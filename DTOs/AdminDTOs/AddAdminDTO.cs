using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.DTOs.AdminDTOs
{
    public class AddAdminDTO
    {


        [Required]
        public string username { get; set; }
        [Required]

        public string email { get; set; }

        [Required]

        public string password { get; set; }
        [Required]
        public string phonenumber { get; set; }
    }
}
