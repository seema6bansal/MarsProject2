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
    [TestFixture, Description("Collection of tests for Delete Service Listings")]
    class ManageListingsDeleteTestSuite : Base
    {
        [Test, Order(1), Description("Navigate to ManageListings page")]
        public void NavigateToManageListings()
        {
            Profile profileObj = new Profile();
            profileObj.ClickOnManageListings();
            ManageListings manageListingsObj = new ManageListings();
            Assert.AreEqual(ManageListings.expectedManageListingsUrl, manageListingsObj.GetManageListingsUrl());

        }

        [Test, Order(2), Description("Delete Service Listings on the ManageListing page")]
        public void DeleteServiceListings()
        {
            //Populate DeleteManageListings Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "DeleteManageListings");

            if (GlobalDefinitions.ExcelLib.ReadData(2, "DeleteAction").Equals("Yes"))
            {
                string deleteTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.DeleteServiceListings(deleteTitle);
                Assert.AreEqual((deleteTitle + " has been deleted"), manageListingsObj.GetPopUpMsg());

            }
        }
    }
}
