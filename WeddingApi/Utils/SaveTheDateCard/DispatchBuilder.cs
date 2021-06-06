using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class DispatchBuilder
    {
        private readonly string _message;
        private readonly IEnumerable<string> _emails;

        private const string SenderEmail = "våranballaapp@giftdig.kär";
        private const string UsernameSenderEmail = "";
        private const string PasswordSenderEmail = "";
        private const string SubjectEmail = "Save this date dude!";

        public DispatchBuilder(DeliverOptionsBuilder options, CardBuilder cardBuilder)
        {
            _message = cardBuilder.Message;
            _emails = cardBuilder.Emails;
        }

        public void Deliver()
        {
            // loop through all channels message is supposed to be sent through
            // Start of with conducting testing for email
            if (_emails != null)
            {
                DeliverEmail();
            }
        }

        private void DeliverEmail()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.Subject = SubjectEmail;
            message.IsBodyHtml = false; // just nu string, sen kanske html
            message.Body = _message;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(UsernameSenderEmail, PasswordSenderEmail);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            message.From = new MailAddress(SenderEmail);

            foreach (var email in _emails)
            {
                message.To.Add(new MailAddress(email));
            }
            smtp.Send(message);
        }
    }
}
