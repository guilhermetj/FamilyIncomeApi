using MailKit.Net.Smtp;
using MimeKit;
using UsersApi.Models;

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

        private void Enviar(MimeMessage messageEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("Conexao");
                    //todo authemail
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
            messageEmail.From.Add(new MailboxAddress("","Adicionar o remetente"));
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
