using BusinessObject.Enum;

namespace DataTransfer.Response
{
    public class ProfileEmployeeResponse
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public EnumList.Role Role { get; set; }
        public bool IsFirstLogin { get; set; }
    }
}
