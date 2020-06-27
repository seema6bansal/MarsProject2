using MarsProject3.Global;
using MarsProject3.Model;
using MarsProject3.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject3.Test
{
    [TestFixture, Description("Collection of tests of Add functionalities for Profile Page")]
    class ProfileAddTestSuite : Base
    {
        [Test, Order(1), Description("Add Language on the Profile page")]
        public void AddLanguage()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.ClickOnLanguageTab();
            profileObj.AddLanguageOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Language"), GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Language") + " has been added to your languages", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

        [Test, Order(2), Description("Add Skill on the Profile page")]
        public void AddSkill()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.ClickOnSkillTab();
            profileObj.AddSkillOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"), GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Skill") + " has been added to your skills", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

        [Test, Order(3), Description("Add Education on the Profile page")]
        public void AddEducation()
        {
            //Populate Education Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Education");

            EducationDetails educationDetailsobj = new EducationDetails();
            educationDetailsobj.University = GlobalDefinitions.ExcelLib.ReadData(2, "University");
            educationDetailsobj.Country = GlobalDefinitions.ExcelLib.ReadData(2, "Country");
            educationDetailsobj.Title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            educationDetailsobj.Degree = GlobalDefinitions.ExcelLib.ReadData(2, "Degree");
            educationDetailsobj.Year = GlobalDefinitions.ExcelLib.ReadData(2, "Year");

            Profile profileObj = new Profile();
            profileObj.ClickOnEducationTab();
            profileObj.AddEducationOnProfile(educationDetailsobj);
            Assert.AreEqual("Education has been added", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

        [Test, Order(4), Description("Add Certification on the Profile page")]
        public void AddCertification()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.ClickOnCertificationTab();
            profileObj.AddCertificationOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Certification"), GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"), GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedYear"));
            Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Certification") + " has been added to your certification", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

    }

}
