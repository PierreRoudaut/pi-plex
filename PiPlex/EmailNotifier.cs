using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace PiPlex
{
    using PiPlex.Properties;

    public class Email
    {
        public string Body { get; set; }

        public string Subject { get; set; }

        public string Recipient { get; set; }
    }

    public class EmailNotifier
    {
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static bool SendEmail(Email email)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Settings.Default.NotifierEmail, Settings.Default.NotifierPassword)
            };
            using (var message = new MailMessage(Settings.Default.NotifierEmail, email.Recipient)
            {
                Subject = email.Subject,
                Body = email.Body
            })
            {
                smtp.Send(message);
            }
            return true;
        }
    }
}
