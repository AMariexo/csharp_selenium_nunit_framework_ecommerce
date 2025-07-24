using ECommerceApp.Utils;
using OpenQA.Selenium;
using System;
using System.Runtime.CompilerServices;


namespace ECommerceApp.Pages
{
    public class ProductsPage
    {
        public IWebDriver driver;
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //title of sub page
        private IWebElement productTitle => driver.FindElement(By.ClassName("title"));

        //inventory item card
        private List<IWebElement> inventoryItems => driver.FindElements(By.XPath("//div[@class='inventory_item']")).ToList();

        //inventory card -> inventory item name, description, image and price
        private List<IWebElement> inventoryNames => driver.FindElements(By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_name ']")).ToList();
        private List<IWebElement> inventoryDescriptions => driver.FindElements(By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_desc']")).ToList();
        private List<IWebElement> inventoryImages => driver.FindElements(By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_img']")).ToList();
        private List<IWebElement> inventoryPrices => driver.FindElements(By.XPath("//div[@class='inventory_item']//div[@class='inventory_item_price']")).ToList();

        //add to cart buttons
        private List<IWebElement> addToCartBtns => driver.FindElements(By.XPath("//button[text()='Add to cart']")).ToList();

        //price of the selected items by the user
        private List<IWebElement> priceOfSelectedItems => driver.FindElements(By.XPath("//button[text()='Remove']/parent::div/child::div")).ToList();

        //button to go to shopping cart page
        private IWebElement shoppingCart => driver.FindElement(By.ClassName("shopping_cart_link"));

        //badge displayed when user adds item to cart
        private IWebElement shoppingCartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));

        //product sort drop down
        private IWebElement productSortDropDown => driver.FindElement(By.ClassName("product_sort_container"));



        
        public void clickAddToCart(int itemIndex)
        {
            addToCartBtns[itemIndex].Click();
        }

        public string totalPriceOfSelectedItems()
        {
            double total = 0;
            for (int i = 0; i < priceOfSelectedItems.Count; i++)
            {
                String priceWithoutDollarSign = priceOfSelectedItems[i].Text.TrimStart('$');
                Console.WriteLine(priceWithoutDollarSign);
                total += double.Parse(priceWithoutDollarSign);
            }
            string withDollarSign = "$" + total.ToString();
            return withDollarSign;
        }

        public int totalCountOfItems()
        {
            return inventoryItems.Count;
        }

        //verify that all cards are displayed
        public bool productCardsDisplayed()
        {
            return Common.isTotalNumberOfElementsDisplayed(inventoryItems,totalCountOfItems());
        }

        //product name is within product card
        public bool productNameDisplayedOnCard()
        {
            return Common.isTotalNumberOfElementsDisplayed(inventoryNames, totalCountOfItems());
        }
        //product description is within product card
        public bool productDescDisplayedOnCard()
        {
            return Common.isTotalNumberOfElementsDisplayed(inventoryDescriptions, totalCountOfItems());
        }
        //product image is within product card
        public bool productImageDisplayedOnCard()
        {
            return Common.isTotalNumberOfElementsDisplayed(inventoryImages, totalCountOfItems());
        }
        //product price is within product card
        public bool productPriceDisplayedOnCard()
        {
            return Common.isTotalNumberOfElementsDisplayed(inventoryPrices, totalCountOfItems());
        }

        //click product sort drop down
        public void clickProductSortDropDown()
        {
            productSortDropDown.Click();
        }

        //return product sort displayed
        public bool productSortDisplayed()
        {
            return productSortDropDown.Displayed;
        }






        public string getProductTitle()
        {
            return productTitle.Text;
        }
    }
}
