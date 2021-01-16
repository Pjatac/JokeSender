namespace JokeSender.Domain.EmailSender
{
    public class SmtpEmailSenderConfiguration
    {
        public SmtpEmailSenderConfiguration(string senderEmail, string host, string userName, string password)
        {
            SenderEmail = senderEmail;
            Host = host;
            UserName = userName;
            Password = password;
        }

        public string SenderEmail { get; }

        public string Host { get; }

        public string UserName { get; }

        public string Password { get; }
    }
}
