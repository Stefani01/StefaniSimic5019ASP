using Project.Application.Email;
using Project.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.Implementation.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly string _email;
        private readonly string _password;

        public EmailSender(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public void Send(EmailDTO mail)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_email, _password),
                UseDefaultCredentials = false
            };

            var message = new MailMessage(_email, mail.To);
            message.Subject = mail.Title;
            message.Body = mail.Body;
            message.IsBodyHtml = true;

            smtp.Send(message);
        }
    }
}
