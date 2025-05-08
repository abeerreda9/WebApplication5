using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models.account
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        public string ConfirmPassword { get; set; }
    }
}
