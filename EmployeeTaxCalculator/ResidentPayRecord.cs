using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaxCalculator
{/// <summary>
/// This is Resident Pay Record Class.
/// </summary>
    public class ResidentPayRecord:PayRecord
    {
        /// <summary>
        /// Override abstract property from Base Class.
        /// </summary>
        public override double Tax
        {
            get
            {
                double result = 0;

                result = TaxCalculator.CalculateResidentialTax(Gross);

                return result;
            }
        }

        /// <summary>
        /// Create constructor for ResidentPayRecord Class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base(id, hours, rates)
        {
           
        }

    }
}
