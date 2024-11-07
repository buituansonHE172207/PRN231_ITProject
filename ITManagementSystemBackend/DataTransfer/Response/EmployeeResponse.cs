using BusinessObject;

namespace DataTransfer.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public string CCCD { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool IsFirstLogin { get; set; }
        public bool HasAnyContract { get; set; }
        public Contract? CurrentContract { get; set; } 
    }
}
