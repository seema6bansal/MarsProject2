using MarsProject2.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using MarsProject2.Extension;
using MarsProject2.TestData;

namespace MarsProject2.Pages
{
    class ShareSkill
    {
        public static string expectedShareSkillUrl = "http://192.168.99.100:5000/Home/ServiceListing";
        private readonly IWebDriver driver;

        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
            this.driver = GlobalDefinitions.driver;

        }

        //Initialize Web Elements by using Page Factory

        //Find the Title Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement TitleTextBox { get; set; }

        //Find the Description Textbox
        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")]
        private IWebElement DescriptionTextBox { get; set; }

        //Find the Category Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        private IWebElement CategoryDropDown { get; set; }

        //Find the SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Find the Tag Textbox
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[1]")]
        private IWebElement TagTextBox { get; set; }

        //Find the ServiceType
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']")]
        private IList<IWebElement> ServiceType { get; set; }

        //Find the ServiceType label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='serviceType']//parent::div//label")]
        private IList<IWebElement> ServiceTypeLabel { get; set; }

        //Find the LocationType
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType']")]
        private IList<IWebElement> LocationType { get; set; }

        //Find the LocationType Label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='locationType']//parent::div//label")]
        private IList<IWebElement> LocationTypeLabel { get; set; }

        //Find the StartDate Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        private IWebElement StartDate { get; set; }

        //Find the EndDate Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        private IWebElement EndDate { get; set; }

        //Find avaialable Days Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='Available']")]
        private IList<IWebElement> DaysCheckBox { get; set; }

        //Find avaialable Days label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='Available']//parent::div//label")]
        private IList<IWebElement> DaysLabel { get; set; }

        //Find the StartTime Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime']")]
        private IList<IWebElement> StartTime { get; set; }

        //Find the EndTime Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime']")]
        private IList<IWebElement> EndTime { get; set; }

        //Find the SkillTrade checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades']")]
        private IList<IWebElement> SkillTrade { get; set; }

        //Find the SkillTrade checkbox label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='skillTrades']//parent::div//label")]
        private IList<IWebElement> SkillTradeLabel { get; set; }

        //Find the SkillExchange TextBox
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[2]")]
        private IWebElement SkillExchange { get; set; }

        //Find the WorkSamples
        [FindsBy(How = How.XPath, Using = "//div/span/i[@class='huge plus circle icon padding-25']")]
        private IWebElement WorkSamples { get; set; }

        //Find the Active checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']")]
        private IList<IWebElement> Active { get; set; }

        //Find the Active checkbox label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='isActive']//parent::div//label")]
        private IList<IWebElement> ActiveLabel { get; set; }

        //Find the Save Button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Save']")]
        private IWebElement SaveButton { get; set; }


        //Select Radio button based on Excel Data
        public void SelectRadioButton(IList<IWebElement> radioButton, IList<IWebElement> radioButtonLabel, string excelData)
        {
            int size = radioButton.Count;
            for (int i = 0; i < size; i++)
            {
                string labelText = radioButtonLabel.ElementAt(i).Text;
                if (excelData.Equals(labelText))
                {
                    radioButton.ElementAt(i).Click();
                    break;
                }

            }
        }

        //Select Available days and enter StartTime and EndTime based on Excel Data
        public void SelectAvailableDays(string selectDay, string startTime, string endTime)
        {
            int size = DaysCheckBox.Count;
            for (int i = 0; i < size; i++)
            {
                string dayText = DaysLabel.ElementAt(i).Text;
                if ((selectDay).Equals(dayText))
                {
                    DaysCheckBox.ElementAt(i).Click();

                    string startTimeData = startTime;
                    DateTime dtStartTime = DateTime.Parse(startTimeData);
                    StartTime.ElementAt(i).SendKeys(dtStartTime.ToLongTimeString().ToString());

                    string endTimeData = endTime;
                    DateTime dtEndTime = DateTime.Parse(endTimeData);
                    EndTime.ElementAt(i).SendKeys(dtEndTime.ToLongTimeString().ToString());
                    break;
                }

            }

        }

        //AutoIT implementation to upload WorkSamples file which is not supported by Selenium
        public void UploadFileByAutoIT()
        {
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinWaitActive("Open", "", 60);
            autoIt.AutoItSetOption("SendKeyDelay", 10);
            autoIt.Send(Base.uploadFile);
            autoIt.AutoItSetOption("SendKeyDelay", 10);
            autoIt.Send("{ENTER}");
        }


        public void AddShareSkillDetails(ShareSkillDetails skillObj)
        {
            //Enter Title data from Excel
            driver.WaitForElementIsVisible(TitleTextBox);
            TitleTextBox.SendKeys(skillObj.Title);

            //Enter Description data from Excel
            DescriptionTextBox.SendKeys(skillObj.Description);

            //Select Category based on Excel data
            driver.WaitForElementIsVisible(CategoryDropDown);
            SelectElement categorySelect = new SelectElement(CategoryDropDown);
            categorySelect.SelectByText(skillObj.Category);

            //Select Subcategory based on Excel data
            SelectElement subCategorySelect = new SelectElement(SubCategoryDropDown);
            subCategorySelect.SelectByText(skillObj.SubCategory);

            //Enter Text in Tag and perform keyboard action "Enter"
            TagTextBox.SendKeys(skillObj.Tags + Keys.Enter);

            //Select Service Type based on Excel data
            SelectRadioButton(ServiceType, ServiceTypeLabel, skillObj.ServiceType);

            //Select Location Type based on Excel data
            SelectRadioButton(LocationType, LocationTypeLabel, skillObj.LocationType);

            //Enter Startdate based on Excel data
            StartDate.SendKeys(skillObj.StartDate);

            //Enter Enddate based on Excel data
            EndDate.SendKeys(skillObj.EndDate);

            //Select days based on excel data and enter start and end time
            SelectAvailableDays(skillObj.SelectDay, skillObj.StartTime, skillObj.EndTime);

            //Select SkillTrade based on Excel data
            SelectRadioButton(SkillTrade, SkillTradeLabel, skillObj.SkillTrade);

            //Enter Text in Tag and perform keyboard action "Enter"
            SkillExchange.SendKeys(skillObj.SkillExchange + Keys.Enter);

            //Click WorkSample and upload the file through AutoIT
            driver.WaitForElementIsVisible(WorkSamples);
            WorkSamples.Click();
            UploadFileByAutoIT();

            //Select Active/Hidden based on Excel data
            SelectRadioButton(Active, ActiveLabel, skillObj.Active);

            //Save ShareSkill data
            SaveButton.Click();
        }

        //Get ShareSkill Url
        public string GetShareSkillUrl()
        {
            driver.WaitForUrl(expectedShareSkillUrl);
            return (GlobalDefinitions.driver.Url);

        }

    }
}
