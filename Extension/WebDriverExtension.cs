using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject2.Extension
{
    public static class WebDriverExtension
    {
        private static WebDriverWait wait;


        //Func delegate to check if element is visible by passing WebElement                     
        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };

        }

        //Explicit wait for element by using Func delegate       
        public static bool WaitForElementIsVisible(this IWebDriver driver, Func<IWebDriver, bool> ElementIsVisible, int timeOutinSeconds = 20)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(ElementIsVisible);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //Explicit Wait for Element 
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeOutinSeconds = 25)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(x => x.FindElement(by));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //Explicit Wait for List of Elements
        public static IList<IWebElement> WaitForListOfElements(this IWebDriver driver, By by, int timeOutinSeconds = 30)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(x => (x.FindElements(by).Count > 0 ? x.FindElements(by) : null));

            }
            catch (Exception e)
            {
                throw;
            }
        }


        //Func delegate to check the Url                    
        public static Func<IWebDriver, bool> UrlToBe(string url)
        {
            return (driver) =>
            {
                try
                {
                    return driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant());
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        //Explicit wait for Url by using Func delegate       
        public static bool WaitForUrl(this IWebDriver driver, Func<IWebDriver, bool> UrlToBe, int timeOutinSeconds = 20)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(UrlToBe);
            }
            catch (Exception e)
            {
                throw;
            }

        }



    }
}
