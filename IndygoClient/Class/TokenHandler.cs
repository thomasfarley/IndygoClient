using static IndygoClient.ResponseEnum;

namespace IndygoClient.Class
{
    internal class TokenHandler
    {
        internal TokenHandler()
        {

        }

        internal byte ValidateToken(string Token)
        {
            return (byte)TokenValidationStatus.TokenValidated;
        }
    }
}