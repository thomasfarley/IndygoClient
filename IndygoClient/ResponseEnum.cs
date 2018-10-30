namespace IndygoClient
{
    internal class ResponseEnum
    {
        internal enum TokenValidationStatus { TokenValidated, InvalidToken, BannedToken, SoftwareOutOfDate, UnknownError }
        internal enum LicenseStatus { Success }

    }
}
