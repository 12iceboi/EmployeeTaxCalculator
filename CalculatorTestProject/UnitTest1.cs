using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using EmployeeTaxCalculator;

namespace CalculatorTestProject
{
    public class Tests
    {
        List<PayRecord> records;

        [SetUp]
        public void Setup()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\net5.0", "");

            string filePath = path + "\\import\\employee-payroll-data.csv";

            records = CsvImporter.ImportPayRecords(filePath);
        }

        [Test]
        public void TestImport()
        {
            //Assert.Pass();

            Assert.IsNotNull(records);
            Assert.AreEqual(records.Count, 5);
            Assert.IsNotEmpty(records);
        }

        [Test]
        public void TestGross()
        {
            //Checking the first employee
            double actual = Math.Round(records[0].Gross, 2);
            double expected = 652;
            Assert.AreEqual(expected, actual);

            //Checking the second employee
            actual = Math.Round(records[1].Gross, 2);
            expected = 418;
            Assert.AreEqual(expected, actual);

            //Checking the third employee
            actual = Math.Round(records[2].Gross, 2);
            expected = 2202;
            Assert.AreEqual(expected, actual);

            //Checking the fourth employee
            actual = Math.Round(records[3].Gross, 2);
            expected = 1104;
            Assert.AreEqual(expected, actual);

            //Checking the fifth employee
            actual = Math.Round(records[4].Gross, 2);
            expected = 1797.45;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestTax()
        {
            //Checking the first employee
            double actual = Math.Round(records[0].Tax, 2);
            double expected = 182.45;
            Assert.AreEqual(expected, actual);

            //Checking the second employee
            actual = Math.Round(records[1].Tax, 2);
            expected = 62.70;
            Assert.AreEqual(expected, actual);

            //Checking the third employee
            actual = Math.Round(records[2].Tax, 2);
            expected = 754.91;
            Assert.AreEqual(expected, actual);

            //Checking the fourth employee
            actual = Math.Round(records[3].Tax, 2);
            expected = 165.60;
            Assert.AreEqual(expected, actual);

            //Checking the fifth employee
            actual = Math.Round(records[4].Tax, 2);
            expected = 597.14;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void TestNet()
        {
            //Checking the first employee
            double actual = Math.Round(records[0].Net, 2);
            double expected = 469.55;
            Assert.AreEqual(expected, actual);

            //Checking the second employee
            actual = Math.Round(records[1].Net, 2);
            expected = 355.30;
            Assert.AreEqual(expected, actual);

            //Checking the third employee
            actual = Math.Round(records[2].Net, 2);
            expected = 1447.09;
            Assert.AreEqual(expected, actual);

            //Checking the fourth employee
            actual = Math.Round(records[3].Net, 2);
            expected = 938.40;
            Assert.AreEqual(expected, actual);

            //Checking the fifth employee
            actual = Math.Round(records[4].Net, 2);
            expected = 1200.31;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestExport()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\net5.0", "");

            string exportFile = (DateTime.Now.Ticks).ToString() + "-records.csv";

            string exportPath = path + "\\export\\" + exportFile;

            PayRecordWriter.Write(exportPath, records, false);

            bool fileExists = File.Exists(exportPath);

            Assert.IsTrue(fileExists);
        }
    }
}