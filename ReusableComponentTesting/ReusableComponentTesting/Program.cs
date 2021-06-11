using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;


namespace ReusableComponentTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Test> TestList = new List<Test>();

            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = path.Replace(@"\bin\Debug", "");

            string importPath = path + @"Import\Names.csv";
            string exportPath = path + @"Export\Export.csv";


            using (var reader = new StreamReader(importPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Test>();

                using (var writer = new StreamWriter(exportPath))
                using (var csv2 = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv2.WriteHeader<Test>();
                    csv2.NextRecord();
                    foreach (var record in records)
                    {
                        csv2.WriteRecords(records);
                        csv2.NextRecord();
                    }
                }
            }

        }
    }
}
