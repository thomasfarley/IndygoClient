using static IndygoClient.Response;

using IndygoClient.Controllers;
using IndygoClient.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndygoClient.Class
{
    internal class LicenseHandler
    {
        internal readonly string Token;
        
        internal LicenseHandler(string Token)
        {
            this.Token = Token;
        }
       
        private void GenerateLocalLicense(string keycode)
        {
            var lic = new License(keycode, Token);

            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Indygo");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            directory = Path.Combine(directory, "license.lic");

            //Serialize and write license file
            //TODO: Some type of public key encryption system
            WriteToBinaryFile(directory, lic);

        }

        internal bool ValidateLocalLicense()
        {
            string licenseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Indygo", "license.lic");
            if (!Directory.Exists(licenseDirectory))
            {
                return false;
            }

            License key;
            try
            {
                key = ReadFromBinaryFile<License>(licenseDirectory);
            }
            catch
            { 
                return false;
            }
            if (key.TokenId == Token)
            {
                //TODO server validation
                //FUTURE UPDATES: Allow offline verification
                return true;
            }
            return false;
        }

        internal async Task<Tuple<RegistrationResponse, Keycode>> RegisterKeyAsync(string keycode)
        {
            var response = await new KeyController().FindByKeycodeAsync(keycode, Token);
            if (response.Item1) // If data successfully acquired and converted
            {

            }



        }

        private void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        private T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }

    [Serializable]
    class License
    {
        public string KeycodeId { get; }
        public string TokenId { get; }
        public int Seed { get; }
        DateTime GenerationTime { get; }
        
        public License(string keycodeId, string tokenId)
        {
            KeycodeId = keycodeId;
            TokenId = tokenId;
            GenerationTime = DateTime.UtcNow;
            Seed = new Random().Next(0, 9999999); // Temporary
        }
    }
}