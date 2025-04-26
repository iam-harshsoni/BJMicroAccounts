using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJMicroAccounts.Utils
{
    public class FormValidationHelper
    {
        public static bool ValidateRequiredField(TextBox textBox, ErrorProvider errorProvider, Label errorLabel, Panel errorPanel, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(textBox, errorMessage);
                errorLabel.Text = errorMessage;
                errorPanel.Visible = true;
                textBox.Focus();
                return false;
            }

            return true;
        }
    }
}
