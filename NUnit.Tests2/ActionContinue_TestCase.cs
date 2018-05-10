using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class ActionContinue_TestCase:Baseclass
    {

        public static String testcaseName = "ActionTest_Continue";
        loginpa login = new loginpa();
        ContinueAction_Page contnw = new ContinueAction_Page();

        [Test, TestCaseSource("getdata1")]
        public void TestMethod(Dictionary<String, String> data)
        {
            username = data[Username];
            password = data[Password];
            hospital = data[Hospital];
            adiagnosis = data[Diagnosis];
            MedicalRecNo = data[mrno];
            lvalue = data[Value_fetch];
            AdmitTypeData = data[AdmitType_fetch];

            login.dologin();
            login.doPatientCreation();
            contnw.ClickContinue();
           // contnw.corenoDataFill();

        }
        public static Object[][] getdata1()
        {
            return TestUtil.getTestdata2(xls, testcaseName);
        }
    }
}
