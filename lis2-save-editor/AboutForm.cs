using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lis2_save_editor.Properties;

namespace lis2_save_editor
{
    public partial class AboutForm : Form
    {
        private MainForm main;
        public AboutForm(MainForm mf)
        {
            InitializeComponent();
            main = mf;
        }

        private void buttonCheckUpdates_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                var result = await UpdateChecker.CheckForUpdates();
                if (result == null || !result.CanBeUpdated)
                {
                    MessageBox.Show(Resources.NoUpdatesFoundMessage, "Software Update", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (var updateForm = new UpdateForm(result))
                {
                    if (updateForm.ShowDialog() == DialogResult.Yes)
                    {
                        UpdateChecker.VisitDownloadPage();
                    }

                    if (updateForm.DontShowAgainIsChecked)
                    {
                        main._settingManager.Settings.CheckForUpdatesAtStartup = false;
                    }
                }
            });
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            label1.Text = string.Format(Resources.AboutMessage, Program.GetApplicationVersionStr());
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Information, 16, 16);
        }
    }
}
