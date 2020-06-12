using MarsProject2.Global;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsProject2.Extension;

namespace MarsProject2.Pages
{
    class Profile
    {
        private readonly IWebDriver driver;
        public Profile()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
            this.driver = GlobalDefinitions.driver;
        }

        //Initialize WebElements by using Page Factory

        //Find the ShareSkill Link 
        [FindsBy(How = How.XPath, Using = "//a[@href ='/Home/ServiceListing']")]
        private IWebElement ShareSkillLink { get; set; }

        //Find the ManageListings Link 
        [FindsBy(How = How.XPath, Using = "//a[@href ='/Home/ListingManagement']")]
        private IWebElement ManageListingsLink { get; set; }


        //Click on ShareSkill tab to navigate to the ShareSkill page
        public void ClickOnShareSkill()
        {
            driver.WaitForElementIsVisible(ShareSkillLink);
            ShareSkillLink.Click();
        }

        //Click on ManageListings tab to navigate to the ManageListings page
        public void ClickOnManageListings()
        {
            driver.WaitForElementIsVisible(ManageListingsLink);
            ManageListingsLink.Click();
        }


    }
}
