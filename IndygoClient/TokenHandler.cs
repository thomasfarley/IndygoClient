using static IndygoClient.Response;

using IndygoClient.Controllers;

namespace IndygoClient.Class
{
    internal class TokenHandler
    {
        TokensController tokensController;

        internal TokenHandler()
        {
            tokensController = new TokensController();
        }

        internal TokenValidationStatus ValidateToken(string Token)
        {
            var token = tokensController.FindByTokenId(Token);
            if (token != null && token.TokenId == Token)
            {
                if (!token.IsDisabled)
                {
                    return TokenValidationStatus.TokenValidated;
                }
                else
                {
                    return TokenValidationStatus.BannedToken;
                }
            }
            else
            {
                return TokenValidationStatus.InvalidToken;
            }
        }
    }
}