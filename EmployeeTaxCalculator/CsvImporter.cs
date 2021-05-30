using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaxCalculator
{/// <summary>
/// Creating CsvImportor ClaSS.
/// </summary>
    public class CsvImporter
    {/// <summary>
    /// Creating StreamReader variable to read csv file and store them in arrays.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {
            List<PayRecord> payRecords = new List<PayRecord>();

            string line;

            List<double> hours = new List<double>();
            List<double> rate = new List<double>();

            string yearToDate = "";
            string visa = "";


            string[] payRecordLine;

            int currentId;

            int previousId = -1;

            
            StreamReader inputFile = new StreamReader(file);

            line = inputFile.ReadLine();// this is the first line of date in the csv file i.e headers

            line = inputFile.ReadLine(); //this is second line of data in the csv file

            while (line != null)
            {
                //Do something with the data inside that line

                payRecordLine = line.Split(',');

                currentId = int.Parse(payRecordLine[0]);

                if (previousId != currentId && previousId != -1)
                {
                    payRecords.Add(CreatePayRecord(previousId, hours.ToArray(), rate.ToArray(), visa, yearToDate));
                    hours.Clear();
                    rate.Clear();
                    

                    previousId = int.Parse(payRecordLine[0]);

                }


                //for first student
                if (previousId == -1)
                {
                    previousId = int.Parse(payRecordLine[0]);
                }



                hours.Add(double.Parse(payRecordLine[1]));
                rate.Add(double.Parse(payRecordLine[2]));

                visa = payRecordLine[3];

                if (visa != "")
                {
                    yearToDate = payRecordLine[4];
                }

                line = inputFile.ReadLine();

            }

            //this is for creating last student record
            if (previousId != -1)
            {
                payRecords.Add(CreatePayRecord(previousId, hours.ToArray(), rate.ToArray(), visa, yearToDate));
            }




            return payRecords;
        }
        /// <summary>
        /// This is Create Pay Record method.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rate"></param>
        /// <param name="visa"></param>
        /// <param name="yearToDate"></param>
        /// <returns></returns>
        public static PayRecord CreatePayRecord(int id, double[] hours, double[] rate, string visa, string yearToDate)
        {

            if (visa == "" || visa == null)
            {
                ResidentPayRecord residentRecord = new ResidentPayRecord(id, hours, rate);
                return residentRecord;
            }
            else
            {
                WorkingHolidayPayRecord workingHolidayRecord = new WorkingHolidayPayRecord(Convert.ToInt32(id), hours, rate, Convert.ToInt32(visa), Convert.ToInt32(yearToDate));
                return workingHolidayRecord;

            }
        }

    }
}
