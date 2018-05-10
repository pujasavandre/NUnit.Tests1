using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class Baseclass
    {
        public static Object[][] obj2;
        public static Dictionary<String, String> data;

        public static bool flag = false;

        public static Xls_Reader xls = new Xls_Reader(@"D:\RNG_Automation\RngTest.xls");
        public static String username;
        public static String password;
        public static  String hospital;
        public static  String Username = "UserName";
        public static  String Password = "Password";
        public static String Hospital = "Hospital";

        public static String adiagnosis;
        public static String Diagnosis = "Diagnosis";

        public static String MedicalRecNo;
        public static String mrno= "MedicalRecordNo";

        public static String AccountNo_data;
        public static String accountno_fetch = "AccountNo";

        public static String FirstName_data;
        public static String fname_fetch = "FirstName";

        public static String LastName_data;
        public static String lname_fetch = "LastName";

        public static String Gender_data;
        public static String gender_fetch = "Gender";

        public static String DOB_data;
        public static String dob_fetch = "DOB";

        public static String lvalue;
        public static String Value_fetch = "Value";

        public static String AdmitTypeData;
        public static String AdmitType_fetch = "AdmitType";

        public static String HospitalistData;
        public static String Hospitalist_fetch = "Hospitalist";

        public static String HoldReason_data;
        public static String holdreason_fetch = "HoldReason";

        public static String DeclineReason_data;
        public static String declinereason_fetch = "DeclineReason";



    }
}
