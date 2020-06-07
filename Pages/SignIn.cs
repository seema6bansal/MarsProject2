using MarsProject2.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject2.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        //Initialize WebElements by using Page Factory

        //Find the SignIn Link 
        [FindsBy(How = How.XPath, Using = "//a[@class='item' and text()='Sign In']")]
        private IWebElement signInButton { get; set; }

        //Find the Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement emailTextBox { get; set; }

        //Find Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement passwordTextBox { get; set; }

        //Find Login button
        [FindsBy(How = How.XPath, Using = "//button[ text()='Login']")]
        private IWebElement loginButton { get; set; }


        //Login to SkillSwap Website
        public void LoginStep()
        {
            signInButton.Click();
            emailTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UserName"));
            passwordTextBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            loginButton.Click();

        }
    }
}
