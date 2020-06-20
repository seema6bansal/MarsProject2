using MarsProject3.Global;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsProject3.Extension;

namespace MarsProject3.Pages
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

        //Find Edit Availability icon
        [FindsBy(How = How.XPath, Using = "(//div[@class='ui list']//i[@class ='right floated outline small write icon'])[1]")]
        private IWebElement EditAvailability { get; set; }

        //Find Availability dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyType']")]
        private IWebElement AvailabilityDropDown { get; set; }

        //Find Edit Hours icon
        [FindsBy(How = How.XPath, Using = "(//div[@class='ui list']//i[@class ='right floated outline small write icon'])[2]")]
        private IWebElement EditHours { get; set; }

        //Find Hours dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyHour']")]
        private IWebElement HoursDropDown { get; set; }

        //Find Edit Earn Target icon
        [FindsBy(How = How.XPath, Using = "(//div[@class='ui list']//i[@class ='right floated outline small write icon'])[3]")]
        private IWebElement EditEarnTarget { get; set; }

        //Find Earn Target dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyTarget']")]
        private IWebElement EarnTargetDropDown { get; set; }

        //Find Edit Description icon
        [FindsBy(How = How.XPath, Using = "//div[@class='content']//i[@class = 'outline write icon']")]
        private IWebElement EditDescription { get; set; }

        //Find Description Textbox
        [FindsBy(How = How.XPath, Using = "//div[@class='field  ']//textarea[@name='value']")]
        private IWebElement Description { get; set; }

        //Find Save button
        [FindsBy(How = How.XPath, Using = "(//button[contains(text(), 'Save')])[2]")]
        private IWebElement SaveButton { get; set; }

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
