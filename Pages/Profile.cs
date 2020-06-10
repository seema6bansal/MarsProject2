using MarsProject2.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsProject2.Pages
{
    class Profile
    {
        public Profile()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
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
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver, GlobalDefinitions.ElementIsVisible(ShareSkillLink), 15);
            ShareSkillLink.Click();
        }

        //Click on ManageListings tab to navigate to the ManageListings page
        public void ClickOnManageListings()
        {
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver, GlobalDefinitions.ElementIsVisible(ManageListingsLink), 15);
            ManageListingsLink.Click();
        }


    }
}
