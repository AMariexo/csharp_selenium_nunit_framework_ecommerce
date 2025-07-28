using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ECommerceApp.Base
{
    public class BaseDriver
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }


        //pass the locator and the time you want to wait for the element to be displayed
        public IWebElement WaitForElement(By locator, int timeToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

    }
}


