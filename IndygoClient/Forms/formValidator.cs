using IndygoClient.Class;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IndygoClient.Forms
{
    public partial class formValidator : Form
    {
        private LicenseHandler licenseHandler;

        internal formValidator(ref LicenseHandler licenseHandler)
        {
            this.licenseHandler = licenseHandler;
            InitializeComponent();
        }

        private void formValidator_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(licenseHandler.Token);

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var response = await licenseHandler.RegisterKeyAsync(textBox1.Text);
            
            /*
            switch(data.Item2)
            {
                case (byte)LicenseStatus.LicenseValidated:
                    MessageBox.Show(data.Item1.TokenId);
                    break;
                case (byte)LicenseStatus.InvalidLicense:

                    break;
                case (byte)LicenseStatus.LicenseExpired:

                    break;
                case (byte)LicenseStatus.LicenseBanned:

                    break;
                default:
                    break;

            }
            */
        }
    }
}