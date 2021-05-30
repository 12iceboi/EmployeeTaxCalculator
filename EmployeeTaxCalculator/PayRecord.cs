using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaxCalculator
{/// <summary>
/// This is the main parent class for Resident& Working Holiday PayRecord.
/// </summary>
    public abstract class PayRecord
    {
        
        /// <summary>
        /// Create backing field variables for class.
        /// </summary>
        protected double[] _hours;
        protected double[] _rates;

        /// <summary>
        /// Creating properties for Pay Record Class.
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        public double Gross
        {
            get
            {
                double totalGross = 0;
                for (int i = 0; i < _hours.Length; i++)
                {
                    totalGross += _hours[i] * _rates[i];
                }
                return Math.Round(totalGross,2);
            }
        }
        /// <summary>
        /// Abstract properties.
        /// </summary>
        public abstract double Tax
        {
            get;
            //Derived value calculated from the TaxCalculator Method base
            //on the type of record (resident or working holiday)
        }

        public double Net
        {
            get
            {
                double net = Gross - Tax;
                return Math.Round(net,2);
            }
            //Derived value calculated from Gross - Tax (net = gross - tax)
        }

        /// <summary>
        /// Create constructor for PayRecord Class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        public PayRecord(int id, double[] hours, double[] rates)
        {
            Id = id;
            _hours = hours;
            _rates = rates;
        }

        /// <summary>
        /// Create method for Pay Record Class.
        /// </summary>
        /// <returns></returns>
        public virtual string GetDetails()
        {
            string details = "";
            details += "---------- EMPLOYEE: " + Id +" ----------" + "\n";
            details += "GROSS: " + "$"+ Convert.ToDecimal(Gross).ToString("#,##0.00") + "\n";
            details += "NET:   " + "$"+ Convert.ToDecimal(Net).ToString("#,##0.00") + "\n";
            details += "TAX:   " + "$"+ Convert.ToDecimal(Tax).ToString("#,##0.00") + "\n";
            return details;
        }

    }
}
