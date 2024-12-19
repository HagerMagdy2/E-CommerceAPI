using System.ComponentModel.DataAnnotations;

namespace E_CommerceAPI.DTOs.CategoryDTO
{
    public class DisplayCategoryDTO
    {
        public int id { get; set; }
       
        public string name { get; set; }
        public string description { get; set; }
    }
}
