using IndygoClient.Class;
using IndygoClient.Controllers;
using IndygoClient.Forms;
using IndygoClient.Models;
using System;
using System.Windows.Forms;
using static IndygoClient.Response;

namespace Indygo
{
    public class LicenseValidator
    {
        private enum Status { Success, InvalidToken }

        private string Token;

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
                case TokenValidationStatus.TokenValidated:

                    //Now we check for a locally stored license file
                    var licenseHandler = new LicenseHandler(Token);

                    /*if (licenseHandler.ValidateLocalLicense())
                    {
                        //return (byte)Status.Success;
                    }
                    */
                    // No local file found, proceed
                    if (UseDefaultActivationPanel) // 
                    {
                        //Display activation panel
                        var formValidator = new formValidator(ref licenseHandler);
                        formValidator.ShowDialog();
                    }
                    break;

                case TokenValidationStatus.InvalidToken:

                    MessageBox.Show("Your API key is invalid.");
                    Environment.Exit(Environment.ExitCode);

                    break;

                case TokenValidationStatus.BannedToken:

                    MessageBox.Show("Your API key is banned.");
                    Environment.Exit(Environment.ExitCode);
                    break;

                case TokenValidationStatus.SoftwareOutOfDate:
                    break;

                case TokenValidationStatus.UnknownError:
                    
                    break;
            }
            return (byte)Status.Success;
        }
    }
} 