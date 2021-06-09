using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using WeddingApi.Models;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class DispatchBuilder
    {
        private readonly CardBuilder _cardBuilder;

        private const string SenderEmail = "våranballaapp@giftdig.kär";
        private const string UsernameSenderEmail = "";
        private const string PasswordSenderEmail = "";
        private const string SubjectEmail = "Save this date dude!";


        public DispatchBuilder(CardBuilder cardBuilder)
        {
            _cardBuilder = cardBuilder;
        }

        public void Deliver()
        {
            if (_cardBuilder.Emails != null)
            {
                DeliverEmail();

                if (_cardBuilder.Options.SetReminder)
                {
                    SetReminder();
                }
            }
        }

        private void DeliverEmail()
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.Subject = SubjectEmail;
            message.IsBodyHtml = false; // just nu string, sen kanske html
            message.Body = _cardBuilder.Message;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(UsernameSenderEmail, PasswordSenderEmail);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            message.From = new MailAddress(SenderEmail);

            foreach (var email in _cardBuilder.Emails)
            {
                message.To.Add(new MailAddress(email));
            }
            smtp.Send(message);
        }

        public async Task SetReminder()
        {
            var reminder = new Reminder
            {
                Wedding = _cardBuilder.Wedding,
                Date = DateTime.Now.AddDays(69)
            };
        }
    }
}
