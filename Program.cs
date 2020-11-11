using JokeSenderConsole.Models;
using System;
using System.Net;
using System.Net.Http;

namespace JokeSenderConsole
{
	class Program
	{
		private static HttpClient http = new HttpClient();
		static void Main(string[] args)
		{
			Console.WriteLine($"Hello, User!");
			bool exit = false;
			var validator = new EmailValidator();
			var jokeGetter = new JokeGetter();
			var sender = new Sender();
			while (!exit)
			{
				Console.WriteLine($"Please, input your e-mail, or type `Exit` to finish");
				string emailToSend = Console.ReadLine();
				if (emailToSend != "Exit")
				{
					var checkValidity = validator.ValidateEmail(http, emailToSend);
					if (checkValidity)
					{
						var jokeResponse = jokeGetter.GetNewJoke(http).Result;
						if (jokeResponse.Substring(0, 40) != "Something went wrong on getting joke...!")
						{
							sender.SendMessage(
								emailToSend,
								jokeResponse);
						}
						else
						{
							Console.WriteLine(jokeResponse);
						}
					}
					else 
					{
						Console.WriteLine("Email validation faild...");
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
