using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_SuperTest.Support
{
    public class Urls
    {
        //I want to set a base url. Here delare it
        public string baseUrl;

        public string LifeEnvironment = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LifeEnvironment"))
            ? System.Configuration.ConfigurationManager.AppSettings["LifeEnvironment"]
            : Environment.GetEnvironmentVariable("LifeEnvironment");

        public Urls()
        {
                SetBaseUrl();
        }

        private void SetBaseUrl()
        {
            switch (LifeEnvironment.ToLower())
            {
                case "local":
                    baseUrl = "http://life.local.comparethemarket.com/LifeInsurance/";
                    break;
                case "qa":
                    baseUrl = "https://life.qa.internal.comparethemarket.com/LifeInsurance/";
                    break;
                default:
                    baseUrl = "http://life.local.comparethemarket.com/LifeInsurance/";
                    break;
            }
        }
    }
}
// able to set environment in app config
//in hooks I need to grab the app setting for environmenet and I need to append the enviroment piece to driver.url
//I also need to drag in the base url from Url class.

    //homework - finish adding a base url and environment app settings 