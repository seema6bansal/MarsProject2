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
        public void SelectAvailableDays()
        {
            int size = DaysCheckBox.Count;
            for (int i = 0; i < size; i++)
            {
                string dayText = DaysLabel.ElementAt(i).Text;
                if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectDay").Equals(dayText))
                {
                    DaysCheckBox.ElementAt(i).Click();
                    
                    string startTimeData = GlobalDefinitions.ExcelLib.ReadData(2, "StartTime");
                    DateTime dtStartTime = DateTime.Parse(startTimeData);
                    StartTime.ElementAt(i).SendKeys(dtStartTime.ToLongTimeString().ToString());
                                       
                    string endTimeData = GlobalDefinitions.ExcelLib.ReadData(2, "EndTime");
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
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver, GlobalDefinitions.ElementIsVisible(TitleTextBox), 20);
            TitleTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description data from Excel
            DescriptionTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category based on Excel data
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver,GlobalDefinitions.ElementIsVisible(CategoryDropDown),10);
            SelectElement categorySelect = new SelectElement(CategoryDropDown);
            categorySelect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select Subcategory based on Excel data
            SelectElement subCategorySelect = new SelectElement(SubCategoryDropDown);
            subCategorySelect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter Text in Tag and perform keyboard action "Enter"
            TagTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + Keys.Enter);

            //Select Service Type based on Excel data
            SelectRadioButton(ServiceType, ServiceTypeLabel, GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));

            //Select Location Type based on Excel data
            SelectRadioButton(LocationType, LocationTypeLabel, GlobalDefinitions.ExcelLib.ReadData(2, "LocationType"));

            //Enter Startdate based on Excel data
            StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));

            //Enter Enddate based on Excel data
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

            //Select days based on excel data and enter start and end time
            SelectAvailableDays();

            //Select SkillTrade based on Excel data
            SelectRadioButton(SkillTrade, SkillTradeLabel, GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));

            //Enter Text in Tag and perform keyboard action "Enter"
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange") + Keys.Enter);

            //Click WorkSample and upload the file through AutoIT
            GlobalDefinitions.WaitForElementIsVisible(GlobalDefinitions.driver, GlobalDefinitions.ElementIsVisible(WorkSamples), 10);
            WorkSamples.Click();
            UploadFileByAutoIT();

            //Select Active/Hidden based on Excel data
            SelectRadioButton(Active, ActiveLabel, GlobalDefinitions.ExcelLib.ReadData(2, "Active"));

            //Save ShareSkill data
            SaveButton.Click();
        }

        //Get Excel Title 
        public string GetExcelTitle()
        {
            return (GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        }

        //Get ShareSkill Url
        public string GetShareSkillUrl()
        {
            GlobalDefinitions.WaitForUrl(GlobalDefinitions.driver, Base.expectedShareSkillUrl, 10);
            return (GlobalDefinitions.driver.Url);

        }

    }
}
