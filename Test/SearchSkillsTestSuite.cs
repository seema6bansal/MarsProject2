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
    [TestFixture, Description("Collection of tests of Search functionalities for Skills")]
    class SearchSkillsTestSuite : Base
    {
        [Test, Order(1), Description("Search Skills by All Categories")]
        public void SearchSkillsByAllCategories()
        {
            HomeSearch homeSearchObj = new HomeSearch();
            homeSearchObj.SearchByAllCategories();
            Assert.IsTrue(homeSearchObj.GetSearchResult().Length > 0);
           
        }

        [Test, Order(2), Description("Search Skills by Category and SubCategory")]
        public void SearchSkillByCategoryAndSubCategory()
        {
            //Populate SearchSkills Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "SearchSkills");
            HomeSearch homeSearchObj = new HomeSearch();
            homeSearchObj.SearchByAllCategories();
            homeSearchObj.SearchByCategory(GlobalDefinitions.ExcelLib.ReadData(2, "Category"), GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            Assert.IsTrue(homeSearchObj.GetSearchResult().Length > 0);
           
        }

        [Test, Order(3), Description("Search Skills by Filter")]
        public void SearchSkillsByFilter()
        {
            //Populate SearchSkills Excel data in Collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.excelPath, "SearchSkills");
            HomeSearch homeSearchObj = new HomeSearch();
            homeSearchObj.SearchByAllCategories();
            homeSearchObj.SearchByFilter(GlobalDefinitions.ExcelLib.ReadData(2, "Filter"));
            Assert.IsTrue(homeSearchObj.GetSearchResult().Length > 0);
            
        }
    }
}
