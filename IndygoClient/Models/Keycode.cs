namespace IndygoClient.Models
{
    internal class Keycode
    {
        public string KeycodeId { get; set; }
        public string TokenId { get; set; }
        public Token Token { get; set; }
        public int MaxRegistrations { get; set; }
        public int ExpirationLength { get; set; }
        public byte Package { get; set; }
        public bool IsBanned { get; set; }
    }
}