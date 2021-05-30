using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaxCalculator
{/// <summary>
/// This is the main class of the solution.
/// </summary>
    class Program
    {   /// <summary>
        /// This is the Main method for Employee Tax Calculator.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<PayRecord> records;

            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug","");

            string filePath = path + "\\import\\employee-payroll-data.csv";

            records = CsvImporter.ImportPayRecords(filePath);

            string exportFile = (DateTime.Now.Ticks).ToString() + "-records.csv";

            string exportPath = path + "\\export\\" + exportFile;

            PayRecordWriter.Write(exportPath, records, true);
        }
    }
}


