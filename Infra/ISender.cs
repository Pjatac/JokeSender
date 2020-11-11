using System.Net;

namespace JokeSenderConsole.Infra
{
	public interface ISender
	{
		public void SendMessage(string recipient,  string message);
	}
}
