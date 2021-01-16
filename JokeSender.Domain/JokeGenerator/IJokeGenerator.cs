using System.Threading.Tasks;

namespace JokeSender.Domain.JokeGenerator
{
    public interface IJokeGenerator
    {
        /// <summary>
        /// Generates a joke
        /// </summary>
        /// <returns>A string representation of a joke</returns>
        /// <exception cref="JokeGenerationFailedException">If the joke generation failed</exception>
        public Task<string> GetNewJokeAsync();
    }
}
