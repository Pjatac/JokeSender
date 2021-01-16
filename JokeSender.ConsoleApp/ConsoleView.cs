
using JokeSender.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokeSender.ConsoleApp
{
    public class ConsoleView
    {
        private readonly ISendSingleJokeToSingleEmailProcess _process;

        public ConsoleView(ISendSingleJokeToSingleEmailProcess process)
        {
            _process = process;
        }

        public async Task RunAsync()
        {
            bool exit = false;
            Console.WriteLine($"Hello, User!");

            while (!exit)
            {
                Console.WriteLine($"Please, input your e-mail, or type `Exit` to finish");
                string emailToSend = Console.ReadLine();

                if (emailToSend != "Exit")
                {
                    try
                    {
                        await _process.SendJokeAsync(emailToSend, "New joke");
                    }
                    catch (BusinessProcessFailedException ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    exit = true;
                }
            }

            Console.WriteLine($"Good bay!");
            Console.ReadKey();
        }
    }
}
