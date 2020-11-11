using JokeSenderConsole.Infra;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeSenderConsole.Models
{
	public class JokeGetter : IJokeGetter
	{
		//Best way for using - with configuration file, but I'm not shure that using NuGet from Microsoft.Extensions namespace is not external package
		private readonly string _server = "https://icanhazdadjoke.com/";
		public async Task<string> GetNewJoke(HttpClient http)
		{
			try
			{
				var res = await http.SendAsync(new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri(_server),
					Headers = {
					{ 
						HttpRequestHeader.Accept.ToString(), "text/plain" }
					}
				});
				if (res.StatusCode == HttpStatusCode.OK)
				{
					return await res.Content.ReadAsStringAsync();
				}
				else
				{
					return $"Something went wrong on getting joke...! {await res.Content.ReadAsStringAsync()}";
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
