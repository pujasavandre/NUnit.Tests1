using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class Action_Continue_Hold_TestCase:Baseclass
    {
        public static String testcaseName = "ActionTest_Continue_Accept_Hold";
        loginpa login = new loginpa();
        ContinueAction_Page contnw = new ContinueAction_Page();

        [Test, TestCaseSource("getdata2")]
        public void TestMethod(Dictionary<String, String> data)
        {
            username = data[Username];
            password = data[Password];
            hospital = data[Hospital];
            adiagnosis = data[Diagnosis];
            MedicalRecNo = data[mrno];
            lvalue = data[Value_fetch];
            AdmitTypeData = data[AdmitType_fetch];
            HospitalistData = data[Hospitalist_fetch];
            HoldReason_data = data[holdreason_fetch];
            
            login.dologin();         
            login.doPatientCreation();

            contnw.ClickContinue();
            contnw.corenoDataFill();
            contnw.ActionTest_Continue_Hold();

        }
        public static Object[][] getdata2()
        {
            return TestUtil.getTestdata2(xls, testcaseName);
        }
    }
}
