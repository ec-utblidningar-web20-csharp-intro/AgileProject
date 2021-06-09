using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using WeddingApi.Models;
using WeddingApi.Data;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class DispatchBuilder
    {
        private readonly SaveTheDateCardBuilder _cardBuilder;
        private readonly WeddingDbContext _context;

        private const string SenderEmail = "våranballaapp@giftdig.kär";
        private const string UsernameSenderEmail = "";
        private const string PasswordSenderEmail = "";
        private const string SubjectEmail = "Save this date dude!";


        public DispatchBuilder(SaveTheDateCardBuilder cardBuilder, WeddingDbContext context = null)
        {
            _cardBuilder = cardBuilder;
            _context = context;
        }

        public async Task Deliver()
        {
            if (_cardBuilder?.Options?.SendByEmail ?? true)
            {
                DeliverEmail();
                if (_cardBuilder?.Options?.HasReminder ?? false)
                {
                    await SetReminder();
                }
            }

            if (_cardBuilder?.Options?.SendByText ?? true)
            {
                // Implement sending texts
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

            var guests = _cardBuilder.Wedding.GuestList;

            foreach (var guest in guests)
            {
                message.To.Add(new MailAddress(guest.GuestUser.Email));
            }
            try
            {
                smtp.Send(message);
            }
            catch (SmtpFailedRecipientsException exception)
            {
                foreach (var e in exception.InnerExceptions)
                {
                    var status = e.StatusCode;
                    if (status == SmtpStatusCode.Ok) continue;

                    if (_context != null)
                    {
                        var failedToDeliverInfo = new FailedToDeliver
                        {
                            Status = status,
                            Guest = guests.First(g => g.GuestUser.Email == e.FailedRecipient),
                            Email = e.FailedRecipient
                        };
                        continue;
                    }
                    Console.WriteLine("No context supplied, emails that were not delivered won't be logged");
                }
            }
        }

        private async Task SetReminder()
        {
            if (_context != null)
            {
                var reminder = new SaveTheDateCardReminder
                {
                    Wedding = _cardBuilder.Wedding,
                    Date = DateTime.Now.AddDays(69)
                };

                await _context.AddAsync(reminder);
                await _context.SaveChangesAsync();
                return;
            }
            Console.WriteLine("No context supplied, reminder not available");
        }
    }
}
