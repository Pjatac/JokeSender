using System.Net.Http;

namespace JokeSenderConsole.Infra
{
	public interface IEmailValidator
	{
		public bool ValidateEmail(HttpClient http, string address);
	}
}
