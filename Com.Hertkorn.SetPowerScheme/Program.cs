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
    using System.Linq;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool runAsDaemon;
            Guid targetPowerSchemeGuid;

            if (!TryParseArgs(args, out runAsDaemon, out targetPowerSchemeGuid))
            {
                runAsDaemon = Properties.Settings.Default.RUN_AS_DAEMON;
                targetPowerSchemeGuid = Properties.Settings.Default.DEFAULT_POWER_SCHEME_GUID;
            }

            var repository = new Domain.PowerSchemeRepository();

            var targetPowerScheme = repository.FindById(targetPowerSchemeGuid);

            if (targetPowerScheme != null)
            {
                var currentPowerScheme = repository.GetActive();

                if (!currentPowerScheme.Equals(targetPowerScheme))
                {
                    repository.SetActive(targetPowerScheme);
                }

                if (!runAsDaemon)
                {
                    // Done!
                    return;
                }
            }


            // Were not able to simply set the active scheme or are running as daemon

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShowAvailableSchemes(runAsDaemon, targetPowerScheme));
        }

        private static bool TryParseArgs(string[] args, out bool daemon, out Guid schemeGuid)
        {
            daemon = args.Any(x => x == "--daemon");

            if ((daemon && args.Length == 2) || (args.Length == 1))
            {
                if (Guid.TryParse(args[0], out schemeGuid))
                {
                    return true;
                }
            }

            schemeGuid = Guid.Empty;

            return false;
        }
    }
}
