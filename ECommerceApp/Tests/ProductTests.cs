using ECommerceApp.Pages;
using ECommerceApp.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Tests
{
    public class ProductTests : Base.BaseDriver
    {

        private LoginPage login;
        private ProductsPage products;
        private LoginData returnTestData;

        [SetUp]
        public void SetupAndLogin ()
        {
            login = new LoginPage(driver);
            products = new ProductsPage(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //returnTestData = await ReturnTestData.GetLoginDataAsync();
            login.loginToECommerceSite("standard_user", "secret_sauce");
        }


        [Test]
        public void AllProductsAreDisplayed()
        {
            Assert.IsTrue(products.productCardsDisplayed());
        }

        [Test]
        public void ProductCardsContainDetails()
        {
            //item name
            Assert.IsTrue(products.productNameDisplayedOnCard());
            //item description
            Assert.IsTrue(products.productDescDisplayedOnCard());
            //item image
            Assert.IsTrue(products.productImageDisplayedOnCard());
            //item price
            Assert.IsTrue(products.productPriceDisplayedOnCard());
        }

    }
}
