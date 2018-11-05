using System;

namespace IndygoClient.Models
{
    internal class User
    {
        public string Username { get; set; }
        public string Password { get; private set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
