using MailKit.Net.Smtp;
using MimeKit;
using UsersApi.Models;
using Microsoft.Extensions.Configuration;

namespace UsersApi.Services
{
    public class EmailService
    {
        public void SendEmail(string[] destinatario, string subject, int userId, string code)
        {
            var message = new Message(destinatario, subject, userId, code);

            var messageEmail = CreateBodyEmail(message);
            Enviar(messageEmail);
        }

        public async Task Enviar(MimeMessage messageEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.mailtrap.io", 2525, false);
                    client.Authenticate("f977a725317d1d", "1cc0ea2563c39e");
                    client.Send(messageEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            };
        }

        private MimeMessage CreateBodyEmail(Message message)
        {
            var messageEmail = new MimeMessage();
            messageEmail.From.Add(new MailboxAddress("Guilherme", "emailtestetj@gmail.com"));
            messageEmail.To.AddRange(message.Destinatario);
            messageEmail.Subject = message.Subject;
            messageEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            return messageEmail;
        }
    }
}
