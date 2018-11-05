using IndygoClient.Controllers;
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
            var token = tokensController.FindByTokenId(Token);
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