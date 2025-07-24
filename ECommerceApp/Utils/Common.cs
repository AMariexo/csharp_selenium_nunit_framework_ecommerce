using ECommerceApp.Base;
using OpenQA.Selenium;
using System;


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

    }
}
