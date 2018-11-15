using IndygoClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IndygoClient.Controllers
{
    internal class RegistrationController : BaseController
    {
        private string route = "register/";

        internal Task<KeyRegistration> InsertRegistration(Keycode key)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("keyRegistration", JsonConvert.SerializeObject(key))
                });
                

            }
            catch (Exception ex) // Failed to connect TODO proper handling
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
