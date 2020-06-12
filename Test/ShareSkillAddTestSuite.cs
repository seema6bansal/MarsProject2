using MarsProject2.Global;
using MarsProject2.Pages;
using MarsProject2.TestData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject2.Test
{
    [TestFixture, Description("Collection of tests for Add ShareSkill")]
    class ShareSkillAddTestSuite : Base
    {
        [Test, Order(1), Description("Navigate to ShareSkill page")]
        public void NavigateToShareSkill()
        {
            Profile profileObj = new Profile();
            profileObj.ClickOnShareSkill();
            ShareSkill shareSkillObj = new ShareSkill();
            Assert.AreEqual(ShareSkill.expectedShareSkillUrl, shareSkillObj.GetShareSkillUrl());

        }

        [Test, Order(2), Description("Add ShareSkill data and validate it on the ManageListings Page")]
        public void AddShareSkillData()
        {
            //Populate ShareSkill Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "ShareSkill");
            ShareSkillDetails addSkillObj = new ShareSkillDetails();

            addSkillObj.Title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            addSkillObj.Description = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            addSkillObj.Category = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
            addSkillObj.SubCategory = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");
            addSkillObj.Tags = GlobalDefinitions.ExcelLib.ReadData(2, "Tags");
            addSkillObj.ServiceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            addSkillObj.LocationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            addSkillObj.StartDate = GlobalDefinitions.ExcelLib.ReadData(2, "StartDate");
            addSkillObj.EndDate = GlobalDefinitions.ExcelLib.ReadData(2, "EndDate");
            addSkillObj.SelectDay = GlobalDefinitions.ExcelLib.ReadData(2, "SelectDay");
            addSkillObj.StartTime = GlobalDefinitions.ExcelLib.ReadData(2, "StartTime");
            addSkillObj.EndTime = GlobalDefinitions.ExcelLib.ReadData(2, "EndTime");
            addSkillObj.SkillTrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            addSkillObj.SkillExchange = GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange");
            addSkillObj.Active = GlobalDefinitions.ExcelLib.ReadData(2, "Active");

            ShareSkill shareSkillObj = new ShareSkill();
            shareSkillObj.AddShareSkillDetails(addSkillObj);
            //Assert.AreEqual("Service Listing Added sucessfully", shareskillObj.GetPopUp());                ;
            ManageListings manageListingsObj = new ManageListings();
            Assert.AreEqual(addSkillObj.Title, manageListingsObj.GetTitle());

        }
    }
}
