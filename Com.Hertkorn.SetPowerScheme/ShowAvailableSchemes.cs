//===================================================================================
// This Sample Code is provided for the purpose of illustration only and is not 
// intended to be used in a production environment.  THIS SAMPLE CODE AND ANY RELATED 
// INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY 
// AND/OR FITNESS FOR A PARTICULAR PURPOSE.  We grant You a nonexclusive, 
// royalty-free right to use and modify the Sample Code and to reproduce and 
// distribute the object code form of the Sample Code, provided that You agree: 
// (i) to not use Our name, logo, or trademarks to market Your software product in 
// which the Sample Code is embedded; (ii) to include a valid copyright notice on 
// Your software product in which the Sample Code is embedded; and (iii) to 
// indemnify, hold harmless, and defend Us and Our suppliers from and against any 
// claims or lawsuits, including attorneys’ fees, that arise or result from the use 
// or distribution of the Sample Code.
//===================================================================================

namespace Com.Hertkorn.SetPowerScheme
{
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class ShowAvailableSchemes : Form
    {
        private HiddenWindowManager hiddenWindowManager;
        private bool runAsDaemon;
        private Domain.Entities.PowerScheme targetPowerScheme;

        public ShowAvailableSchemes(bool runAsDaemon, Domain.Entities.PowerScheme targetPowerScheme)
        {
            this.runAsDaemon = runAsDaemon && (targetPowerScheme != null);
            this.targetPowerScheme = targetPowerScheme;

            this.hiddenWindowManager = new HiddenWindowManager(this);

            InitializeComponent();

            if (runAsDaemon)
            {
                hiddenWindowManager.MinimizeWindow();
                setPowerSchemeTimer.Tick += new System.EventHandler(setPowerSchemeTimer_Tick);
                setPowerSchemeTimer.Interval = Properties.Settings.Default.CHECK_INTERVAL_IN_SECONDS * 1000;
                setPowerSchemeTimer.Start();
            }

            txtAvailablePowerSchemes.Text = GetPowerSchemesAsString();
            if (targetPowerScheme != null)
            {
                txtCurrentlySetsTo.Text = targetPowerScheme.ToString();
            }
        }

        void setPowerSchemeTimer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                if (this.targetPowerScheme != null)
                {
                    var repository = new Domain.PowerSchemeRepository();
                    repository.SetActive(this.targetPowerScheme);
                }
            }
            catch (Exception)
            {
            }
        }

        private static string GetPowerSchemesAsString()
        {
            var repository = new Domain.PowerSchemeRepository();
            var stringBuilder = new StringBuilder();

            foreach (var powerScheme in repository.FindAll())
            {
                stringBuilder.Append(powerScheme.Id.ToString());
                stringBuilder.Append(" = ");
                stringBuilder.AppendLine(powerScheme.FriendlyName);
            }

            return stringBuilder.ToString();
        }

        private void exitMenuItem_Click(object sender, System.EventArgs e)
        {
            this.hiddenWindowManager.ForceClose();
        }

        private void showKnownPowerSchemesMenuItem_Click(object sender, System.EventArgs e)
        {
            this.hiddenWindowManager.ShowWindow();
        }

        private void trayIcon_DoubleClick(object sender, System.EventArgs e)
        {
            this.hiddenWindowManager.ToggleWindowState();
        }
    }
}
