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
        private string _localOrCI=System.Configuration.ConfigurationManager.AppSettings["localOrCI"];

        private string _useLocalDriverOrSauceLabs =
            System.Configuration.ConfigurationManager.AppSettings["useLocalDriverOrSaucelabs"]; 


        static BrowserSetup()
        {

            //local with local webdriver

            /*
             * get the app config setting for where I want to run it (myComputer or CI)
             * get the app config for how (local web or sauce)
             * if app config set to myComputer
             *   if I want to use saucelabs
             *      then driver should be set to sauce remote driver with desired capabilities set from app config
             *   if I want to run with local webdriver
             *          then driver should be set to local webdriver
             *  else if app config set to CI
             *      then driver should be set to sauce remote driver with desired capabilities set from environment variables
             */

            Username = Environment.GetEnvironmentVariable("SauceLabsUserName");
            AccessKey = Environment.GetEnvironmentVariable("SauceLabsAccessKey");

        }

        public void CreateNewWebDriver()
        {
            if (_localOrCI == "local")
            {
                if (_useLocalDriverOrSauceLabs == "localDriver")
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
            }
        }
    }
}