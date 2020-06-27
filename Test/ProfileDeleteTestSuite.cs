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
    [TestFixture, Description("Collection of tests of Delete functionalities for Profile Page")]
    class ProfileDeleteTestSuite : Base
    {
        [Test, Order(1), Description("Delete Language on the Profile page")]
        public void DeleteLanguage()
        {
            //Populate DeleteProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "DeleteProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnLanguageTab();
                profileObj.DeleteLanguageOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Language") + " has been deleted from your languages", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

        [Test, Order(2), Description("Delete Skill on the Profile page")]
        public void DeleteSkill()
        {
            //Populate DeleteProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "DeleteProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnSkillTab();
                profileObj.DeleteSkillOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Skill") + " has been deleted", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

        [Test, Order(3), Description("Delete Education on the Profile page")]
        public void DeleteEducation()
        {
            //Populate DeleteProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "DeleteProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnEducationTab();
                profileObj.DeleteEducationOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "EducationTitle"));
                Assert.AreEqual("Education entry successfully removed", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }

        [Test, Order(4), Description("Delete Certification on the Profile page")]
        public void DeleteCertification()
        {
            //Populate DeleteProfile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "DeleteProfile");
            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                Profile profileObj = new Profile();
                profileObj.ClickOnCertificationTab();
                profileObj.DeleteCertificationOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Certification"));
                Assert.AreEqual(GlobalDefinitions.ExcelLib.ReadData(2, "Certification") + " has been deleted from your certification", profileObj.GetPopUpMsg());
                profileObj.ClosePopUp();
            }
        }
    }
}
