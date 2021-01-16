using System.Threading.Tasks;

namespace JokeSender.Domain.EmailSender
{
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email message
        /// </summary>
        /// <param name="email">The target email</param>
        /// <param name="title">Email title</param>
        /// <param name="message">The message to be sent</param>
        /// <exception cref="EmailSendFailedException">If the joke generation failed</exception>
        public Task SendMessageAsync(string email, string title, string message);
    }
}
