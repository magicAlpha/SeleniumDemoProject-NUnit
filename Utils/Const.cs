    namespace NUnitFramework.Utils
{
    public static class Const
    {
        /// <summary>
        /// Config Files here
        /// </summary>

        public const string ConfigFileName = "appsettings.json";

        public const string TestDataFileName = "sharedsettings.json";

        public const string LogFileName = "log4net.config";

        /// <summary>
        /// Users defined here.
        /// </summary>

        public const string Headless = "headless";

        public const string FireFoxHeadless = "-headless";

        public const string LinuxHeadless = "--headless";

        //Web drivers path

        //Linux
        public const string ChromeLinuxPath = @"Drivers\Linux\Chrome\";
        public const string FirefoxLinuxPath = @"Drivers\Linux\Firefox\";
        public const string IELinuxPath = @"Drivers\Linux\IE\";

        //Windows
        public const string ChromeWindowPath = @"Drivers\Windows\Chrome\";
        public const string FirefoxWindowPath = @"Drivers\Windows\Firefox\";
        public const string IEWindowPath = @"Drivers\Windows\IE\";        
    }
}
