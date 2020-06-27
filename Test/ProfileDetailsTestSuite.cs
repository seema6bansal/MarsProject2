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
    [TestFixture, Description("Collection of tests to update User's details on the Profile Page")]
    class ProfileDetailsTestSuite : Base
    {
        [Test, Order(1), Description("Edit Availability on the Profile page")]
        public void EditAvailability()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.EditAvailabilityOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Availability"));
            Assert.AreEqual("Availability updated", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

        [Test, Order(2), Description("Edit Hours on the Profile page")]
        public void EditHours()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.EditHoursOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
            Assert.AreEqual("Availability updated", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

        [Test, Order(3), Description("Edit Earn Target on the Profile page")]
        public void EditEarnTarget()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.EditEarnTargetOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
            Assert.AreEqual("Availability updated", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }

        [Test, Order(4), Description("Edit Description on the Profile page")]
        public void EditDescription()
        {
            //Populate Profile Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "Profile");

            Profile profileObj = new Profile();
            profileObj.EditdescriptionOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Assert.AreEqual("Description has been saved successfully", profileObj.GetPopUpMsg());
            profileObj.ClosePopUp();
        }
    }
}
