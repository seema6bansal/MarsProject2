using MarsProject3.Global;
using MarsProject3.Model;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject3.Pages
{
    class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        //Initialize WebElements by using Page Factory

        //Find the Join Link 
        [FindsBy(How = How.XPath, Using = "//button[@class = 'ui green basic button' and contains(text(), 'Join')]")]
        private IWebElement JoinLink { get; set; }

        //Find First Name Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement FirstName { get; set; }

        //Find Last Name Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement LastName { get; set; }

        //Find Email Address Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement EmailAddress { get; set; }

        //Find Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Find Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Find Term and Condition checkbox
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @name='terms']")]
        private IWebElement TermAndCondition { get; set; }

        //Find join button
        [FindsBy(How = How.XPath, Using = "//div[@id='submit-btn']")]
        private IWebElement JoinButton { get; set; }

        //Register to SkillSwap Website
        public void JoinStep(SignUpDetails signUpObj)
        {
            //Click on Join link to register to the SkillSwap Website
            JoinLink.Click();

            //Enter First Name 
            FirstName.SendKeys(signUpObj.FirstName);

            //Enter Last Name 
            LastName.SendKeys(signUpObj.LastName);

            //Enter Email address
            EmailAddress.SendKeys(signUpObj.EmailAddress);

            //Enter Password
            Password.SendKeys(signUpObj.Password);

            //Enter Confirm Password
            ConfirmPassword.SendKeys(signUpObj.ConfirmPassword);

            //Click on Terms and Conditions checkbox
            TermAndCondition.Click();

            //Click on Join button
            JoinButton.Click();
            
        }
    }
}
