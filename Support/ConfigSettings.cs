using System.Collections.Generic;

namespace ReqnRollProjectArchitecture.Support
{
    public class ConfigSettings
    {
        public TestSettings TestSettings { get; set; } = new TestSettings();
    }

    public class TestSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public List<string> Browsers { get; set; } = new List<string>();
        public string DefaultBrowser { get; set; } = "chrome";
        public bool Headless { get; set; }
        public int ExplicitWait { get; set; }
        public string Environment { get; set; } = "QA";
        public CredentialsSettings Credentials { get; set; } = new CredentialsSettings();
        public string ExpectedHomePageTitle { get; set; } = string.Empty;
    }

    public class CredentialsSettings
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
