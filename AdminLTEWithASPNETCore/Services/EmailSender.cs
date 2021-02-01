using AdminLTEWithASPNETCore.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SmtpCredentialsSettings _settings;
        static bool mailSent = false;

        public EmailSender(UserManager<IdentityUser> userManager, SmtpCredentialsSettings settings)
        {
            _userManager = userManager;
            _settings = settings;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string emailState = "Sent";

            SmtpClient client = new SmtpClient(_settings.Server, _settings.Port);
            client.EnableSsl = _settings.EnableSSL;
            client.Credentials = new System.Net.NetworkCredential(_settings.Username, _settings.Password);
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            MailAddress from = new MailAddress(_settings.MailFrom, String.Empty, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            message.Body = htmlMessage;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            client.SendAsync(message, emailState);

            return Task.FromResult(mailSent);
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
    }
}