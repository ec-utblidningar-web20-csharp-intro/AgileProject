using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WeddingApi.Models;

namespace WeddingApi.Utils.SaveTheDateCard
{
    public class FailedToDeliver
    {
        public SmtpStatusCode Status { get; set; }
        public Guest Guest { get; set; }
        public string Email { get; set; }
    }
}
