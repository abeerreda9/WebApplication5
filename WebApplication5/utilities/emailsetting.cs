using System.Net;
using System.Net.Mail;

namespace WebApplication5.utilities
{
    public static class emailsettings
    {
        public static  void sendemail(email email)
        {
            var client=new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("abeerreda07@gmail.com","123");
            client.Send("abeerreda07@gmail.com", email.to, email.subject, email.body);
        }
    }
}
