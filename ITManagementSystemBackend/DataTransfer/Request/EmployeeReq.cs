using BusinessObject.Enum;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTO
{
    public class EmployeeReq
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public EnumList.Gender Gender { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required, MinLength(9), MaxLength(12)]
        public string CCCD { get; set; } = string.Empty;
        [Required, MinLength(9), MaxLength(12)]
        public string Phone { get; set; } = string.Empty;
        [Required] 
        public string Address { get; set; } = string.Empty;


    }
}
