using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CriandoRobot.Send
{
    internal class Email
    {
        public static void SendEmail(string emailBody)
        {
            // Configure o cliente SMTP e envie o e-mail
            SmtpClient smtpClient = new SmtpClient("smtp.seuservidor.com");
            smtpClient.Credentials = new System.Net.NetworkCredential("seuemail@dominio.com", "suasenha");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("seuemail@dominio.com");
            mail.To.Add(new MailAddress("destinatario@dominio.com"));
            mail.Subject = "Benchmarking: nome do Produto";
            mail.Body = emailBody;

            smtpClient.Send(mail);
        }
    }
}
