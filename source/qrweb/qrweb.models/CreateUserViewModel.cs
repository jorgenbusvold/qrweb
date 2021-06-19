using System;

namespace qrweb.models
{
    public class CreateUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] QrCode { get; set; }
        public string B64QrCodeString { get; set; }
    }
}
