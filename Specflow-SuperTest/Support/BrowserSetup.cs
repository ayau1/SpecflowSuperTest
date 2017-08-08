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
        protected static string Username;
        protected static string AccessKey;


        static BrowserSetup()
        {
            Username = Environment.GetEnvironmentVariable("SauceLabsUserName");
            AccessKey = Environment.GetEnvironmentVariable("SauceLabsAccessKey");
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName,"Safari");
            caps.SetCapability(CapabilityType.Version, "latest");
            caps.SetCapability(CapabilityType.Platform, "iOS");
            caps.SetCapability("deviceName", "iPhone 7 Simulator");
            caps.SetCapability("deviceOrientation", "portrait");
            caps.SetCapability("appiumVersion","1.6.4");
            caps.SetCapability("username", Username);
            caps.SetCapability("accessKey", AccessKey);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            //Driver = new ChromeDriver();
            Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                TimeSpan.FromSeconds(600));
                
               
        }
    }
}