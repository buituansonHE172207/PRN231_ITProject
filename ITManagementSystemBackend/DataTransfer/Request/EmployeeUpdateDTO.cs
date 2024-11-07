using BusinessObject.Enum;
using System.ComponentModel.DataAnnotations;

namespace DataTransfer.Request
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public string EmployeeName { get; set; } = string.Empty;
        [Required]
        public EnumList.Gender Gender { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required, MinLength(10), MaxLength(12)]
        public string CCCD { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public EnumList.EmployeeType EmployeeType { get; set; }
        [Required]
        public string Phone { get; set; } = string.Empty;
    }
}
