namespace JokeSender.Domain.EmailValidation
{
    internal class DisifyResponse
    {
        public DisifyResponse(bool format, string domain, bool disposable, bool dns)
        {
            Format = format;
            Domain = domain;
            Disposable = disposable;
            Dns = dns;
        }

        public bool Format { get;  }

        public string Domain { get; }

        public bool Disposable { get; }

        public bool Dns { get; }
    }
}
