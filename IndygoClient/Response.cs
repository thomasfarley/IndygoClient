namespace IndygoClient
{
    internal class Response
    {
        internal enum TokenValidationStatus { TokenValidated, InvalidToken, BannedToken, SoftwareOutOfDate, UnknownError }
        internal enum LicenseStatus { LicenseValidated, InvalidLicense, LicenseBanned, LicenseExpired, UnknownError }
        internal enum RegistrationResponse { LicenseRegistered, InvalidLicense, LicenseExpired, LicenseBanned, MaxRegistrationsReached, UnknownError }
    }
}