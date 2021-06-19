using System;

namespace qrweb.businesslogic.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string B64QrCodeString { get; set; }
    }
}
