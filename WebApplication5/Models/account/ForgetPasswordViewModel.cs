using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models.account
{
    public class ForgetPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string  email { get; set; }
    }
}
