using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaxCalculator
{/// <summary>
/// TaxCalculator Class
/// </summary>
    public class TaxCalculator
    {
        /// <summary>
        /// Create method for Residential Employee Tax.
        /// </summary>
        /// <param name="gross"></param>
        /// <returns></returns>
        public static double CalculateResidentialTax(double gross)
        {
            double result;
            if (gross > -1 && gross <=72)
            {
                result = Math.Round((0.19 * gross - 0.19),2);
            }
            else if(gross > 72 && gross <= 361)
            {
                result = Math.Round((0.2342 * gross - 3.213),2);
            }
            else if (gross > 361 && gross <= 932)
            {
                result = Math.Round((0.3477 * gross - 44.2476), 2);
            }
            else if (gross > 932 && gross <= 1380)
            {
                result = Math.Round((0.345 * gross - 41.7311), 2);
            }
            else if (gross > 1380 && gross <= 3111)
            {
                result = Math.Round((0.39 * gross - 103.8657), 2);
            }
            else
            {
                result = Math.Round((0.47 * gross - 352.7888), 2);
            }
            return result;
        }

        /// <summary>
        /// Creating method for Working Holiday Employee Tax.
        /// </summary>
        /// <param name="gross"></param>
        /// <param name="yearToDate"></param>
        /// <returns></returns>
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            double result = 0;
            if (gross > -1 && gross <= 37000)
            {
                result = Math.Round((gross * 0.15),2);
            }
            else if (gross > 37000 && gross <= 90000)
            {
                result = Math.Round((gross * 0.32), 2);
            }
            else if (gross > 90000 && gross <= 180000)
            {
                result = Math.Round((gross * 0.37), 2);
            }
            else if (gross > 180000 && gross <= 9999999)
            {
                result = Math.Round((gross * 0.45), 2);
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
