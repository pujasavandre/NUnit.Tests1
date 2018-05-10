using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{

    [TestFixture]
    public class LoginTestCase:Baseclass
    {
        public static String testcaseName = "LoginTest";
        loginpa login = new loginpa();

        [Test, TestCaseSource("getdata")]
        public void loginTC(Dictionary<String,String> data)
        {
        username = data[Username];
        password = data[Password];
        hospital = data[Hospital];
       
            login.dologin();
            login.logout();
        }

        public static Object[][] getdata()
        {
            return TestUtil.getTestdata2(xls, testcaseName);
        }

    }


}
