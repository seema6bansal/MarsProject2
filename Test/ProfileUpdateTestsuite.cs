using MarsProject3.Global;
using MarsProject3.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject3.Test
{
    [TestFixture, Description("Collection of tests of Update functionalities for Profile Page")]
    class ProfileUpdateTestsuite : Base
    {
        [Test, Order(1), Description("Update Language on the Profile page")]
        public void UpdateLanguage()
        {
            //Populate UpdateProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "UpdateAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnLanguageTab();
                profileObj.UpdateLanguageOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Language"), GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Language") + " has been updated to your languages", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

        [Test, Order(2), Description("Update Skill on the Profile page")]
        public void UpdateSkill()
        {
            //Populate UpdateProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "UpdateAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnSkillTab();
                profileObj.UpdateSkillOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"), GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Skill") + " has been updated to your skills", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

        [Test, Order(3), Description("Update Education on the Profile page")]
        public void UpdateEducation()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "UpdateAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnEducationTab();
                profileObj.UpdateEducationOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "EducationTitle"), GlobalDefinitions.ExcelLib.ReadData(2, "University"), GlobalDefinitions.ExcelLib.ReadData(2, "Country"));
                Assert.AreEqual("Education as been updated", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

        [Test, Order(4), Description("Update Certification on the Profile page")]
        public void UpdateCertification()
        {
            //Populate UpdateProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "UpdateAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnCertificationTab();
                profileObj.UpdateCertificationOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Certification"), GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"), GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedYear"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Certification") + " has been updated to your certification", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

    }
}
