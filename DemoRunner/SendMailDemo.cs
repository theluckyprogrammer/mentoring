using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Abstract;

namespace DemoRunner
{
    internal class SendMailDemo : Demo
    {
        public override void Run()
        {
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential = new NetworkCredential("","");
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("random@STZN.pl");

            smtpClient.Host = "smtp.webio.pl";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;

            message.From = fromAddress;
            message.Subject = "tytuł wiadomości";
            message.IsBodyHtml = true;
            message.Body = "<h1>treść wiadomości</h1>";
            message.To.Add("wgw31336@msssg.com");

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd podczas wysyłania e-maila: " + ex.Message);
            }
        }
    }
}
