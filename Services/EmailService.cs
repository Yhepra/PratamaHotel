using Microsoft.Extensions.Options;
using PratamaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PratamaHotel.Services
{
    public class EmailService
    {
        private readonly IOptions<Email> _fjson;

        public EmailService(IOptions<Email> em)
        {
            _fjson = em;
        }

        public bool SendEmail(string destination, string title, string contents)
        {
            try
            {
                Email e = new Email();
                e.clientName    = _fjson.Value.clientName;
                e.port          = _fjson.Value.port;
                e.myEmail       = _fjson.Value.myEmail;
                e.myPassword    = _fjson.Value.myPassword;

                MailMessage m   = new MailMessage();
                m.From          = new MailAddress(e.myEmail);
                m.Subject       = title;
                m.Body          = contents;
                m.IsBodyHtml    = true;
                m.To.Add(destination);

                SmtpClient s    = new SmtpClient(e.clientName);
                s.Port          = e.port;
                s.Credentials   = new System.Net.NetworkCredential(e.myEmail, e.myPassword);
                s.EnableSsl     = true;
                s.Send(m);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
