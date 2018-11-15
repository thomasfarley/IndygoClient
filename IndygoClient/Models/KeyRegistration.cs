using System;

namespace IndygoClient.Models
{
    internal class KeyRegistration
    {
        public string KeycodeId { get; set; }
        public Keycode Keycode { get; set; }
        public string TokenId { get; set; }
        public Token Token { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string IPAddress { get; set;  }
    }
}
