using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class Action_Continue_Decline_TestCase:Baseclass
    {
        public static String testcaseName = "ActionTest_Continue_Accept_Decline";

        loginpa login = new loginpa();
        ContinueAction_Page contnw = new ContinueAction_Page();

        [Test, TestCaseSource("getdata3")]
        public void TestMethod(Dictionary<String, String> data)
        {
            username = data[Username];
            password = data[Password];
            hospital = data[Hospital];
            adiagnosis = data[Diagnosis];

            MedicalRecNo = data[mrno];
            AccountNo_data = data[accountno_fetch];
            FirstName_data = data[fname_fetch];
            LastName_data = data[lname_fetch];
            Gender_data = data[gender_fetch];
            DOB_data = data[dob_fetch];

            lvalue = data[Value_fetch];
            AdmitTypeData = data[AdmitType_fetch];
            HospitalistData = data[Hospitalist_fetch];
            DeclineReason_data = data[declinereason_fetch];

            if (flag == false)
            {
                login.dologin();
            }
            login.doPatientCreation();

            contnw.ClickContinue();
            contnw.corenoDataFill();
            contnw.ActionTest_Continue_Decline();

        }

        public static Object[][] getdata3()
        {
            return TestUtil.getTestdata2(xls, testcaseName);
        }
    }
}
