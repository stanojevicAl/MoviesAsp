using Application.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _emailPassword;

        public SmtpEmailSender(string fromEmail, string emailPassword)
        {
            _fromEmail = fromEmail;
            _emailPassword = emailPassword;
        }

        public void Send(SendEmailDto email)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromEmail,_emailPassword)
            };

            var message = new MailMessage(_fromEmail, email.SendTo);
            message.Subject = email.Subject;
            message.Body = email.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
