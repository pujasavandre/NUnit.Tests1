using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class loginpage1
    {
        public By selecthospital = By.XPath("//*[@id='hospitalSelect']/span/input");
        public By username = By.XPath("//*[@id='UserName']");
        public By password = By.XPath("//*[@id='Password']");
        public By loginbtn = By.XPath("//*[@id='btnLogin']");
        public By homepage = By.XPath("//*[@id='DivQuickLinks']/ul/li[1]/a");
        public By logoutlink = By.XPath("//a[@href='/Home/Logout']");
        public By logoutlink1 = By.XPath("//*[@id='content']/a");
        public static Xls_Reader xls=null;
        public IWebDriver driver;
        public WebDriverWait wait1 = null;

        public static Object[][] obj2;
        public static Dictionary<String, String> data;

        [Test, TestCaseSource("getdata")]
        public void TestMethod(Dictionary<String, String> obj)
        {

            //Launch the browser

            //System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"D:\Anand\geckodriver");
            //IWebDriver driver = new FirefoxDriver();

            //Give the path of the geckodriver.exe    
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\Anand", "geckodriver.exe");

            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";

            driver = new FirefoxDriver(service);
            driver.Navigate().GoToUrl("https://rapgotesting.emcare.com");
            wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait1.Until(ExpectedConditions.ElementIsVisible(username));
            driver.FindElement(selecthospital).Click();
            String username1 = obj["UserName"];
            driver.FindElement(selecthospital).SendKeys(obj["Hospital"]);
            driver.FindElement(username).SendKeys(obj["UserName"]);
            driver.FindElement(password).SendKeys(obj["Password"]);
            driver.FindElement(loginbtn).Click();
            wait1.Until(ExpectedConditions.ElementIsVisible(homepage));
            driver.FindElement(logoutlink).Click();
            wait1.Until(ExpectedConditions.ElementIsVisible(logoutlink1));
            driver.FindElement(logoutlink1).Click();
        }

        public static object[] getdata()
        {

            xls = new Xls_Reader(@"D:\Anand\NewRngLogin.xls");
            String sheetName = "TestData";
            int testStartRowNum = 1;
            while (!xls.getCellData(sheetName, 0, testStartRowNum).Equals("Logintest"))
            {
                testStartRowNum++;
            }
            Console.WriteLine("Test starts from no- " + testStartRowNum);
            int colStartRowNum = testStartRowNum + 1;
            int dataStartRowNum = testStartRowNum + 2;

            //Calculate rows of data
            int rows = 0;
            while (!xls.getCellData(sheetName, 0, dataStartRowNum + rows).Equals(""))
            {
                rows++;

            }
            Console.WriteLine("Total rows is: " + rows);

            //Calculate cols of data
            int cols = 0;
            while (!xls.getCellData(sheetName, cols, colStartRowNum).Equals(""))
            {
                cols++;
            }
            Console.WriteLine("Total cols is: " + cols);
            obj2 = new Object[rows][];
            int datarow = 0;

            //  Hashtable myDict = new Hashtable();

            for (int rNum = dataStartRowNum; rNum < dataStartRowNum + rows; rNum++)
            {
                obj2[datarow] = new object[1];
                data = new Dictionary<String, String>();
                for (int cNum = 0; cNum < cols; cNum++)
                {

                    //data[datarow, cNum]=xls.getCellData(sheetName, cNum, rNum);
                    //table = new Dictionary<string, string>();
                    String key = xls.getCellData(sheetName, cNum, colStartRowNum);
                    String value = xls.getCellData(sheetName, cNum, rNum);
                    data.Add(key, value);
                    //  myDict.Add(table);


                }
                obj2[datarow][0] = data;
                datarow++;
                //   myDict = new List<Dictionary<string, string>>();
            }
            return obj2;
        }
    }
}
