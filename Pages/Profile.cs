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
using OpenQA.Selenium.Support.UI;
using MarsProject3.Model;
using OpenQA.Selenium.Interactions;

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

        //Find Save button to save Description
        [FindsBy(How = How.XPath, Using = "(//button[contains(text(), 'Save')])[2]")]
        private IWebElement SaveButton { get; set; }

        //Find User name 
        [FindsBy(How = How.XPath, Using = "//div[@class='ui compact menu']//span[contains(text(), 'Hi ')]")]
        private IWebElement UserNameDropDown { get; set; }

        //Find ChangePassword link 
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Change Password')]")]
        private IWebElement ChangePassword { get; set; }

        //Find Current Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='oldPassword']")]
        private IWebElement CurrentPassword { get; set; }

        //Find New Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='newPassword']")]
        private IWebElement NewPassword { get; set; }

        //Find Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Find Save button to save changed password
        [FindsBy(How = How.XPath, Using = "//button[@class ='ui button ui teal button' and contains(text(),'Save')]")]
        private IWebElement SaveChangedPassword { get; set; }

        //Find Language tab
        [FindsBy(How = How.XPath, Using = "//div//a[@class='item active' and contains(text(), 'Languages')]")]
        private IWebElement LanguageTab { get; set; }

        //Find AddNew button for Language
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[1]")]
        private IWebElement AddNewLanguage { get; set; }

        //Find Language Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Language']")]
        private IWebElement LanguageTextBox { get; set; }

        //Find Level dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='level']")]
        private IWebElement Level { get; set; }

        //Find Add button 
        [FindsBy(How = How.XPath, Using = "//input[@value ='Add']")]
        private IWebElement AddButton { get; set; }

        //Find Skills tab
        [FindsBy(How = How.XPath, Using = "//div//a[@class='item' and contains(text(), 'Skills')]")]
        private IWebElement SkillsTab { get; set; }

        //Find AddNew button for Skill
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[2]")]
        private IWebElement AddNewSkill { get; set; }

        //Find Skill Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        private IWebElement SkillTextBox { get; set; }
                
        //Find Education tab
        [FindsBy(How = How.XPath, Using = "//div//a[@class='item' and contains(text(), 'Education')]")]
        private IWebElement EducationTab { get; set; }

        //Find AddNew button for Education
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[3]")]
        private IWebElement AddNewEducation { get; set; }

        //Find College name Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='instituteName']")]
        private IWebElement CollegeName { get; set; }

        //Find Country of College
        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement CollegeCountry { get; set; }

        //Find Title of Education
        [FindsBy(How = How.XPath, Using = "//select[@name='title']")]
        private IWebElement EducationTitle { get; set; }

        //Find Degree of Education
        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        private IWebElement EducationDegree { get; set; }

        //Find Year of Graduation
        [FindsBy(How = How.XPath, Using = "//select[@name='yearOfGraduation']")]
        private IWebElement EducationYear { get; set; }

        //Find Certifications tab
        [FindsBy(How = How.XPath, Using = "//div//a[@class='item' and contains(text(), 'Certification')]")]
        private IWebElement CertificationTab { get; set; }

        //Find AddNew button for Certification
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[4]")]
        private IWebElement AddNewCertification { get; set; }

        //Find Certificate Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        private IWebElement CertificateTextBox { get; set; }

        //Find CertifiedFrom Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement CertifiedFromTextBox { get; set; }

        //Find Certified Year dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement CertifiedYear { get; set; }

        //Find Update button 
        [FindsBy(How = How.XPath, Using = "//input[@value ='Update']")]
        private IWebElement UpdateButton { get; set; }

        //Find the PopUp
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PopUpMessage { get; set; }

        //Find the PopUp close
        [FindsBy(How = How.XPath, Using = "//a[@class='ns-close']")]
        private IWebElement PopUpClose { get; set; }

        //Find the ShareSkill Link 
        [FindsBy(How = How.XPath, Using = "//a[@href ='/Home/ServiceListing']")]
        private IWebElement ShareSkillLink { get; set; }

        //Find the ManageListings Link 
        [FindsBy(How = How.XPath, Using = "//a[@href ='/Home/ListingManagement']")]
        private IWebElement ManageListingsLink { get; set; }

        //Edit Availability on the Profile page
        public void EditAvailabilityOnProfile(string availability)
        {
            //Click on EditAvailability icon
            driver.WaitForElementIsVisible(EditAvailability);
            EditAvailability.Click();

            //Select Availability based on Excel data
            driver.WaitForElementIsVisible(AvailabilityDropDown);
            SelectElement availabilitySelect = new SelectElement(AvailabilityDropDown);
            availabilitySelect.SelectByText(availability);

        }

        //Edit Hours on the Profile page
        public void EditHoursOnProfile(string hours)
        {
            //Click on EditHours icon
            driver.WaitForElementIsVisible(EditHours);
            EditHours.Click();

            //Select Hours based on Excel data
            driver.WaitForElementIsVisible(HoursDropDown);
            SelectElement hoursSelect = new SelectElement(HoursDropDown);
            hoursSelect.SelectByText(hours);

        }

        //Edit Earn Target on the Profile page
        public void EditEarnTargetOnProfile(string earnTarget)
        {
            //Click on EditEarnTarget icon
            driver.WaitForElementIsVisible(EditEarnTarget);
            EditEarnTarget.Click();

            //Select Earn Target based on Excel data
            driver.WaitForElementIsVisible(EarnTargetDropDown);
            SelectElement earnTargetSelect = new SelectElement(EarnTargetDropDown);
            earnTargetSelect.SelectByText(earnTarget);

        }

        //Edit Earn Target on the Profile page
        public void EditdescriptionOnProfile(string description)
        {
            //Click on EditDescription icon
            driver.WaitForElementIsVisible(EditDescription);
            EditDescription.Click();

            //Enter Description based on Excel data
            Description.Clear();
            Description.SendKeys(description);

            //Click on save button to save the description
            SaveButton.Click();

        }

        //Change Password 
        public void ChangePasswordOnProfile(string oldPassword, string newPassword, string confirmPassword)
        {
            Actions actions = new Actions(driver);
            driver.WaitForElementIsVisible(UserNameDropDown);
            actions.MoveToElement(UserNameDropDown).Build().Perform();
            
            //Click on ChangePassword
            driver.WaitForElementIsVisible(ChangePassword);
            ChangePassword.Click();

            //Enter Current Password
            CurrentPassword.SendKeys(oldPassword);

            //Enter New Password
            NewPassword.SendKeys(newPassword);

            //Enter Confirm Password
            ConfirmPassword.SendKeys(confirmPassword);
            
            //Click on Save Button
            SaveChangedPassword.Click();

        }

        //Click on Language tab 
        public void ClickOnLanguageTab()
        {
            driver.WaitForElementIsVisible(LanguageTab);
            LanguageTab.Click();
        }

        //Add new Language on the Profile page
        public void AddLanguageOnProfile(string language, string level)
        {
            //Click on AddNew button to add new language
            AddNewLanguage.Click();

            //Enter new Language
            LanguageTextBox.SendKeys(language);

            //Select Language level
            SelectElement selectLanguageLevel = new SelectElement(Level);
            selectLanguageLevel.SelectByText(level);

            //Click on Add button to add language data
            AddButton.Click();

        }

        //Click on Skill tab
        public void ClickOnSkillTab()
        {
            driver.WaitForElementIsVisible(SkillsTab);
            SkillsTab.Click();

        }
        
        //Add new Skill on the Profile page
        public void AddSkillOnProfile(string skill, string level)
        {
            //Click on AddNew button 
            AddNewSkill.Click();

            //Enter new Skill
            SkillTextBox.SendKeys(skill);

            //Select Skill level
            SelectElement selectLanguageLevel = new SelectElement(Level);
            selectLanguageLevel.SelectByText(level);

            //Click on Add button to add skill data
            AddButton.Click();
        }

        //Click on Education tab
        public void ClickOnEducationTab()
        {
            driver.WaitForElementIsVisible(EducationTab);
            EducationTab.Click();

        }

        //Add new Education on the Profile page
        public void AddEducationOnProfile(EducationDetails educationObj)
        {
            //Click on AddNew button
            AddNewEducation.Click();

            //Enter Name of College
            driver.WaitForElementIsVisible(CollegeName);
            CollegeName.SendKeys(educationObj.University);

            //Select Country of College
            SelectElement selectCountry = new SelectElement(CollegeCountry);
            selectCountry.SelectByValue(educationObj.Country);

            //Select Title of Education
            SelectElement selectTitle = new SelectElement(EducationTitle);
            selectTitle.SelectByValue(educationObj.Title);

            //Enter Degree of Education
            EducationDegree.SendKeys(educationObj.Degree);

            //Select Year of Graduation
            SelectElement selectYear = new SelectElement(EducationYear);
            selectYear.SelectByValue(educationObj.Year);
                     
            //Click on Add button to add Education data
            AddButton.Click();
        }

        //Click on Certification tab
        public void ClickOnCertificationTab()
        {
            driver.WaitForElementIsVisible(CertificationTab);
            CertificationTab.Click();
        }

        //Add new Certification on the Profile page
        public void AddCertificationOnProfile(string certificate, string from, string year)
        {
            //Click on AddNew button
            AddNewCertification.Click();

            //Enter Certificate name 
            CertificateTextBox.SendKeys(certificate);

            //Enter Certified From
            CertifiedFromTextBox.SendKeys(from);

            //Select Certified year
            SelectElement selectCertifiedYear = new SelectElement(CertifiedYear);
            selectCertifiedYear.SelectByText(year);

            //Click on Add button to add Certificate
            AddButton.Click();

        }

        //Update Language on the Profile page
        public void UpdateLanguageOnProfile(string expectedLanguage, string level)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[1]//tbody/tr/td[1]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string language = null;
                language = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[1]//tbody[" + rnum + "]/tr/td[1]"))).Text;
                if (language == expectedLanguage)
                {
                    //Click on Update icon to update the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[1]//tbody[" + rnum + "]/tr/td[3]/span[1]/i[@class='outline write icon']")).Click();

                    //Update the Level of language
                    SelectElement selectLanguageLevel = new SelectElement(Level);
                    selectLanguageLevel.SelectByValue(level);

                    //Click on Update button to update the Level of language
                    UpdateButton.Click();
                    break;
                }

            }
        }

        //Update Skill on the Profile page
        public void UpdateSkillOnProfile(string expectedSkill, string level)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[2]//tbody/tr/td[1]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string skill = null;
                skill = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[2]//tbody[" + rnum + "]/tr/td[1]"))).Text;
                if (skill == expectedSkill)
                {
                    //Click on Update icon to update the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[2]//tbody[" + rnum + "]/tr/td[3]/span[1]/i[@class='outline write icon']")).Click();

                    //Update the Level of skill
                    SelectElement selectLanguageLevel = new SelectElement(Level);
                    selectLanguageLevel.SelectByValue(level);

                    //Click on Update button to update the Level of skill
                    UpdateButton.Click();
                    break;
                }

            }
        }

        //Update Education on the Profile page
        public void UpdateEducationOnProfile(string expectedEducationTitle, string university, string country)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[3]//tbody/tr/td[3]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string title = null;
                title = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[3]//tbody[" + rnum + "]/tr/td[3]"))).Text;
                if (title == expectedEducationTitle)
                {
                    //Click on Update icon to update the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[3]//tbody[" + rnum + "]/tr/td[6]/span[1]/i[@class='outline write icon']")).Click();

                    //Update University
                    driver.WaitForElementIsVisible(CollegeName);
                    CollegeName.Clear();
                    CollegeName.SendKeys(university);

                    //Update Country
                    SelectElement selectCountry = new SelectElement(CollegeCountry);
                    selectCountry.SelectByValue(country);

                    //Click on Update button to update the University and Country of Education
                    UpdateButton.Click();
                    break;
                }

            }
        }

        //Update Certification on the Profile page
        public void UpdateCertificationOnProfile(string expectedCertificate, string from, string year)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[4]//tbody/tr/td[1]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string certificate = null;
                certificate = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[4]//tbody[" + rnum + "]/tr/td[1]"))).Text;
                if (certificate == expectedCertificate)
                {
                    //Click on Update icon to update the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[4]//tbody[" + rnum + "]/tr/td[4]/span[1]/i[@class='outline write icon']")).Click();

                    //Update Certified From
                    CertifiedFromTextBox.Clear();
                    CertifiedFromTextBox.SendKeys(from);

                    //Update Certified Year
                    SelectElement selectCertifiedYear = new SelectElement(CertifiedYear);
                    selectCertifiedYear.SelectByValue(year);

                    //Click on Update button to update From and Year of certificate
                    UpdateButton.Click();
                    break;
                }

            }
        }

        //Delete Language on the Profile page
        public void DeleteLanguageOnProfile(string expectedLanguage)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[1]//tbody/tr/td[1]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string language = null;
                language = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[1]//tbody[" + rnum + "]/tr/td[1]"))).Text;
                if (language == expectedLanguage)
                {
                    //Click on Delete icon to delete the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[1]//tbody[" + rnum + "]/tr/td[3]/span[2]/i[@class='remove icon']")).Click();
                    break;
                }

            }
        }

        //Delete Skill on the Profile page
        public void DeleteSkillOnProfile(string expectedSkill)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[2]//tbody/tr/td[1]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string skill = null;
                skill = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[2]//tbody[" + rnum + "]/tr/td[1]"))).Text;
                if (skill == expectedSkill)
                {
                    //Click on Delete icon to delete the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[2]//tbody[" + rnum + "]/tr/td[3]/span[2]/i[@class='remove icon']")).Click();
                    break;
                }

            }
        }

        //Delete Education on the Profile page
        public void DeleteEducationOnProfile(string expectedEducationTitle)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[3]//tbody/tr/td[3]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string title = null;
                title = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[3]//tbody[" + rnum + "]/tr/td[3]"))).Text;
                if (title == expectedEducationTitle)
                {
                    //Click on Delete icon to delete the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[3]//tbody[" + rnum + "]/tr/td[6]/span[2]/i[@class='remove icon']")).Click();
                    break;
                }

            }
        }

        //Delete Certification on the Profile page
        public void DeleteCertificationOnProfile(string expectedCertification)
        {
            IList<IWebElement> rows = driver.WaitForListOfElements(By.XPath("(//table[@class='ui fixed table'])[4]//tbody/tr/td[1]"));
            for (int rnum = 1; rnum <= rows.Count; rnum++)
            {
                string certificate = null;
                certificate = (driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[4]//tbody[" + rnum + "]/tr/td[1]"))).Text;
                if (certificate == expectedCertification)
                {
                    //Click on Delete icon to delete the record
                    driver.WaitForElement(By.XPath("(//table[@class='ui fixed table'])[4]//tbody[" + rnum + "]/tr/td[4]/span[2]/i[@class='remove icon']")).Click();
                    break;
                }

            }
        }

        
        //Find out Popup Message 
        public string GetPopUpMsg()
        {
            driver.WaitForElementIsVisible(PopUpMessage);
            return PopUpMessage.Text;
        }

        //Popup close 
        public void ClosePopUp()
        {
            if (PopUpClose.Displayed)
            {
                PopUpClose.Click();
            }
        }


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
