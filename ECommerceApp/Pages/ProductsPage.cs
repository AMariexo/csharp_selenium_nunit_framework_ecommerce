using OpenQA.Selenium;
using System;


namespace ECommerceApp.Pages
{
    public class ProductsPage
    {
        public IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement productTitle => driver.FindElement(By.ClassName("title"));

        public string getProductTitle()
        {
            return productTitle.Text;
        }
    }
}
