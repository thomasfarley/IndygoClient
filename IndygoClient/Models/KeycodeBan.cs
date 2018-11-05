using System;

namespace IndygoClient.Models
{
    internal class KeycodeBan
    {
        public string KeycodeId { get; set; }
        public Keycode Keycode { get; set; }
        public string TokenId { get; set; }
        public Token Token { get; set; }
        public DateTime BanDate { get; set; }
        public string BanReason { get; set; }
    }
}