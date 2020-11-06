using ECADEconAPI.Class;
using ECADEconAPI.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ECADEconAPI.Services
{
    public class AuthMessageSender : IEmailSender
    {
        protected EmailSettings _emailSettings;
        public AuthMessageSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string subject, string message)
        {
            try
            {
                Execute(subject, message).Wait();
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Execute(string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "API Lexicon"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };
    
                mail.To.Add(new MailAddress(_emailSettings.ToEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                //mail.Attachments.Add(new Attachment(arquivo));

                SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort);
                smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                //smtp.EnableSsl = true;

                await smtp.SendMailAsync(mail);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}