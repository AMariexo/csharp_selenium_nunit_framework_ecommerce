using System;
using ECommerceApp.Base;
using ECommerceApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ECommerceApp.Tests
{
    public class LoginTests : BaseDriver
    {
        private LoginPage login;
        private ProductsPage products;

        [SetUp]
        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void LoginSuccessfully()
        {
            login = new LoginPage(driver);
            products = new ProductsPage(driver);
            login.loginToECommerceSite("standard_user", "secret_sauce");
            Assert.AreEqual("Products", products.getProductTitle());
        }

        [Test]
        public void RequiredUsername()
        {
            login = new LoginPage(driver);
            login.enterUserName("");
            login.enterPassword("secret_sauce");
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Username is required", login.getErrorMsg());
       }

        [Test]
        public void RequiredPassword()
        {
            login = new LoginPage(driver);
            login.enterUserName("standard_user");
            login.enterPassword("");
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Password is required", login.getErrorMsg());
        }

        [Test]
        public void RequiredUsernameAndPassword()
        {
            login = new LoginPage(driver);
            login.enterUserName("");
            login.enterPassword("");
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Username is required", login.getErrorMsg());
        }

        [Test]
        public void InvalidUseranme()
        {
            login = new LoginPage(driver);
            login.enterUserName("standard_user");
            login.enterPassword("asdadasdasd");
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.getErrorMsg());
        }

        [Test]
        public void SpecialCharactersUsername()
        {
            login = new LoginPage(driver);
            login.enterUserName("standard_u$er@!");
            login.enterPassword("secret_sauce");
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.getErrorMsg());
        }

        [Test]
        public void InvalidPassword()
        {
            login = new LoginPage(driver);
            login.enterUserName("asdadasdasd");
            login.enterPassword("secret_sauce");
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.getErrorMsg());
        }

        [Test]
        public void ClearError()
        {
            login = new LoginPage(driver);
            login.clickLoginBtn();
            Thread.Sleep(3000);
            Assert.AreEqual("Epic sadface: Username is required", login.getErrorMsg());
            login.clickErrorBtn();
        }

    }
}
