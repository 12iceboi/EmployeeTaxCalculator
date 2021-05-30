using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaxCalculator
{/// <summary>
/// Working Holiday Pay Record Class.
/// </summary>
    public class WorkingHolidayPayRecord:PayRecord
    {
        /// <summary>
        /// Create backing fields.
        /// </summary>
        private int _visa;

        private int _yearToDate;
        /// <summary>
        /// Define Properties for class
        /// </summary>
        public int Visa
        {
            get
            {
                return _visa;
            }
            private set
            {
                _visa = value;
            }
        }

        public int YearToDate
        {
            get
            {
                return ((int)(_yearToDate + Gross));
            }
            private set
            {
                _yearToDate = value;
            }
        }
        /// <summary>
        /// Overriding properties derived from parent class.
        /// </summary>
        public override double Tax
        {
            get
            {
                double result = 0;

                result = TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);

                return result;
            }
           
        }

        /// <summary>
        /// Creating Constructor for WorkingHolidayPayRecord Class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        /// <param name="visa"></param>
        /// <param name="yearToDate"></param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base (id, hours, rates)
        {
            Visa = visa;
            YearToDate = yearToDate;
        }

     

        /// <summary>
        /// This method derived from base class.
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            string details = base.GetDetails();
            details += "VISA:  " + Visa + "\n";
            details += "YTD:   " + "$" + Convert.ToDecimal(YearToDate).ToString("#,##0.00") + "\n";
            return details;
        }
    }
}
