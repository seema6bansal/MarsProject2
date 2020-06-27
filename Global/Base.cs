using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsProject3.Model;
using MarsProject3.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsProject3.Global
{
    class Base
    {
        public static string excelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestData\\TestData.xlsx");
        public static string uploadFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestData\\TestWorkSample.txt");
        public static string reportsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestReports\\");
        public static ExtentTest test;
        public static ExtentReports extent;
        private string isLogin = "true";



        public void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(Base.reportsPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeSetUp]
        public void SetUp()
        {
            //Initialize the Extent Report
            InitializeReport();

            //Define driver
            GlobalDefinitions.driver = new ChromeDriver();
            GlobalDefinitions.driver.Manage().Window.Maximize();

            //Login to the application if user is already registered
            if (isLogin == "true")
            {
                //Populate SignIn Excel data in Collection
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "SignIn");

                //Get Base Url from Excel
                GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

                SignIn loginObj = new SignIn();
                loginObj.LoginStep(GlobalDefinitions.ExcelLib.ReadData(2, "UserName"), GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            }
            else
            {
                //Register to the application if user is not registered
                //Populate SignUp Excel data in Collection
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "SignUp");

                //Get Base Url from Excel
                GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

                SignUpDetails signUpDetailsObj = new SignUpDetails();
                signUpDetailsObj.FirstName = GlobalDefinitions.ExcelLib.ReadData(2, "FirstName");
                signUpDetailsObj.LastName = GlobalDefinitions.ExcelLib.ReadData(2, "LastName");
                signUpDetailsObj.EmailAddress = GlobalDefinitions.ExcelLib.ReadData(2, "EmailAddress");
                signUpDetailsObj.Password = GlobalDefinitions.ExcelLib.ReadData(2, "Password");
                signUpDetailsObj.ConfirmPassword = GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword");

                SignUp joinObj = new SignUp();
                joinObj.JoinStep(signUpDetailsObj);
                Assert.AreEqual("Registration successful", joinObj.GetPopUpMsg());
                SignIn loginObj = new SignIn();
                loginObj.LoginStep(GlobalDefinitions.ExcelLib.ReadData(2, "EmailAddress"), GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            }
        }

        [SetUp]
        public void GetTestName()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [TearDown]
        public void GetResultsInReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Log(Status.Pass, "Test passed");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, status + errorMessage);
            }

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //Close all the Browsers open by Selenium
            GlobalDefinitions.driver.Quit();

            //calling Flush to write everything to the Extent Report
            extent.Flush();
        }
    }
}
