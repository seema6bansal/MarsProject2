using MarsProject2.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MarsProject2.Pages
{
    class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        //Initialize WebElements by using Page Factory

        //Find the ManageListingTitle
        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[3]")]
        private IWebElement ManageListingTitle { get; set; }

        //Find the PopUp
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PopUpMessage { get; set; }

        public string deleteTitleMsg;


        //Get Title of the row on the ManageListing Page
        public string GetTitle()
        {
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver, GlobalDefinitions.ElementIsVisible(ManageListingTitle), 15);
            return ManageListingTitle.Text;
        }

        //Update Service Listing on the Manage Listings Page
        public void UpdateServiceListings()
        {
            //Populate ShareSkill Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateManageListings");

            if (GlobalDefinitions.ExcelLib.ReadData(2, "UpdateAction").Equals("Yes"))
            {
                string UpdateTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                IList<IWebElement> rows = GlobalDefinitions.WaitForListOfElements(GlobalDefinitions.driver, (By.XPath("//table[@class='ui striped table']/tbody/tr")), 10);

                for (int rnum = 1; rnum <= rows.Count; rnum++)
                {
                    string titleValue = null;
                    titleValue = (GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//table/tbody/tr[" + rnum + "]/td[3]")), 15)).Text;
                    if (titleValue == UpdateTitle)
                    {
                        GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//table/tbody/tr[" + rnum + "]/td[8]/div/button[2]/i[@class='outline write icon']")), 15).Click();
                        break;
                    }
                }

            }
        }

        //Delete Service Listing on the Manage Listings Page
        public void DeleteServiceListings()
        {
            //Populate ShareSkill Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "DeleteManageListings");

            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                string deleteTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

                deleteTitleMsg = deleteTitle;
                IList<IWebElement> rows = GlobalDefinitions.WaitForListOfElements(GlobalDefinitions.driver, (By.XPath("//table[@class='ui striped table']/tbody/tr")), 10);

                for (int rnum = 1; rnum <= rows.Count; rnum++)
                {
                    string titleValue = null;
                    titleValue = (GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//table/tbody/tr[" + rnum + "]/td[3]")), 15)).Text;
                    if (titleValue == deleteTitle)
                    {
                        GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//table/tbody/tr[" + rnum + "]/td[8]/div/button[3]/i[@class='remove icon']")), 15).Click();

                        GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//div[@class='actions']/button[2]/i[@class='checkmark icon']")), 15).Click();
                        break;
                    }

                }

            }
        }


        //Find out Popup Message for Delete
        public string GetPopUpMsg()
        {
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver, GlobalDefinitions.ElementIsVisible(PopUpMessage), 30);
            return PopUpMessage.Text;
        }

        //Get Manage Listings Url
        public string GetManageListingsUrl()
        {
            GlobalDefinitions.WaitForUrl(GlobalDefinitions.driver, Base.expectedManageListingsUrl, 10);
            return (GlobalDefinitions.driver.Url);

        }

    }
}
