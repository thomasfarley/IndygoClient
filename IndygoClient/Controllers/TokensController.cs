using IndygoClient.Class;
using IndygoClient.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndygoClient.Controllers
{
    internal class TokensController
    {
        private string apiUrl = "http://localhost:59641/api/Tokens/";
        NetworkHandler networkHandler;

        internal TokensController()
        {
            networkHandler = new NetworkHandler();
        }

        internal async Task<Token> FindByTokenIdAsync(string tokenId)
        {
            Tuple<ResponseInfo, Token> token = await networkHandler.DownloadJsonAsync<Token>(apiUrl + tokenId);
            networkHandler.Dispose();

            return token.Item2;
        }
        internal Token FindByTokenId(string tokenId)
        {
            try
            {
                Tuple<ResponseInfo, Token> token = networkHandler.DownloadJson<Token>(apiUrl + tokenId);
                MessageBox.Show(token.Item2.TimeCreated.ToShortDateString());
                return token.Item2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                networkHandler.Dispose();
            }
            return null;
        }
    }
}