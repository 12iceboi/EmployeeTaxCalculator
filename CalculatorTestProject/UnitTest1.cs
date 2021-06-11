using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using EmployeeTaxCalculator;

/// <summary>
/// Unit Testing for Calculator Project
/// </summary>
namespace CalculatorTestProject
{/// <summary>
/// Class Tests
/// </summary>
    public class Tests
    {/// <summary>
    /// Setup for Test
    /// </summary>
        private List<PayRecord> _records;

        [SetUp]
        public void Setup()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\net5.0", "");

            string filePath = path + "\\import\\employee-payroll-data.csv";

            _records = CsvImporter.ImportPayRecords(filePath);
        }
        /// <summary>
        /// Testing Import function
        /// </summary>
        [Test]
        public void TestImport()
        {
            //Assert.Pass();

            Assert.IsNotNull(_records);
            Assert.AreEqual(_records.Count, 5);
            Assert.IsNotEmpty(_records);
        }
        /// <summary>
        /// Testing Gross function
        /// </summary>
        [Test]
        public void TestGross()
        {
            //Checking the first employee
            double actual = Math.Round(_records[0].Gross, 2);
            double expected = 652;
            Assert.AreEqual(expected, actual);

            //Checking the second employee
            actual = Math.Round(_records[1].Gross, 2);
            expected = 418;
            Assert.AreEqual(expected, actual);

            //Checking the third employee
            actual = Math.Round(_records[2].Gross, 2);
            expected = 2202;
            Assert.AreEqual(expected, actual);

            //Checking the fourth employee
            actual = Math.Round(_records[3].Gross, 2);
            expected = 1104;
            Assert.AreEqual(expected, actual);

            //Checking the fifth employee
            actual = Math.Round(_records[4].Gross, 2);
            expected = 1797.45;
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Testing Tax function
        /// </summary>
        [Test]
        public void TestTax()
        {
            //Checking the first employee
            double actual = Math.Round(_records[0].Tax, 2);
            double expected = 182.45;
            Assert.AreEqual(expected, actual);

            //Checking the second employee
            actual = Math.Round(_records[1].Tax, 2);
            expected = 133.76;
            Assert.AreEqual(expected, actual);

            //Checking the third employee
            actual = Math.Round(_records[2].Tax, 2);
            expected = 754.91;
            Assert.AreEqual(expected, actual);

            //Checking the fourth employee
            actual = Math.Round(_records[3].Tax, 2);
            expected = 165.60;
            Assert.AreEqual(expected, actual);

            //Checking the fifth employee
            actual = Math.Round(_records[4].Tax, 2);
            expected = 597.14;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testing Net function
        /// </summary>
        [Test]
        public void TestNet()
        {
            //Checking the first employee
            double actual = Math.Round(_records[0].Net, 2);
            double expected = 469.55;
            Assert.AreEqual(expected, actual);

            //Checking the second employee
            actual = Math.Round(_records[1].Net, 2);
            expected = 284.24;
            Assert.AreEqual(expected, actual);

            //Checking the third employee
            actual = Math.Round(_records[2].Net, 2);
            expected = 1447.09;
            Assert.AreEqual(expected, actual);

            //Checking the fourth employee
            actual = Math.Round(_records[3].Net, 2);
            expected = 938.40;
            Assert.AreEqual(expected, actual);

            //Checking the fifth employee
            actual = Math.Round(_records[4].Net, 2);
            expected = 1200.31;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testing Export function
        /// </summary>
        [Test]
        public void TestExport()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug\net5.0", "");

            string exportFile = (DateTime.Now.Ticks).ToString() + "-records.csv";

            string exportPath = path + "\\export\\" + exportFile;

            PayRecordWriter.Write(exportPath, _records, false);

            bool fileExists = File.Exists(exportPath);

            Assert.IsTrue(fileExists);
        }
    }
}