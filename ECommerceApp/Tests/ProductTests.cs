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
        public async Task SetupAndLogin ()
        {
            login = new LoginPage(driver);
            products = new ProductsPage(driver);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //returnTestData = await ReturnTestData.GetLoginDataAsync();
            //login.loginToECommerceSite(returnTestData.Username, returnTestData.Password);
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

        [Test]
        public void ClickAndSelectProductSortInAsenOrder()
        {
            products.clickProductSortDropDown();
            products.selectProductSortOptions("Name (A to Z)");
            Assert.IsTrue(products.isProductsSorted(false, false), "Sorting verification failed - products not sorted in A - Z");
        }

        [Test]
        public void ClickAndSelectProductSortInDescOrder()
        {
            products.clickProductSortDropDown();
            products.selectProductSortOptions("Name (Z to A)");
            Assert.IsTrue(products.isProductsSorted(true, false), "Sorting verification failed - products not sorted by Z - A");
        }

        [Test]
        public void ClickAndSelectProductPriceInDescOrder()
        {
            products.clickProductSortDropDown();
            products.selectProductSortOptions("Price (high to low)");
            Assert.IsTrue(products.isProductsSortedByPrice(true, true), "Sorting verification failed - products not sorted by Price (low to high)");
        }

        [Test]
        public void ClickAndSelectProductPriceInAsenOrder()
        {
            products.clickProductSortDropDown();
            products.selectProductSortOptions("Price (low to high)");
            Assert.IsTrue(products.isProductsSortedByPrice(false, true), "Sorting verification failed - products not sorted by Price (high to low)");
        }

        [Test]
        public void AddProductToCart()
        {
            products.clickAddToCart(0);
            Assert.IsTrue(products.isShoppingCartBadgeDisplayed(),"The shopping cart badge is not displayed after adding product to cart");
            Assert.IsTrue(products.isShoppingCartCount(1), "The shopping cart count is not updated after adding product to cart");
        }

        [Test]
        public void RemoveProductFromCart()
        {
            products.clickAddToCart(1);
            Assert.IsTrue(products.isShoppingCartBadgeDisplayed(), "The shopping cart badge is not displayed after adding product to cart");
            Assert.IsTrue(products.isShoppingCartCount(1), "The shopping cart count is not updated after adding product to cart");
            products.clickRemoveItem(0);
            Assert.IsFalse(products.isShoppingCartBadgeDisplayed(), "The shopping cart badge is displayed after removing product from cart");
        }

        [TearDown]
        public void afterEachTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            ExtentManager.RecordResultsForEachTest(test, status, message);
        }




    }
}
