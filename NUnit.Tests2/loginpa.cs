using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace NUnit.Tests2
{
    [TestFixture]
    public class loginpa:Baseclass
    {
        public By selecthospital = By.XPath("//*[@id='hospitalSelect']/span/input");
        public By usernamexpath = By.XPath("//*[@id='UserName']");
        public By passwordxpath = By.XPath("//*[@id='Password']");
        public By loginbtn = By.XPath("//*[@id='btnLogin']");
        public By homepage = By.XPath("//*[@id='DivQuickLinks']/ul/li[1]/a");
        public By logoutlink = By.XPath("//a[@href='/Home/Logout']");
        public By logoutlink1 = By.XPath("//*[@id='content']/a");   //After Logout.
        public By lgout = By.XPath("//*[@id='logoutUser']/span/a"); //Logout Button.


        public By AdmitProtocol_Xpath = By.XPath("//*[@id='NavWrapper']/ul/li[6]");  //Admit Protocol Mouse hover
        public By Admit_Protocol_box_Xpath = By.XPath("//*[@id='ui-id-98']");  //Admit Protocol box
        public static By MedicalrecordNoSearchTextbox_Xpath = By.XPath("//*[@id='searchPatientForm']/div[2]/input"); //MrNo of Pattient

        public By SearchPatientInfoButton_Xpath = By.XPath("//*[@id='searchPatients']"); //Search patient Button
        public static By Addpatientbutton_Xpath = By.XPath("//*[@id='addPatientFromSearch']/span[contains(text(), 'Add Patient')]"); //Add Patient Button
        public static By AccountNoTextbox_Xpath = By.XPath("//*[@id='addPatientForm']/div[1]/input");

        public static By EnterLastName_Xpath = By.XPath("//*[@id='addPatientForm']/div[3]/input");
        public static By EnterFirstName_Xpath = By.XPath("//*[@id='addPatientForm']/div[4]/input");

        public By SearchPatient_Popup = By.XPath("//*[@id='searchContent']");
        public By gender = By.XPath("//*[@id='addSexRadios']");

        public static By ClickongenderFemale_Xpath = By.XPath("//*[@for='addSexF']");
        public static By Clickongendermale_Xpath = By.XPath("//*[@for='addSexM']");

        public static By DOB_Xpath = By.XPath("//*[@class='datepicker required hasDatepicker']");
        public static By Rapgo_selectyear_Xpath = By.XPath("//select[@class='ui-datepicker-year']");
        public static By Tagnameoption = By.TagName("option");
        public static By Rapgo_selectmonth_Xpath = By.XPath("//select[@class='ui-datepicker-month']");
        public static By Rapgo_selectdate_Xpath = By.XPath("//*[@data-event='click']");
        public static By ClickonDate = By.XPath("//*[@id='ui-datepicker-div']/table/tbody/tr[2]/td[2]/a");

        public static By Click_AddPatientButton = By.XPath("//*[@id='Diagnostic']/div[6]/div[3]/div/button[1]");
        public By getallmandatorytable = By.Id("CORE_Diagnostic");

        public By Click_Notify_HospitalistButton = By.XPath("//*[@id='Notify_Button']");
        public WebDriverWait wait1 = null;

       
        public void dologin()
        {
            try
            {
                if (DriverRepository.Driver == null)
                {
                    DriverRepository.Driver = new ChromeDriver();
                    DriverRepository.Driver.Manage().Window.Maximize();
                    DriverRepository.Driver.Navigate().GoToUrl("https://rapgotesting.emcare.com");

                }


                ////Give the path of the geckodriver.exe    
                //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\geckodriver-v0.18.0-win64", "geckodriver.exe");

                ////Launch the browser
                //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                //driver = new FirefoxDriver(service);





                wait1 = new WebDriverWait(DriverRepository.Driver, TimeSpan.FromSeconds(60));
            }
            catch (Exception yy) { }
            

            wait1.Until(ExpectedConditions.ElementIsVisible(selecthospital));
            DriverRepository.Driver.FindElement(selecthospital).Click();

            DriverRepository.Driver.FindElement(selecthospital).Clear();
            DriverRepository.Driver.FindElement(selecthospital).SendKeys(hospital);

            DriverRepository.Driver.FindElement(usernamexpath).Clear();
            DriverRepository.Driver.FindElement(usernamexpath).SendKeys(username);

            DriverRepository.Driver.FindElement(passwordxpath).Clear();
            DriverRepository.Driver.FindElement(passwordxpath).SendKeys(password);

            DriverRepository.Driver.FindElement(loginbtn).Click();
            flag = true;
           // Thread.Sleep(2000);

            //wait1.Until(ExpectedConditions.ElementIsVisible(homepage));
            try
            {
                //if (driver.FindElement(lgout) != null)
                //{
                //    driver.FindElement(lgout).Click();
                //    wait1.Until(ExpectedConditions.ElementIsVisible(logoutlink1));
                //    driver.FindElement(logoutlink1).Click();
                //}
            }
            catch
            {

            }

           


        }

        public void logout()
        {
           
            Thread.Sleep(2000);
            try
            {
                if (DriverRepository.Driver.FindElement(lgout) != null)
                {
                    flag = false;
                    DriverRepository.Driver.FindElement(lgout).Click();
                    wait1.Until(ExpectedConditions.ElementIsVisible(logoutlink1));
                    DriverRepository.Driver.FindElement(logoutlink1).Click();
                }
            }
            catch
            {

            }
        }

        public void doPatientCreation()
        {
            //Mouse Hover for admit protocols
            Thread.Sleep(5000);
            Actions action = new Actions(DriverRepository.Driver);
            IWebElement admit_protocols = DriverRepository.Driver.FindElement(AdmitProtocol_Xpath);
            action.MoveToElement(admit_protocols).Perform();

            Thread.Sleep(2000);
            wait1.Until(ExpectedConditions.ElementIsVisible(Admit_Protocol_box_Xpath));
            DriverRepository.Driver.FindElement(By.LinkText(adiagnosis)).Click();  //Selecting the asthama diagnosis from list

            //Search patient If present or not

            wait1.Until(ExpectedConditions.ElementIsVisible(MedicalrecordNoSearchTextbox_Xpath));
            DriverRepository.Driver.FindElement(MedicalrecordNoSearchTextbox_Xpath).Clear();
            DriverRepository.Driver.FindElement(MedicalrecordNoSearchTextbox_Xpath).SendKeys(MedicalRecNo);

            Thread.Sleep(1000);
            DriverRepository.Driver.FindElement(SearchPatientInfoButton_Xpath).Click();
            // wait1.Until(ExpectedConditions.ElementIsVisible(SearchPatient_Popup));
            Thread.Sleep(2000);

            try
            {

                if (DriverRepository.Driver.FindElement(Addpatientbutton_Xpath) != null) //If Patient is not present.
                {

                    wait1.Until(ExpectedConditions.ElementIsVisible(Addpatientbutton_Xpath));
                    DriverRepository.Driver.FindElement(Addpatientbutton_Xpath).Click();

                    DriverRepository.Driver.FindElement(AccountNoTextbox_Xpath).SendKeys(AccountNo_data);   //Entering Account no.
                    DriverRepository.Driver.FindElement(EnterLastName_Xpath).SendKeys(LastName_data);
                    DriverRepository.Driver.FindElement(EnterFirstName_Xpath).SendKeys(FirstName_data);

                    wait1.Until(ExpectedConditions.ElementIsVisible(DOB_Xpath));


                    //DOB selection 2 Ways..............

                    DriverRepository.Driver.FindElement(DOB_Xpath).SendKeys(DOB_data);

                    Thread.Sleep(2000);

                    /*  String[] m =DOB_data.Split('/');

                      String dat = m[0];
                      String mnth = m[1];
                      String yr = m[2];

                      DriverRepository.Driver.FindElement(DOB_Xpath).Click();

                      //year
                      IWebElement year = DriverRepository.Driver.FindElement(Rapgo_selectyear_Xpath);
                      IList<IWebElement> yearoptions = DriverRepository.Driver.FindElements(Tagnameoption);
                      foreach (IWebElement option in yearoptions)
                      {

                          if (yr.Equals(option.Text))
                          {
                              option.Click();
                              break;
                          }
                      }

                      //month
                      IWebElement mont = DriverRepository.Driver.FindElement(Rapgo_selectmonth_Xpath);
                      IList<IWebElement> montoptions = DriverRepository.Driver.FindElements(Tagnameoption);
                      foreach (IWebElement options in montoptions)
                      {
                          //nth = Convert.ToString(TestContext.DataRow["month"]);
                          if (mnth.Equals(options.Text))
                          {
                              options.Click();
                              break;
                          }
                      }

                      //date
                      // IWebElement date = GenricHelper.getWeblinks(Rapgo_selectdate_Xpath);
                      IList<IWebElement> dateoptions = DriverRepository.Driver.FindElements(Rapgo_selectdate_Xpath);
                      foreach (IWebElement option1 in dateoptions)
                      {

                          if (dat.Equals(option1.Text))
                          {
                              option1.Click();
                              break;
                          }
                      }

                      DriverRepository.Driver.FindElement(ClickonDate).Click();

                      */


                    //Gender Selection radio Button
                    //DriverRepository.Driver.FindElement(ClickongenderFemale_Xpath).Click();

                    if (Gender_data == "M")
                    {
                        DriverRepository.Driver.FindElement(Clickongendermale_Xpath).Click();
                    }
                    else
                    {
                        DriverRepository.Driver.FindElement(ClickongenderFemale_Xpath).Click();

                    }
                    wait1.Until(ExpectedConditions.ElementIsVisible(Click_AddPatientButton));
                    Thread.Sleep(2000);

                    DriverRepository.Driver.FindElement(Click_AddPatientButton).Click(); //Click on add paient button


                }

            } catch (Exception oo) { }

            Thread.Sleep(2000);

            IWebElement getallfields = DriverRepository.Driver.FindElement(getallmandatorytable);
            IList<IWebElement> getallmandatoryfields = getallfields.FindElements(By.CssSelector("input[class~='required'][value='" + lvalue + "']"));
            Console.WriteLine("Total mandatory fields are: " + getallmandatoryfields.Count);
            foreach (IWebElement optionss in getallmandatoryfields)
            {
                Thread.Sleep(500);
                optionss.Click();


            }
            
        }
        public void NotifyHospitalist()
        {
            System.Threading.Thread.Sleep(2000);
            DriverRepository.Driver.FindElement(Click_Notify_HospitalistButton).Click();// Notify Hospitalist Click Button
            if (lvalue == "1")
            {
                DriverRepository.Driver.FindElement(By.XPath("//*[@id='Diagnostic']/div[4]/div[11]/div/button")).Click();// Popup Alert---Continue Button Xpath
            }

            try
            {
                DriverRepository.Driver.FindElement(By.XPath("//*[@id='Diagnostic']/div[4]/div[11]/div/button")).Click();
            }

            catch (Exception err)
            {
                DriverRepository.Driver.FindElement(By.XPath("//*[@id='Diagnostic']/div[7]/div[11]/div/button")).Click();
            }
        }

        


            


    }



}
