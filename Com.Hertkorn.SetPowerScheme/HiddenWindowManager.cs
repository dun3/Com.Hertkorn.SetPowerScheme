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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class HiddenWindowManager
    {
        private static readonly object syncRoot = new object();

        private Form form;
        public HiddenWindowManager(Form form)
        {
            this.form = form;

            this.form.FormClosing += new FormClosingEventHandler(FormClosing);
        }

        private FormWindowState prevWindowState = FormWindowState.Normal;
        private void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MinimizeWindow();
                e.Cancel = true;
            }
        }

        public void ForceClose()
        {
            form.FormClosing -= new FormClosingEventHandler(FormClosing);

            form.Close();
        }

        public void ToggleWindowState()
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                RestoreWindowState();
            }
            else
            {
                MinimizeWindow();
            }
        }

        public void MinimizeWindow()
        {
            StoreWindowState();
            form.WindowState = FormWindowState.Minimized;
            form.ShowInTaskbar = false;
        }

        public void ShowWindow()
        {
            RestoreWindowState();
        }

        private void StoreWindowState()
        {
            lock (syncRoot)
            {
                if (form.WindowState != FormWindowState.Minimized)
                {
                    prevWindowState = form.WindowState;
                }
            }
        }

        private void RestoreWindowState()
        {
            lock (syncRoot)
            {
                if (prevWindowState == FormWindowState.Minimized)
                {
                    prevWindowState = FormWindowState.Normal;
                }
                form.ShowInTaskbar = true;
                form.WindowState = prevWindowState;
                form.Activate();
            }
        }

    }
}
