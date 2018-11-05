using System;

namespace IndygoClient.Models
{
    internal class Token
    {
        public string TokenId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool IsDisabled { get; set; }
    }
}