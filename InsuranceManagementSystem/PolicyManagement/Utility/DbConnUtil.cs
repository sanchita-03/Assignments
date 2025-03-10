using Microsoft.Extensions.Configuration;

namespace PolicyManagement.Utility
{
    static class DbConnUtil
    {
        static IConfiguration _iConfiguration;

        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
            _iConfiguration = builder.Build();
        }
        public static string GetConnectionString()
        {
            return _iConfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
