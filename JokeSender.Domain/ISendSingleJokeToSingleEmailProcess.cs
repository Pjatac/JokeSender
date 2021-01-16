using System.Threading.Tasks;

namespace JokeSender.Domain
{
    public interface ISendSingleJokeToSingleEmailProcess
    {
        /// <summary>
        /// Sends a random joke to a single email
        /// </summary>
        /// <param name="email">The email address to send the joke to</param>
        /// <param name="title">The title of the email to be sent</param>
        /// <exception cref="BusinessProcessFailedException">Indicates any error in the business process</exception>
        Task SendJokeAsync(string email, string title);
    }
}