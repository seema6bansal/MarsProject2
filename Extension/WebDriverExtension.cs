using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject3.Extension
{
    public static class WebDriverExtension
    {
        private static WebDriverWait wait;


        //Explicit wait for element by passing "IWebElement"    
        public static bool WaitForElementIsVisible(this IWebDriver driver, IWebElement element, int timeOutinSeconds = 20)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until<bool>(d =>
                {
                    try
                    {
                        return element.Displayed;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //Explicit Wait for Element by passing "By"
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
        public static IList<IWebElement> WaitForListOfElements(this IWebDriver driver, By by, int timeOutinSeconds = 40)
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

        //Explicit wait for Url      
        public static bool WaitForUrl(this IWebDriver driver, string url, int timeOutinSeconds = 20)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until<bool>(d =>
                {
                    try
                    {
                        return driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant());
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //Func delegate to check visibility of all the elements              
        public static Func<IWebDriver, IList<IWebElement>> VisibilityOfAllElements(By by)
        {
            return (driver) =>
            {
                try
                {
                    var elements = driver.FindElements(by);
                    if (elements.Any(element => !element.Displayed))
                    {
                        return null;
                    }

                    return elements.Any() ? elements : null;
                }
                catch (Exception)
                {
                    return null;
                }
            };

        }

        //Explicit Wait for Visibility of all the elements by using Func delegate
        public static IList<IWebElement> WaitForVisibilityOfAllElements(this IWebDriver driver, By by, int timeOutinSeconds = 60)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(VisibilityOfAllElements(by));

            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
