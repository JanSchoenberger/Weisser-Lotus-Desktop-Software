using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace Weißer_Lotus_Desktop_Software.Services
{
    public class EmailNotification
    {


        private string smtpServer;
        private int smtpPort;
        private string emailFrom;
        private string password;

        public EmailNotification(string smtpServer, int smtpPort, string emailFrom, string password)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.emailFrom = emailFrom;
            this.password = password;
        }

        public void SendNotification(string emailTo, string subject, string body)
        {
            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(emailFrom, password);

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailFrom);
                mailMessage.To.Add(emailTo);
                mailMessage.Body = body;
                mailMessage.Subject = subject;
                client.Send(mailMessage);
            }
        }



    }
}
