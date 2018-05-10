using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests2
{
    [TestFixture]
    public class TestUtil:Baseclass
    {
       
        public static Object[][] getTestdata2(Xls_Reader xls, String testcaseName)
        {
            String sheetName = "Loginsheet";
            int testStartRowNum = 1;
            while (!xls.getCellData(sheetName, 0, testStartRowNum).Equals(testcaseName))
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
