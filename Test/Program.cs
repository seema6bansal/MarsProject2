using MarsProject2.Global;
using MarsProject2.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsProject2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

    }

    [TestFixture, Description("Collection of tests for Add ShareSkill")]
    class ShareSkillAddTestSuite : Base
    {
        [Test, Order(1), Description("Navigate to ShareSkill page")]
        public void NavigateToShareSkill()
        {
            Profile profileObj = new Profile();
            profileObj.ShareSkillClick();
            ShareSkill shareSkillObj = new ShareSkill();
            Assert.AreEqual(Base.expectedShareSkillUrl, shareSkillObj.ShareSkillUrl());

        }

        [Test, Order(2), Description("Add ShareSkill data and validate it on the ManageListings Page")]
        public void AddShareSkillData()
        {
            ShareSkill shareSkillObj = new ShareSkill();
            shareSkillObj.PopulateShareSkillAddData();
            shareSkillObj.AddShareSkillDetails();
            //Assert.AreEqual("Service Listing Added sucessfully", shareskillObj.GetPopUp());                ;
            ManageListings manageListingsObj = new ManageListings();
            Assert.AreEqual(shareSkillObj.excelTitle(), manageListingsObj.GetTitle());

        }

    }

    [TestFixture, Description("Collection of tests for update Service Listings")]
    class ManageListingsUpdateTestSuite : Base
    {
        [Test, Order(1), Description("Navigate to ManageListings page")]
        public void NavigateToManageListings()
        {
            Profile profileObj = new Profile();
            profileObj.ManageListingsClick();
            ManageListings manageListingsObj = new ManageListings();
            Assert.AreEqual(Base.expectedManageListingsUrl, manageListingsObj.ManageListingsUrl());

        }

        [Test, Order(2), Description("Update Service Listings on the ManageListing page")]
        public void UpdateServiceListings()
        {
            ManageListings manageListingsObj = new ManageListings();
            manageListingsObj.UpdateServiceListings();

            ShareSkill shareSkillObj = new ShareSkill();
            shareSkillObj.PopulateShareSkillUpdateData();
            shareSkillObj.AddShareSkillDetails();

            Assert.AreEqual(shareSkillObj.excelTitle(), manageListingsObj.GetTitle());

        }

    }

    [TestFixture, Description("Collection of tests for Delete Service Listings")]
    class ManageListingsDeleteTestSuite : Base
    {
        [Test, Order(1), Description("Navigate to ManageListings page")]
        public void NavigateToManageListings()
        {
            Profile profileObj = new Profile();
            profileObj.ManageListingsClick();
            ManageListings manageListingsObj = new ManageListings();
            Assert.AreEqual(Base.expectedManageListingsUrl, manageListingsObj.ManageListingsUrl());

        }

        [Test, Order(2), Description("Delete Service Listings on the ManageListing page")]
        public void DeleteServiceListings()
        {
            ManageListings manageListingsObj = new ManageListings();
            manageListingsObj.DeleteServiceListings();
            Assert.AreEqual((manageListingsObj.deleteTitleMsg + " has been deleted"), manageListingsObj.DeletePopUpMsg());

        }
    }


}
