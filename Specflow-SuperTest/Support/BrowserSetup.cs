using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Specflow_SuperTest
{
    public class BrowserSetup
    {
        public static IWebDriver Driver;
        private static string Username = Environment.GetEnvironmentVariable("SauceLabsUserName");
        private static string AccessKey = AccessKey = Environment.GetEnvironmentVariable("SauceLabsAccessKey");
        private static string _localOrCI=System.Configuration.ConfigurationManager.AppSettings["localOrCI"];

        private static string _useLocalDriverOrSauceLabs =
            System.Configuration.ConfigurationManager.AppSettings["useLocalDriverOrSaucelabs"]; 

        static BrowserSetup()
        {
            CreateNewWebDriver();
        }

        static void CreateNewWebDriver()
        {
            if (_localOrCI == "LOCAL".ToLower())
            {
                if (_useLocalDriverOrSauceLabs == "SAUCELABS".ToLower())
                {
                    DesiredCapabilities caps = new DesiredCapabilities();
                    caps.SetCapability(CapabilityType.BrowserName, System.Configuration.ConfigurationManager.AppSettings["BrowserName"]);
                    caps.SetCapability(CapabilityType.Version, System.Configuration.ConfigurationManager.AppSettings["Version"]);
                    caps.SetCapability(CapabilityType.Platform, System.Configuration.ConfigurationManager.AppSettings["Platform"]);
                    caps.SetCapability("deviceName", System.Configuration.ConfigurationManager.AppSettings["deviceName"]);
                    caps.SetCapability("deviceOrientation", System.Configuration.ConfigurationManager.AppSettings["deviceOrientation"]);
                    caps.SetCapability("appiumVersion", System.Configuration.ConfigurationManager.AppSettings["appiumVersion"]);
                    caps.SetCapability("username", Username);
                    caps.SetCapability("accessKey", AccessKey);
                    caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

                    Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                        TimeSpan.FromSeconds(600));
                }
                else
                {
                    Driver = new ChromeDriver();
                }
            }
            else
            {
                DesiredCapabilities caps = new DesiredCapabilities();
                caps.SetCapability(CapabilityType.BrowserName, Environment.GetEnvironmentVariable("BrowserName"));
                caps.SetCapability(CapabilityType.Version, Environment.GetEnvironmentVariable("Version"));
                caps.SetCapability(CapabilityType.Platform, Environment.GetEnvironmentVariable("Platform"));
                caps.SetCapability("deviceName", Environment.GetEnvironmentVariable("deviceName"));
                caps.SetCapability("deviceOrientation", Environment.GetEnvironmentVariable("deviceOrientation"));
                caps.SetCapability("appiumVersion", Environment.GetEnvironmentVariable("appiumVersion"));
                caps.SetCapability("username", Username);
                caps.SetCapability("accessKey", AccessKey);
                caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

                Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                    TimeSpan.FromSeconds(600));
            }
        }
    }
}