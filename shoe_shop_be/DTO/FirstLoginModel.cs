using shoe_shop_be.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace shoe_shop_be.DTO
{
    public class FirstLoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public IFormFile Avatar { get; set; }
    }
}
