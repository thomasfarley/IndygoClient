using System;

namespace IndygoClient.Models
{
    internal class SoftwareBan
    {
        public string TokenId { get; set; }
        public Token Token { get; set; }
        public string BanReason { get; set; }
        public DateTime BanDate { get; set; }
    }
}
