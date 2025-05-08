using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models.account
{
    public class login_view_model
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
