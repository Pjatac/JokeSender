using JokeSenderConsole.Infra;
using System;
using System.Net;
using System.Net.Mail;

namespace JokeSenderConsole.Models
{
	public class Sender : ISender
	{
		//Best way for using - with configuration file, but I'm not shure that using NuGet from Microsoft.Extensions namespace is not external package
		const string TITLE = "New joke";
		const string SENDER = "test@newjoke.com";
		//Need to fill server details!!!
		const string SMTP = "";
		const string USER = "";
		const string PASS = "";

		public Sender()
		{ 
			
		}
		public void SendMessage(string recipient, string message)
		{
			try
			{
				SmtpClient mailClient = new SmtpClient(SMTP)
				{
					Credentials = new NetworkCredential(USER, PASS)
				};

				mailClient.Send(SENDER, recipient, TITLE, message);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
