using filmAlert.interfaces;
using filmAlert.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace filmAlert.helpers
{
    public class SendEmail: ISendEmail
    {

        public bool send(List<show> showList) 
        {
            string filmsString = string.Join(",", showList);
            try
            {
                var body = "<p>New shows!</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("samrobbo1997@live.co.uk"));  // where the message is going 
                message.From = new MailAddress("sam@samsite.tech", "FilmAlert");  // being sent from
                message.Subject = "from FilmAlert";
                message.Body = string.Format(body, "FilmAlert", "sam@samsite.tech", filmsString);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "sam@samsite.tech",
                        Password = "Film@Alertpass5728"
                    };

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "stmphost";
                    smtp.Timeout = 10000;
                    smtp.Port = 80;
                    smtp.Send(message);

                    return true;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed to send email {e}");
                return false;
            }
        }
    }
}
