using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AventStack.ExtentReports;
using ECommerceApp.Utils;

namespace ECommerceApp.Base
{
    public class BaseDriver
    {
        public IWebDriver driver;
        public ChromeOptions options;
        public ExtentReports extent;
        public ExtentTest test;

        [SetUp]
        public void SetUp()
        {
            options = new ChromeOptions();
            options.AddArgument("--headless=new"); // or "--headless" for older versions
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument($"--user-data-dir=/tmp/chrome-user-data-{Guid.NewGuid()}");
            driver = new ChromeDriver(options);
            extent = ExtentManager.GetExtent();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //write to the report
            extent.Flush();
        }


        //pass the locator and the time you want to wait for the element to be displayed
        public IWebElement WaitForElement(By locator, int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

    }
}


