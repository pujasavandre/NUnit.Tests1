using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class ContinueAction_Page:Baseclass
    {
        public WebDriverWait wait1 = null;
        
        //coreno Xpaths
        public By Rapgo_ContinueButton_xpath = By.XPath("//*[@id='GO_Button']");
        public By AdmitType_xpath = By.XPath("//*[@id='admitType']");
        public By Hospitalist_xpath = By.XPath("//*[@id='HospitalistID']");
        public By Continue_HoldButton_xpath = By.XPath("//*[@id='holdButton']");
        public By Continue_DeclineButton_xpath = By.XPath("//*[@id='declineButton']");
        public By Continue_NotifyHospButton_xpath = By.XPath("//*[@id='notifyHospitalistButton']");

        //Popup in coreno Xpaths
        public By popup_HoldReason_xpath = By.XPath("//*[@id='holdReason']");
        public By popup_DeclineReason_xpath = By.XPath("//*[@id='DeclinedReasonSelect']");

        //Common Hold Decline Popup Xpath
        public By popup_Button_xpath = By.XPath("/html/body/div[4]/div[3]/div/button[1]");
        public By popup_Ok_xpath = By.XPath("/html/body/div/div[11]/div/button");

        public void ClickContinue()
        {
            wait1 = new WebDriverWait(DriverRepository.Driver, TimeSpan.FromSeconds(40));
            Thread.Sleep(2000);

            try
            {
                if(DriverRepository.Driver.FindElement(Rapgo_ContinueButton_xpath) != null)
                {
                    DriverRepository.Driver.FindElement(Rapgo_ContinueButton_xpath).Click();
                }
                else
                {
                    Console.WriteLine("Continue button is not present");
                }

            }
            catch (Exception hh)
            {

            }
            if (lvalue == "1")
            {
                DriverRepository.Driver.FindElement(By.XPath("//*[@id='Diagnostic']/div[4]/div[11]/div/button")).Click();// Popup Alert---Continue Button Xpath if radio are Yes(1)
            }

        }

        public void corenoDataFill()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(AdmitType_xpath));

            IWebElement getalladmitypelabels = DriverRepository.Driver.FindElement(AdmitType_xpath);
            IList<IWebElement> getalllabeltext = getalladmitypelabels.FindElements(By.TagName("label"));
            foreach (IWebElement eachoption in getalllabeltext)
            {
                String applable = eachoption.Text;
                if (AdmitTypeData.Equals(applable))
                {
                    eachoption.Click();
                }

            }

            Thread.Sleep(2000);
            IWebElement getallhospitalislabels = DriverRepository.Driver.FindElement(Hospitalist_xpath);
            IList<IWebElement> getallhospitalislabeltext = getallhospitalislabels.FindElements(By.TagName("option"));
            foreach (IWebElement eachhospitalisoption in getallhospitalislabeltext)
            {
                String apphospitalislable = eachhospitalisoption.Text;
                if (HospitalistData.Equals(apphospitalislable))
                {
                    eachhospitalisoption.Click();
                    break;
                }
            }


        }

        public void ActionTest_Continue_Hold()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(Continue_HoldButton_xpath));
            DriverRepository.Driver.FindElement(Continue_HoldButton_xpath).Click(); //coreno page Hold Button click

            wait1.Until(ExpectedConditions.ElementIsVisible(popup_HoldReason_xpath));
            DriverRepository.Driver.FindElement(popup_HoldReason_xpath).SendKeys(HoldReason_data); //Hold Reason Selection from excel


            Thread.Sleep(2000);
            wait1.Until(ExpectedConditions.ElementIsVisible(popup_Button_xpath));
            DriverRepository.Driver.FindElement(popup_Button_xpath).Click();   //Hold Button from popup Hold

            DriverRepository.Driver.FindElement(popup_Ok_xpath).Click();

        }

        public void ActionTest_Continue_Decline()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(Continue_DeclineButton_xpath));
            DriverRepository.Driver.FindElement(Continue_DeclineButton_xpath).Click(); //coreno page Decline Button click

            wait1.Until(ExpectedConditions.ElementIsVisible(popup_DeclineReason_xpath));
            DriverRepository.Driver.FindElement(popup_DeclineReason_xpath).SendKeys(DeclineReason_data); //Decline Reason Selection from excel


            Thread.Sleep(2000);
            wait1.Until(ExpectedConditions.ElementIsVisible(popup_Button_xpath));
            DriverRepository.Driver.FindElement(popup_Button_xpath).Click();   //Decline Button from popup Hold

            DriverRepository.Driver.FindElement(popup_Ok_xpath).Click();

        }

        public void ActionTest_Continue_NotifyHosp()
        {
            wait1.Until(ExpectedConditions.ElementIsVisible(Continue_NotifyHospButton_xpath));
            DriverRepository.Driver.FindElement(Continue_NotifyHospButton_xpath).Click(); //coreno page Notify Hospitalist Button click
            
            Thread.Sleep(2000);
            DriverRepository.Driver.FindElement(popup_Ok_xpath).Click();
          
        }

    }
}
