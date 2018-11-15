using IndygoClient.Class;
using IndygoClient.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndygoClient.Controllers
{
    internal class TokensController : BaseController
    {
        private string route = "tokens/";
        internal async Task<Token> FindByTokenIdAsync(string tokenId)
        {
            var token = await networkHandler.DownloadJsonAsync<Token>(apiUrl + tokenId);

            return token.Item2;
        }
        internal Token FindByTokenId(string tokenId)
        {
            try
            {
                var token = networkHandler.DownloadJson<Token>(apiUrl + route + tokenId);
                return token.Item2;
            }
            catch(Exception ex) // Failed to connect
            {
                MessageBox.Show(ex.Message + " - TokensController.FindByTokenId");
            }
            return null;
        }
    }
}