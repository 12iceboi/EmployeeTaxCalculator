using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace EmployeeTaxCalculator
{/// <summary>
/// Creating Pay Record Writer Class.
/// </summary>
    public class PayRecordWriter
    {
        public static void Write(string file, IEnumerable<PayRecord> pays, bool writeToConsole)
        {
            using (var writer = new StreamWriter(file))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(pays);
                    //csv.Dispose();
                }
            }

            if (writeToConsole)
            {
                foreach (PayRecord record in pays)
                {
                    Console.WriteLine(record.GetDetails());
                }

            }
            
        }
    }
}
