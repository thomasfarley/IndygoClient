using IndygoClient.Controllers;
using IndygoClient.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IndygoClient.Class
{
    internal class LicenseHandler
    {
        internal readonly string Token;
        
        internal LicenseHandler(string Token)
        {
            this.Token = Token;
        }

        internal bool ValidateLocalLicense()
        {
            return true;
        }

        internal async Task<Tuple<Keycode, byte>> ValidateLicenseKeyAsync(string keycode)
        {
            var keyController = new KeyController();

            string key = await keyController.FindByKeycodeAsync(keycode, Token);
            if (key != null) //Valid data
            {
                Keycode deserializedKey = JsonConvert.DeserializeObject<Keycode>(key);
                return new Tuple<Keycode, byte>(deserializedKey, (byte)ResponseEnum.LicenseStatus.LicenseValidated);
            }
            return null;
        }
    }
}