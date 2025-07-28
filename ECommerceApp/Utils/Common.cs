using ECommerceApp.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace ECommerceApp.Utils
{
    public static class Common
    {

        public static bool isTotalNumberOfElementsDisplayed(List<IWebElement> elements, int count)
        {
            int displayCnt = 0;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Displayed)
                {
                    displayCnt += 1;
                }
            }
            if (displayCnt == count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool areElementsSorted(List<string> unsortedList, List<string> sortedList, bool isDesc, bool isPrice)
        {
            //need to verify prices
            List<decimal> unsortedPriceList = new List<decimal>();
            List<decimal> sortedPriceList = new List<decimal>();
            
            if (isPrice == true)
            {
                unsortedPriceList = unsortedList.Select(x => Decimal.Parse(x.Trim('$'))).ToList();
                sortedPriceList = sortedList.Select(x => Decimal.Parse(x.Trim('$'))).ToList();

                //if descending order is true, then take the original list and descend it, else sort the original list by asending order
                if (isDesc == true)
                {
                    unsortedPriceList.Sort((a, b) => b.CompareTo(a));
                }
                else
                {
                    unsortedPriceList.Sort();
                }


                return unsortedPriceList.SequenceEqual(sortedPriceList);
            }
            else
            {
                //if descending order is true, then take the original list and descend it, else sort the original list by asending order
                if (isDesc == true)
                {
                    unsortedList.Sort((a, b) => b.CompareTo(a));
                }
                else
                {
                    unsortedList.Sort();
                }
            }

            //compare both the sorted original list with the products that are sorted by the filter
            return unsortedList.SequenceEqual(sortedList);
        }


        public static IWebElement waitFor(IWebDriver driver, By by, int timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return ele;
        }
    }
}
