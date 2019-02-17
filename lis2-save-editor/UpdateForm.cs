using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lis2_save_editor
{
    public partial class UpdateForm : Form
    {
        public bool DontShowAgainIsChecked { get; private set; } = false;

        public UpdateForm(UpdateCheckingResult updateCheckingResult)
        {
            InitializeComponent();

            var message = new StringBuilder();
            message.AppendLine($"A newer version ({updateCheckingResult.ServerVersion}) is available.");
            message.AppendLine();
            message.AppendLine("Would you like to go to the release download page?");

            labelMessage.Text = message.ToString();
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DontShowAgainIsChecked = checkBoxDontShow.Checked;
        }

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
