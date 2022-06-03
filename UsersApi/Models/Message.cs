using MimeKit;

namespace UsersApi.Models
{
    public class Message
    {
        public List<MailboxAddress> Destinatario { get; set; }
        
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> destinatario, string subject, int userId, string code)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress("",d)));
            Subject = subject;
            Content = $"http://localhost:7012/ativa?UserId={userId}&ActiveCode{code}";
        }
    }
}
