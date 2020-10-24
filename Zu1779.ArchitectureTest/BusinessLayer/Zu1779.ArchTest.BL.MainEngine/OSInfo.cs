namespace Zu1779.ArchTest.BL.MainEngine
{
    using System;
    using System.Runtime.InteropServices;
    using intServ = System.Runtime.InteropServices;
    using re = System.Runtime.InteropServices.RuntimeEnvironment;
    using ri = System.Runtime.InteropServices.RuntimeInformation;

    public enum OSType
    {
        Unknown,
        Windows,
        OsX,
        Linux,
    }

    public class OSInfo
    {
        public OSType GetOSType()
        {
            if (ri.IsOSPlatform(OSPlatform.Windows)) return OSType.Windows;
            else if (ri.IsOSPlatform(OSPlatform.OSX)) return OSType.OsX;
            else if (ri.IsOSPlatform(OSPlatform.Linux)) return OSType.Linux;
            else return OSType.Unknown;
        }
    }
}
