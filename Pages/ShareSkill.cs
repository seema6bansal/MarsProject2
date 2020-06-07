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

namespace MarsProject2.Pages
{
    class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);

        }

        //Initialize Web Elements by using Page Factory

        //Find the Title Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement titleTextBox { get; set; }

        //Find the Description Textbox
        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")]
        private IWebElement descriptionTextBox { get; set; }

        //Find the Category Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        private IWebElement categoryDropDown { get; set; }

        //Find the SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement subCategoryDropDown { get; set; }

        //Find the Tag Textbox
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[1]")]
        private IWebElement tagTextBox { get; set; }

        //Find the ServiceType
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType']")]
        private IList<IWebElement> serviceType { get; set; }

        //Find the ServiceType label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='serviceType']//parent::div//label")]
        private IList<IWebElement> serviceTypeLabel { get; set; }

        //Find the LocationType
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType']")]
        private IList<IWebElement> locationType { get; set; }

        //Find the LocationType Label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='locationType']//parent::div//label")]
        private IList<IWebElement> locationTypeLabel { get; set; }

        //Find the StartDate Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        private IWebElement startDate { get; set; }

        //Find the EndDate Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        private IWebElement endDate { get; set; }

        //Find avaialable Days Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='Available']")]
        private IList<IWebElement> daysCheckBox { get; set; }

        //Find avaialable Days label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='Available']//parent::div//label")]
        private IList<IWebElement> daysLabel { get; set; }

        //Find the StartTime Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime']")]
        private IList<IWebElement> startTime { get; set; }

        //Find the EndTime Dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime']")]
        private IList<IWebElement> endTime { get; set; }

        //Find the SkillTrade checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades']")]
        private IList<IWebElement> skillTrade { get; set; }

        //Find the SkillTrade checkbox label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='skillTrades']//parent::div//label")]
        private IList<IWebElement> skillTradeLabel { get; set; }

        //Find the SkillExchange TextBox
        [FindsBy(How = How.XPath, Using = "(//input[@class='ReactTags__tagInputField'])[2]")]
        private IWebElement skillExchange { get; set; }

        //Find the WorkSamples
        [FindsBy(How = How.XPath, Using = "//div/span/i[@class='huge plus circle icon padding-25']")]
        private IWebElement workSamples { get; set; }

        //Find the Active checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive']")]
        private IList<IWebElement> active { get; set; }

        //Find the Active checkbox label
        [FindsBy(How = How.XPath, Using = "//div/input[@name='isActive']//parent::div//label")]
        private IList<IWebElement> activeLabel { get; set; }

        //Find the Save Button
        [FindsBy(How = How.XPath, Using = "//input[@type='button' and @value='Save']")]
        private IWebElement saveButton { get; set; }


        //ServiceType selection based on Excel Data
        public void ServiceTypeSelection()
        {
            int size = serviceType.Count;

            for (int i = 0; i < size; i++)
            {
                string serviceTypeText = serviceTypeLabel.ElementAt(i).Text;
                if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType").Equals(serviceTypeText))
                {
                    serviceType.ElementAt(i).Click();
                    break;
                }

            }

        }

        //LocationType selection based on Excel Data
        public void LocationTypeSelection()
        {
            int size = locationType.Count;

            for (int i = 0; i < size; i++)
            {
                string locationTypeText = locationTypeLabel.ElementAt(i).Text;
                if (GlobalDefinitions.ExcelLib.ReadData(2, "LocationType").Equals(locationTypeText))
                {
                    locationType.ElementAt(i).Click();
                    break;
                }

            }

        }

        //Available days selection and enter StartTime and EndTime based on Excel Data
        public void AvailableDaysSelection()
        {
            int size = daysCheckBox.Count;
            for (int i = 0; i < size; i++)
            {
                string dayText = daysLabel.ElementAt(i).Text;
                if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectDay").Equals(dayText))
                {
                    daysCheckBox.ElementAt(i).Click();
                    
                    string startTimeData = GlobalDefinitions.ExcelLib.ReadData(2, "StartTime");
                    DateTime dtStartTime = DateTime.Parse(startTimeData);
                    startTime.ElementAt(i).SendKeys(dtStartTime.ToLongTimeString().ToString());
                                       
                    string endTimeData = GlobalDefinitions.ExcelLib.ReadData(2, "EndTime");
                    DateTime dtEndTime = DateTime.Parse(endTimeData);
                    endTime.ElementAt(i).SendKeys(dtEndTime.ToLongTimeString().ToString());
                    break;
                }

            }

        }

        //SkillTrade selection based on Excel Data
        public void SkillTradeSelection()
        {
            int size = skillTrade.Count;
            for (int i = 0; i < size; i++)
            {
                string skillTradeText = skillTradeLabel.ElementAt(i).Text;
                if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade").Equals(skillTradeText))
                {
                    skillTrade.ElementAt(i).Click();
                    break;
                }

            }
        }

        //Active selection based on Excel Data
        public void ActiveSelection()
        {
            int size = active.Count;
            for (int i = 0; i < size; i++)
            {
                string activeText = activeLabel.ElementAt(i).Text;
                if (GlobalDefinitions.ExcelLib.ReadData(2, "Active").Equals(activeText))
                {
                    active.ElementAt(i).Click();
                    break;
                }

            }
        }

        //AutoIT implementation to upload WorkSamples file which is not supported by Selenium
        public void FileUploadAutoIT()
        {
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinWaitActive("Open", "", 60);
            autoIt.AutoItSetOption("SendKeyDelay", 10);
            autoIt.Send(Base.uploadFile);
            autoIt.AutoItSetOption("SendKeyDelay", 10);
            autoIt.Send("{ENTER}");
        }

        public void PopulateShareSkillAddData()
        {
            //Populate ShareSkill Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "ShareSkill");
        }

        public void PopulateShareSkillUpdateData()
        {
            //Populate Update ManageListings Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateManageListings");
        }

        public void AddShareSkillDetails()
        {
            //Enter Title data from Excel
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//input[@name='title']")), 10).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description data from Excel
            descriptionTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category based on Excel data
            SelectElement categorySelect = new SelectElement(GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, (By.XPath("//select[@name='categoryId']")), 10));
            categorySelect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select Subcategory based on Excel data
            SelectElement subCategorySelect = new SelectElement(subCategoryDropDown);
            subCategorySelect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter Text in Tag and perform keyboard action "Enter"
            tagTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + Keys.Enter);

            //Select Service Type based on Excel data
            ServiceTypeSelection();

            //Select Location Type based on Excel data
            LocationTypeSelection();

            //Enter Startdate based on Excel data
            startDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));

            //Enter Enddate based on Excel data
            endDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

            //Select days based on excel data and enter start and end time
            AvailableDaysSelection();

            //Select SkillTrade based on Excel data
            SkillTradeSelection();

            //Enter Text in Tag and perform keyboard action "Enter"
            skillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange") + Keys.Enter);

            //Click WorkSample and upload the file through AutoIT
            workSamples.Click();
            FileUploadAutoIT();

            //Select Active/Hidden based on Excel data
            ActiveSelection();

            //Save ShareSkill data
            saveButton.Click();
        }

        //Get Excel Title 
        public string excelTitle()
        {
            return (GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        }

        //Get ShareSkill Url
        public string ShareSkillUrl()
        {
            GlobalDefinitions.WaitForUrl(GlobalDefinitions.driver, Base.expectedShareSkillUrl, 10);
            return (GlobalDefinitions.driver.Url);

        }

    }
}
