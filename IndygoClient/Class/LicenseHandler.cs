namespace IndygoClient.Class
{
    internal class LicenseHandler
    {
        private string Token { get; }
        internal LicenseHandler(string Token)
        {
            this.Token = Token;
        }

        internal bool ValidateLocalLicense()
        {
            return true;
        }
        internal byte ValidateLicenseKey(string keycode)
        {
            return 1;
        }
    }
}