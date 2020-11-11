using JokeSenderConsole.Infra;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace JokeSenderConsole.Models
{
	public class EmailValidator : IEmailValidator
	{
		//Best way for using - with configuration file, but I'm not shure that using NuGet from Microsoft.Extensions namespace is not external package
		private readonly string _server = "https://disify.com/api/email/";
		public bool ValidateEmail(HttpClient http, string address)
		{
			try
			{
				var validation = http.GetAsync(_server + address).Result;
				if (validation.StatusCode == HttpStatusCode.OK)
				{
					var res = JsonSerializer.Deserialize<DisifyResponse>(validation.Content.ReadAsStringAsync().Result);
					return res.format ? true : false;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
