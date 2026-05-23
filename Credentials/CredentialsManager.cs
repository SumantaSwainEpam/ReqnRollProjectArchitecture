using Microsoft.Extensions.Configuration;
using ReqnRollProjectArchitecture.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReqnRollProjectArchitecture.Credentials
{
    public class CredentialsManager
    {
        private static readonly ConfigSettings _settings;

        static CredentialsManager()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Path.Combine("Credentials", "AppConfig.json"), optional: false, reloadOnChange: true);
                
                var configuration = builder.Build();
                _settings = new ConfigSettings();
                configuration.Bind(_settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                _settings = new ConfigSettings(); // Fallback to defaults
            }
        }

        public static string GetBaseUrl() => _settings.TestSettings.BaseUrl;
        
        public static string GetDefaultUsername() => _settings.TestSettings.Credentials.Username;
        
        public static string GetDefaultPassword() => _settings.TestSettings.Credentials.Password;
        
        public static string GetAppTitle() => _settings.TestSettings.ExpectedHomePageTitle;

        public static List<string> GetBrowsers() => _settings.TestSettings.Browsers;

        public static string GetDefaultBrowser() => _settings.TestSettings.DefaultBrowser;

        public static string GetBrowserByIndex(int index)
        {
            var browsers = GetBrowsers();
            if (browsers == null || index < 0 || index >= browsers.Count)
            {
                return GetDefaultBrowser();
            }
            return browsers[index];
        }

        public static int GetExplicitWait() => _settings.TestSettings.ExplicitWait;
        
        public static string GetEnvironment() => _settings.TestSettings.Environment;
    }
}
