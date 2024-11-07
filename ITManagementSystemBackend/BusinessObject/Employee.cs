using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(EmployeeCode), IsUnique = true)]
    [Index(nameof(CCCD), IsUnique = true)]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; } = string.Empty;
        [Required]
        public string EmployeeCode { get; set; } = string.Empty;
        [Required]
        public Enum.EnumList.Gender Gender { get; set; }
        [Required]
        public Enum.EnumList.Role Role { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required, MinLength(9), MaxLength(12)]
        public string CCCD { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public Enum.EnumList.EmployeeStatus Status { get; set; }
        [Required]
        public bool IsFirstLogin { get; set; }

        [JsonIgnore]
        public virtual ICollection<Attendance>? Attendances { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        [JsonIgnore]
        public virtual ICollection<TakeLeave> TakeLeaves { get; set; } = new List<TakeLeave>();

    }
}
