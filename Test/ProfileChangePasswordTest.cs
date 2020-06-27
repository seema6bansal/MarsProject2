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
    class ProfileChangePasswordTest : Base
    {
        [Test, Order(1), Description("Change Password on the Profile page")]
        public void ChangePassword()
        {
            //Populate Profile Excel data in Collection        
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "ChangePassword");

            Profile profileObj = new Profile();
            profileObj.ChangePasswordOnProfile(GlobalDefinitions.ExcelLib.ReadData(2, "CurrentPassword"),
                                               GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"),
                                               GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPassword"));
            Assert.AreEqual("Password Changed Successfully", profileObj.GetPopUpMsg());

        }
    }
}
