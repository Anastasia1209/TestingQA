using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;

namespace Lab11.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        { 
            driver = new ChromeDriver();
   
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
