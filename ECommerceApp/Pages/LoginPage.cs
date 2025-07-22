using ECommerceApp.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Pages
{
    public class LoginPage : BaseDriver
    {

        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //username field
        private IWebElement userNameInput => driver.FindElement(By.Id("user-name"));
        //password field
        private IWebElement passwordInput => driver.FindElement(By.Id("password"));
        //login button
        private IWebElement loginBtn => driver.FindElement(By.Id("login-button"));
        //error message
        private IWebElement errorMsg => driver.FindElement(By.XPath("//h3[@data-test='error']"));
        //error button
        private IWebElement errorBtn => driver.FindElement(By.ClassName("error-button"));

        public void enterUserName(String userName)
        {
            userNameInput.SendKeys(userName);
        }

        public void enterPassword(String password)
        {
            passwordInput.SendKeys(password);
        }

        public void clickLoginBtn()
        {
            loginBtn.Click();
        }

        public void clickErrorBtn()
        {
            errorBtn.Click();
        }

        public string getErrorMsg()
        {
            return errorMsg.Text;
        }

        public void enterUsernameAndPassword(String username, String password)
        {
            enterUserName(username);
            enterPassword(password);
        }

        public void loginToECommerceSite(String username, String password)
        {
            enterUserName(username);
            enterPassword(password);
            clickLoginBtn();
        }



    }
}
