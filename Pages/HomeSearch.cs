using MarsProject3.Extension;
using MarsProject3.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsProject3.Pages
{
    class HomeSearch
    {
        private readonly IWebDriver driver;
        public HomeSearch()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
            this.driver = GlobalDefinitions.driver;
        }

        //Initialize WebElements by using Page Factory

        //Find Search icon
        [FindsBy(How = How.XPath, Using = "//div//i[@class = 'search link icon']")]
        private IWebElement SearchIcon { get; set; }

        //Find Result of Search
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Results Per Page :')]//button[1]")]
        private IWebElement SearchResult { get; set; }

        //Find Filter for Search
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui buttons']//button[@class ='ui button']")]
        private IList<IWebElement> ListOfFilters { get; set; }

        //Search Skills by All Categories
        public void SearchByAllCategories()
        {
            //Click on Search icon to get all the available Skills
            driver.WaitForElementIsVisible(SearchIcon);
            SearchIcon.Click();
           
        }

        //Get the Search Result 
        public string GetSearchResult()
        {
            driver.WaitForElementIsVisible(SearchResult);
            return (SearchResult.Text);
        }

        //Search Skills by Category and SubCategory
        public void SearchByCategory(string category, string subCategory)
        {
            IList<IWebElement> ListOfCategories = driver.WaitForVisibilityOfAllElements(By.XPath("//div[@class= 'ui link list']//a[@role = 'listitem']"));
            int size = ListOfCategories.Count;
           
            for (int i = 1; i <= size; i++)
            {
                if (category.Equals(ListOfCategories.ElementAt(i).Text))
                {
                    ListOfCategories.ElementAt(i).Click();

                    //Find SubCategories
                    IList<IWebElement> ListOfSubCategories = driver.WaitForVisibilityOfAllElements(By.XPath("//div[@class= 'ui link list']//a[@role = 'listitem' and @class = 'item subcategory']"));
                    int subSize = ListOfSubCategories.Count;
                    
                    for (int j = 1; j <= subSize; j++)
                    {
                        string subCategoryText = ListOfSubCategories.ElementAt(j).Text.Replace(ListOfSubCategories.ElementAt(j).FindElement(By.XPath("./*")).Text, "");
                        subCategoryText = subCategoryText.Replace("\r\n", "");
                       
                         if (subCategory.Equals(subCategoryText))
                         {
                              ListOfSubCategories.ElementAt(j).Click();
                              break;
                         }
                    }
                   break;
                }
            }
        }

        //Serach Skiils by Filter
        public void SearchByFilter(string filter)
        {
            int size = ListOfFilters.Count;
            for (int i = 1; i <= size; i++)
            {
                if (filter.Equals(ListOfFilters.ElementAt(i).Text))
                {
                    ListOfFilters.ElementAt(i).Click();
                    break;
                }

            }
        }
    }
}
