using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace MarsProject2.Global
{
    class GlobalDefinitions
    {
        //Initialize the browser
        public static IWebDriver driver { get; set; }

        public static WebDriverWait wait;

        //Func delegate to check if element is visible by passing WebElement                     
        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };

        }
        //Explicit wait for element by using Func delegate       
        public static bool WaitForElementIsVisible(IWebDriver driver, Func<IWebDriver, bool> ElementIsVisible, int timeOutinSeconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(ElementIsVisible);

        }

        //Explicit Wait for Element
        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return element;

        }
        //Explicit Wait for List of Elements
        public static IList<IWebElement> WaitForListOfElements(IWebDriver driver, By by, int timeOutinSeconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            IList<IWebElement> listOfElements = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return listOfElements;

        }

        //Explicit Wait for Url
        public static void WaitForUrl(IWebDriver driver, string url, int timeOutinSeconds)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            wait.Until(ExpectedConditions.UrlToBe(url));

        }


        //Excel
        public class ExcelLib
        {
            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }

            public static void ClearData()
            {
                dataCol.Clear();
            }

            private static DataTable ReadExcelToDataTable(string fileName, string sheetName)
            {
                //Open the file and return as stream
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        //Return as dataset
                        DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        }
                        );

                        //Get all the tables
                        DataTableCollection table = resultSet.Tables;

                        //Store it in data table
                        DataTable resultTable = table[sheetName];
                        return resultTable;
                    }
                }
            }


            public static void PopulateInCollection(string fileName, string sheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ReadExcelToDataTable(fileName, sheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };

                        //Add all the details for each row
                        dataCol.Add(dtTable);

                    }
                }

            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations
                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    return data.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

        }



    }
}
