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
        private string route = "keycodes/";
        
        internal async Task<Tuple<bool, Keycode>> FindByKeycodeAsync(string keyCode, string tokenId)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("keyCode", keyCode),
                    new KeyValuePair<string, string>("tokenId", tokenId)
                });
                
                var keycode = await networkHandler.PostAsync(apiUrl + route + "validate", content);

                return new Tuple<bool, Keycode>(true, JsonConvert.DeserializeObject<Keycode>(keycode.Item2));
            }
            catch (Exception ex) // Failed to connect TODO proper handling
            {
                MessageBox.Show(ex.Message);
            }
            return new Tuple<bool, Keycode>(false, new Keycode());
        }

        //TODO Refactor.
        internal object FindByKeycode(string keyCode, string tokenId) 
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("keyCode", keyCode),
                    new KeyValuePair<string, string>("tokenId", tokenId)
                });
                var key = networkHandler.Post(apiUrl + route + "validate", content);

                return key;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}