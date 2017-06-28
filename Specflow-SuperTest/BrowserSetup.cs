using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Specflow_SuperTest
{
    public class BrowserSetup
    {
        public static IWebDriver Driver;

        static BrowserSetup()
        {
            Driver = new ChromeDriver();
        }
    }
}