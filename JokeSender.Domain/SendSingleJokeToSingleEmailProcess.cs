using JokeSender.Domain.EmailSender;
using JokeSender.Domain.EmailValidation;
using JokeSender.Domain.JokeGenerator;
using System.Threading.Tasks;

namespace JokeSender.Domain
{
    public class SendSingleJokeToSingleEmailProcess : ISendSingleJokeToSingleEmailProcess
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IJokeGenerator _jokeGenerator;
        private readonly IEmailSender _emailSender;

        public SendSingleJokeToSingleEmailProcess(IEmailValidator emailValidator, IJokeGenerator jokeGenerator, IEmailSender emailSender)
        {
            _emailValidator = emailValidator;
            _jokeGenerator = jokeGenerator;
            _emailSender = emailSender;
        }

        public async Task SendJokeAsync(string email, string title)
        {
            try
            {
                var validEmail = await _emailValidator.ValidateEmailAsync(email);

                if (!validEmail)
                {
                    throw new BusinessProcessFailedException($"The business process stopped because the email '{email}' was found not to be valid");
                }

                var joke = await _jokeGenerator.GetNewJokeAsync();
                await _emailSender.SendMessageAsync(email, title, joke);
            }
            catch (EmailValidationFailedException ex)
            {
                throw new BusinessProcessFailedException("The business process failed to validate the email", ex);
            }
            catch (JokeGenerationFailedException ex)
            {
                throw new BusinessProcessFailedException("The business process failed to generate a joke", ex);
            }
            catch (EmailSendFailedException ex)
            {
                throw new BusinessProcessFailedException("The business process failed to send the email", ex);
            }
        }
    }
}
