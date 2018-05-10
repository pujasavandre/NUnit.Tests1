using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class AdmitProtocolTestCase:Baseclass
    {
        public static String testcaseName = "AddPatient";
        loginpa login = new loginpa();

        [Test, TestCaseSource("getdata")]
        public void AdmitP(Dictionary<String, String> data)
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

            if (flag == false)
            {
                login.dologin();
            }
            login.doPatientCreation();
            login.NotifyHospitalist();
            //login.logout();
        }

        public static Object[][] getdata()
        {
            return TestUtil.getTestdata2(xls, testcaseName);
        }
    }
}
