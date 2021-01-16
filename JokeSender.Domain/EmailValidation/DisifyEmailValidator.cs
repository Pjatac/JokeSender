using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeSender.Domain.EmailValidation
{
    public class DisifyEmailValidator : IEmailValidator
    {
        //Best way for using - with configuration file, but I'm not shure that using NuGet from Microsoft.Extensions namespace is not external package
        private readonly string _server = "https://disify.com/api/email/";
        private readonly HttpClient _httpClient;

        public DisifyEmailValidator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateEmailAsync(string email)
        {
            try
            {
                var validation = await _httpClient.GetAsync(_server + email);

                if (validation.StatusCode == HttpStatusCode.OK)
                {
                    var resultContent = await validation.Content.ReadAsStringAsync();
                    var desifyRespones = JsonSerializer.Deserialize<DisifyResponse>(resultContent);
                    return desifyRespones.Format;
                }

                throw new EmailValidationFailedException($"Email validation failed for email '{email}', http status code '{validation.StatusCode}'");
            }
            catch (Exception ex)
            {
                throw new EmailValidationFailedException($"Email validation failed for email '{email}'", ex);
            }
        }
    }
}
