using MarsProject3.Global;
using MarsProject3.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MarsProject3.Pages
{
    class ManageListings
    {
        public static string expectedManageListingsUrl = "http://192.168.99.100:5000/Home/ListingManagement";
        private readonly IWebDriver driver;

        public ManageListings()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
            this.driver = GlobalDefinitions.driver;
        }


        //Initialize WebElements by using Page Factory

        //Find the ManageListingTitle
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[3]")]
        private IWebElement ManageListingTitle { get; set; }

        //Find the PopUp
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PopUpMessage { get; set; }


        //Get Title of the row on the ManageListing Page
        public string GetTitle()
        {
            driver.WaitForElementIsVisible(ManageListingTitle);
            return ManageListingTitle.Text;
        }

        //Update Service Listing on the Manage Listings Page
        public void UpdateServiceListings(string updateTitle)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements((By.XPath("//table[@class='ui striped table']/tbody/tr")));

            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string titleValue = null;
                titleValue = (driver.WaitForElement(By.XPath("//table/tbody/tr[" + rnum + "]/td[3]"))).Text;
                if (titleValue == updateTitle)
                {
                    driver.WaitForElement(By.XPath("//table/tbody/tr[" + rnum + "]/td[8]/div/button[2]/i[@class='outline write icon']")).Click();
                    break;
                }
            }

        }

        //Delete Service Listing on the Manage Listings Page
        public void DeleteServiceListings(string deleteTitle)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("//table[@class='ui striped table']/tbody/tr"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string titleValue = null;
                titleValue = (driver.WaitForElement(By.XPath("//table/tbody/tr[" + rnum + "]/td[3]"))).Text;
                if (titleValue == deleteTitle)
                {
                    driver.WaitForElement(By.XPath("//table/tbody/tr[" + rnum + "]/td[8]/div/button[3]/i[@class='remove icon']")).Click();

                    driver.WaitForElement(By.XPath("//div[@class='actions']/button[2]/i[@class='checkmark icon']")).Click();
                    break;
                }

            }
        }


        //Find out Popup Message for Delete
        public string GetPopUpMsg()
        {
            driver.WaitForElementIsVisible(PopUpMessage);
            return PopUpMessage.Text;
        }

        //Get Manage Listings Url
        public string GetManageListingsUrl()
        {
            driver.WaitForUrl(expectedManageListingsUrl);
            return (GlobalDefinitions.driver.Url);

        }

    }
}
