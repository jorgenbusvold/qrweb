using System;

namespace qrweb.models
{
    public class UserDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string B64QrCodeString { get; set; }
    }
}