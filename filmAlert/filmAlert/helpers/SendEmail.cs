using filmAlert.interfaces;
using filmAlert.objects;
using FluentEmail.Core;
using FluentEmail.Smtp;
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

        public async Task<bool> send(List<show> showList) 
        {
            string filmsString = string.Join(",", showList);
            try
            {
                var sender = new SmtpSender(() => new SmtpClient("localhost")
                {
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Port = 25
                    //DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    //PickupDirectoryLocation = @"C:\Demos"
                });

                StringBuilder template = new();
                template.AppendLine("<p>Film out!</p>");
                template.AppendLine("- The Film Alert Team");

                Email.DefaultSender = sender;
                

                var email = await Email
                    .From("sam@samsite.tech")
                    .To("samrobbo1997@live.co.uk", "Sam")
                    .Subject("Thanks!")
                    .UsingTemplate(template.ToString(), new { FirstName = "Sam", ProductName = "FilmAlert" })
                    .Body(filmsString)
                    .SendAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed to send email {e}");
                return false;
            }
        }
    }
}
