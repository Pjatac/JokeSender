using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;

namespace JokeSenderConsole
{
	class Program
	{
		//Config information from task document
		const string DS = "https://disify.com/api/email/"; //E-mail validator
		const string IJ = "https://icanhazdadjoke.com/"; //Joke API
		//Need fill data about smtp server connection
		const string SMTP = "";
		const string USER = "";
		const string PASS = "";

		private static HttpClient http = new HttpClient();
		static void Main(string[] args)
		{
			Console.WriteLine($"Hello, User!");
			bool exit = false;
			while (!exit)
			{
				Console.WriteLine($"Please, input your e-mail, or type `Exit` to finish");
				string emailToSend = Console.ReadLine();
				if (emailToSend != "Exit")
				{
					try
					{
						var checkValidity = http.GetAsync(DS + emailToSend).Result;
						if (checkValidity != null && checkValidity.StatusCode == HttpStatusCode.OK)
						{
							var res = JsonSerializer.Deserialize<DisifyResponse>(checkValidity.Content.ReadAsStringAsync().Result);
							if (res.format == true)
							//Email validity submitted
							{
								string joke = GetJoke().Result;
								SendEmail(emailToSend, joke);
							}
							else
							{
								Console.WriteLine($"Wrong e-mail address...");
							}
						}
						else
							Console.WriteLine("Something went wrong...!");
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				else
				{
					exit = true;
				}
			}
			Console.WriteLine("Good bay!");
			Console.ReadKey();
		}

		static async Task<string> GetJoke()
		{
			var res = await http.SendAsync(new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(IJ),
				Headers = {
					{ HttpRequestHeader.Accept.ToString(), "text/plain" }
			}
			});
			return await res.Content.ReadAsStringAsync();
		}

		static void SendEmail(string recipient, string joke)
		{
			SmtpClient mailClient = new SmtpClient(SMTP)
			{
				Credentials = new NetworkCredential(USER, PASS)
			};

			mailClient.Send("test@newjoke.com", recipient, "New joke", joke);

		}
	}

	internal class DisifyResponse
	{
		public bool format { get; set; }
		public string domain { get; set; }
		public bool disposable { get; set; }
		public bool dns { get; set; }
		public override string ToString()
		{
			return $"format: {format} domain: {domain} dns: {dns}";
		}
	}
}
