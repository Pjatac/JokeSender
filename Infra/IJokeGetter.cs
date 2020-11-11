using System.Net.Http;
using System.Threading.Tasks;

namespace JokeSenderConsole.Infra
{
	public interface IJokeGetter
	{
		public Task<string> GetNewJoke(HttpClient http);
	}
}
