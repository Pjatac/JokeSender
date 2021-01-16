using System.Net.Http;
using System.Threading.Tasks;

namespace JokeSender.Domain.EmailValidation
{
    public interface IEmailValidator
    {
        /// <summary>
        /// Validates the correctness of the e-mail
        /// </summary>
        /// <param name="email">The e-mail to be validated</param>
        /// <returns>True, if the e-mail is valid, false otherwise</returns>
        /// <exception cref="EmailValidationFailedException">If the validation failed</exception>
        public Task<bool> ValidateEmailAsync(string email);
    }
}
