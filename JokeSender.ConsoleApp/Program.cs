using JokeSender.Domain;
using JokeSender.Domain.EmailSender;
using JokeSender.Domain.EmailValidation;
using JokeSender.Domain.JokeGenerator;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeSender.ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            var http = new HttpClient();
            var validator = new DisifyEmailValidator(http);
            var jokeGenerator = new HazdadGenerator(http);

            var configuration = new SmtpEmailSenderConfiguration("test@newjoke.com", "From-cmdline-params", "From-cmdline-params", "From-cmdline-params");
            var emailSender = new SmtpEmailSender(configuration);

            var process = new SendSingleJokeToSingleEmailProcess(validator, jokeGenerator, emailSender);

            var view = new ConsoleView(process);
            await view.RunAsync();
        }
    }
}
