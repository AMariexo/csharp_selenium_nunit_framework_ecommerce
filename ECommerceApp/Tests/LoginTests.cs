﻿using System;
using ECommerceApp.Base;
using ECommerceApp.Pages;
using ECommerceApp.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ECommerceApp.Tests
{
    public class LoginTests : BaseDriver
    {
        private LoginPage login;
        private ProductsPage products;
        private LoginData returnTestData;

        [SetUp]
        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public async Task LoginSuccessfully()
        {
            login = new LoginPage(driver);
            products = new ProductsPage(driver);
            returnTestData = await ReturnTestData.GetLoginDataAsync();
            login.loginToECommerceSite(returnTestData.Username, returnTestData.Password);
            Assert.AreEqual("Products", products.getProductTitle());
        }

        [Test]
        public void RequiredUsername()
        {
            login = new LoginPage(driver);
            login.enterUserName("");
            login.enterPassword(returnTestData.Password);
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Username is required", login.getErrorMsg());
       }

        [Test]
        public void RequiredPassword()
        {
            login = new LoginPage(driver);
            login.enterUserName(returnTestData.Username);
            login.enterPassword("");
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Password is required", login.getErrorMsg());
        }

        [Test]
        public void RequiredUsernameAndPassword()
        {
            login = new LoginPage(driver);
            login.enterUserName("");
            login.enterPassword("");
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Username is required", login.getErrorMsg());
        }

        [Test]
        public void InvalidUseranme()
        {
            login = new LoginPage(driver);
            login.enterUserName("standard_user");
            login.enterPassword("asdadasdasd");
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.getErrorMsg());
        }

        [Test]
        public void SpecialCharactersUsername()
        {
            login = new LoginPage(driver);
            login.enterUserName("standard_u$er@!");
            login.enterPassword("secret_sauce");
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.getErrorMsg());
        }

        [Test]
        public void InvalidPassword()
        {
            login = new LoginPage(driver);
            login.enterUserName("asdadasdasd");
            login.enterPassword("secret_sauce");
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.getErrorMsg());
        }

        [Test]
        public void ClearError()
        {
            login = new LoginPage(driver);
            login.clickLoginBtn();
            Thread.Sleep(1000);
            Assert.AreEqual("Epic sadface: Username is required", login.getErrorMsg());
            login.clickErrorBtn();
            Assert.IsFalse(login.isErrorMsgDisplayed());
            
        }

    }
}
