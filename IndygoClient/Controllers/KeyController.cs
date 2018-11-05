using IndygoClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndygoClient.Controllers
{
    internal class KeyController : BaseController
    {
        private string route = "Keycodes/";
        
        internal async Task<string> FindByKeycodeAsync(string keyCode, string tokenId)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("keyCode", keyCode),
                    new KeyValuePair<string, string>("tokenId", tokenId)
                });

                var keycode = await networkHandler.PostAsync(apiUrl + route + "validate", content);

                return keycode.Item2;
            }
            catch (Exception ex) // Failed to connect TODO
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}