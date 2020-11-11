namespace JokeSenderConsole.Models
{
	public class DisifyResponse
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
