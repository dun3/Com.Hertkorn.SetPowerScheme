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

namespace Com.Hertkorn.SetPowerScheme.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class PowerSchemeRepository
    {
        public IEnumerable<Entities.PowerScheme> FindAll()
        {
            var schemeGuid = Guid.Empty;

            uint sizeSchemeGuid = (uint)Marshal.SizeOf(typeof(Guid));
            uint schemeIndex = 0;

            while (WinAPI.PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (uint)WinAPI.AccessFlags.ACCESS_SCHEME, schemeIndex, ref schemeGuid, ref sizeSchemeGuid) == 0)
            {
                string friendlyName = ReadFriendlyName(schemeGuid);

                yield return new Entities.PowerScheme() { Id = schemeGuid, FriendlyName = friendlyName };

                schemeIndex++;
            }
        }

        public Entities.PowerScheme FindById(Guid id)
        {
            return FindAll().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void SetActive(Entities.PowerScheme powerScheme)
        {
            var schemeGuid = powerScheme.Id;

            WinAPI.PowerSetActiveScheme(IntPtr.Zero, ref schemeGuid);
        }

        public Entities.PowerScheme GetActive()
        {
            IntPtr pCurrentSchemeGuid = IntPtr.Zero;

            WinAPI.PowerGetActiveScheme(IntPtr.Zero, ref pCurrentSchemeGuid);

            var currentSchemeGuid = (Guid)Marshal.PtrToStructure(pCurrentSchemeGuid, typeof(Guid));

            return FindById(currentSchemeGuid);
        }

        private static string ReadFriendlyName(Guid schemeGuid)
        {
            uint sizeName = 1024;
            IntPtr pSizeName = Marshal.AllocHGlobal((int)sizeName);

            string friendlyName;

            try
            {
                WinAPI.PowerReadFriendlyName(IntPtr.Zero, ref schemeGuid, IntPtr.Zero, IntPtr.Zero, pSizeName, ref sizeName);
                friendlyName = Marshal.PtrToStringUni(pSizeName);
            }
            finally
            {
                Marshal.FreeHGlobal(pSizeName);
            }

            return friendlyName;
        }
    }
}
