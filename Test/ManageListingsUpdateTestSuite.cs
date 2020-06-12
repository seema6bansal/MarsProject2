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
    [TestFixture, Description("Collection of tests for update Service Listings")]
    class ManageListingsUpdateTestSuite : Base
    {
        [Test, Order(1), Description("Navigate to ManageListings page")]
        public void NavigateToManageListings()
        {
            Profile profileObj = new Profile();
            profileObj.ClickOnManageListings();
            ManageListings manageListingsObj = new ManageListings();
            Assert.AreEqual(ManageListings.expectedManageListingsUrl, manageListingsObj.GetManageListingsUrl());

        }

        [Test, Order(2), Description("Update Service Listings on the ManageListing page")]
        public void UpdateServiceListings()
        {
            //Populate DeleteManageListings Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "UpdateManageListings");

            if (GlobalDefinitions.ExcelLib.ReadData(2, "UpdateAction").Equals("Yes"))
            {
                string updateTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.UpdateServiceListings(updateTitle);

                ShareSkillDetails updateSkillObj = new ShareSkillDetails();
                updateSkillObj.Title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                updateSkillObj.Description = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                updateSkillObj.Category = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                updateSkillObj.SubCategory = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");
                updateSkillObj.Tags = GlobalDefinitions.ExcelLib.ReadData(2, "Tags");
                updateSkillObj.ServiceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
                updateSkillObj.LocationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
                updateSkillObj.StartDate = GlobalDefinitions.ExcelLib.ReadData(2, "StartDate");
                updateSkillObj.EndDate = GlobalDefinitions.ExcelLib.ReadData(2, "EndDate");
                updateSkillObj.SelectDay = GlobalDefinitions.ExcelLib.ReadData(2, "SelectDay");
                updateSkillObj.StartTime = GlobalDefinitions.ExcelLib.ReadData(2, "StartTime");
                updateSkillObj.EndTime = GlobalDefinitions.ExcelLib.ReadData(2, "EndTime");
                updateSkillObj.SkillTrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
                updateSkillObj.SkillExchange = GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange");
                updateSkillObj.Active = GlobalDefinitions.ExcelLib.ReadData(2, "Active");

                ShareSkill shareSkillObj = new ShareSkill();

                shareSkillObj.AddShareSkillDetails(updateSkillObj.Title, updateSkillObj.Description, updateSkillObj.Category, updateSkillObj.SubCategory,
                                                   updateSkillObj.Tags, updateSkillObj.ServiceType, updateSkillObj.LocationType, updateSkillObj.StartDate,
                                                   updateSkillObj.EndDate, updateSkillObj.SelectDay, updateSkillObj.StartTime, updateSkillObj.EndTime,
                                                   updateSkillObj.SkillTrade, updateSkillObj.SkillExchange, updateSkillObj.Active);

                Assert.AreEqual(updateSkillObj.Title, manageListingsObj.GetTitle());
            }

        }
    }
}
