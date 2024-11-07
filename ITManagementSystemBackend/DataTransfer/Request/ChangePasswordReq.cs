using System.ComponentModel.DataAnnotations;

namespace DataTransfer.Request
{
    public class ChangePasswordReq
    {
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
