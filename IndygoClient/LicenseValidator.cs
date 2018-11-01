using IndygoClient.Class;
using IndygoClient.Forms;
using System;
using static IndygoClient.ResponseEnum;

namespace Indygo
{
    public class LicenseValidator
    {
        private enum Status { Success, InvalidToken }

        private string Token { get; }
        internal bool UseDefaultActivationPanel { get; }
        
        //Constructor
        //API Validation Token, and an option for developers to create their own activation panels.
        public LicenseValidator(string Token, bool UseDefaultActivationPanel = true)
        {
            this.Token = Token;
            this.UseDefaultActivationPanel = UseDefaultActivationPanel;
        }

        public byte Initialize() // ToDo proper response class? Async?
        {
            if (string.IsNullOrEmpty(Token))
            {
                if (UseDefaultActivationPanel)
                {
                    //Shut down program, todo: debug notifications
                    Environment.Exit(Environment.ExitCode);
                }
                return (byte)TokenValidationStatus.InvalidToken;
            }

            var tokenHandler = new TokenHandler();

            switch (tokenHandler.ValidateToken(Token))
            {
                case (byte)TokenValidationStatus.TokenValidated:

                    //Now we check for a locally stored license file
                    var licenseHandler = new LicenseHandler(this.Token);

                    if (licenseHandler.ValidateLocalLicense())
                    {

                        //return (byte)Status.Success;

                    }

                    // No local file found, proceed
                    if (UseDefaultActivationPanel) // 
                    {
                        //Display activation panel
                        var formValidator = new formValidator();
                        formValidator.ShowDialog();
                   
                    }
                    break;

                case (byte)TokenValidationStatus.InvalidToken:
                    break;

                case (byte)TokenValidationStatus.BannedToken:
                    break;

                case (byte)TokenValidationStatus.SoftwareOutOfDate:
                    break;

                case (byte)TokenValidationStatus.UnknownError:
                    break;
            }
            return (byte)Status.Success;
        }
    }
} 