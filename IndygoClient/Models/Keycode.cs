namespace IndygoClient.Models
{
    internal class Keycode
    {
        public string KeycodeId { get; }
        public string TokenId { get; }
        public Token Token { get; }
        public int MaxRegistrations { get; }
        public int ExpirationLength { get; }
        public byte Package { get; }
        public bool IsBanned { get; }
    }
}