using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JokeSender.Domain.JokeGenerator
{
    public class HazdadGenerator : IJokeGenerator
    {
        private const string _serverUri = "https://icanhazdadjoke.com/";
        private readonly HttpClient _httpClient;

        public HazdadGenerator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetNewJokeAsync()
        {
            try
            {
                var httpResponse = await _httpClient.SendAsync(new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_serverUri),
                    Headers = {
                    {
                        HttpRequestHeader.Accept.ToString(), "text/plain" }
                    }
                });

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }

                throw new JokeGenerationFailedException($"Joke generation failed, http status code '{httpResponse.StatusCode}'");

            }
            catch (Exception ex)
            {
                throw new JokeGenerationFailedException("Joke generation failed", ex);
            }
        }
    }
}
