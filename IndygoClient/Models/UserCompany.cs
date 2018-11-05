namespace IndygoClient.Models
{
    internal class UserCompany
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Username { get; set; }
        public User User { get; set; }
        public byte UserAccessLevel { get; set; }
        public string UserTitle { get; set; }
        public bool IsActiveUser { get; set; }
    }
}
