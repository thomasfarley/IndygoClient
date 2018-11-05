using IndygoClient.Controllers;
using IndygoClient.Models;
using static IndygoClient.ResponseEnum;

namespace IndygoClient.Class
{
    internal class TokenHandler
    {
        TokensController tokensController;

        internal TokenHandler()
        {
            tokensController = new TokensController();
        }

        internal byte ValidateToken(string Token)
        {
            Token token = tokensController.FindByTokenId(Token);
            if (token != null && token.TokenId == Token)
            {
                if (!token.IsDisabled)
                {
                    return (byte)TokenValidationStatus.TokenValidated;
                }
                else
                {
                    return (byte)TokenValidationStatus.BannedToken;
                }
            }
            else
            {
                return (byte)TokenValidationStatus.InvalidToken;
            }
        }
    }
}