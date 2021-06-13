using System.Collections.Generic;
using System.Linq;

namespace RY2
{
    /// <summary>
    /// PayRoll
    /// </summary>
    public class PayRoll
    {

        #region "Class Members"

        /// <summary>
        /// Hourly Rate
        /// </summary>
        public float HourlyRate { get; set; }

        /// <summary>
        /// Hours worked
        /// </summary>
        public int HoursWorked { get; set; }

        /// <summary>
        /// Employee Location
        /// </summary>
        public string EmployeeLocation { get; set; }

        /// <summary>
        /// Deductions applied
        /// </summary>
        private readonly List<IDeduction> deductions;

        #endregion

        #region "Class constructor"

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="ideductions">Deductions</param>
        public PayRoll(List<IDeduction> ideductions)
        {
            deductions = ideductions;
        }

        #endregion

        #region "Class properties"

        /// <summary>
        /// Returns Gross Amount
        /// </summary>
        /// <returns>Gross Amount</returns>
        public float GetGrossAmount()
        {
            return HourlyRate * HoursWorked;
        }

        /// <summary>
        /// Returns Deductions
        /// </summary>
        /// <returns>Deductions</returns>
        public float GetDeductions()
        {
            return (from d in deductions select d.CalculateDeduction(GetGrossAmount())).Sum();
        }

        /// <summary>
        /// Returns Net Amount
        /// </summary>
        /// <returns>Net Amount</returns>
        public float GetNetAmount()
        {
            return GetGrossAmount() - GetDeductions();
        }

        /// <summary>
        /// Returns Deductions Description
        /// </summary>
        /// <returns>Deductions Description</returns>
        public string GetDeductionsDescription()
        {
            return string.Concat(from d in deductions select d.GetDeductionLine(GetGrossAmount()) + "\n");
        }

        /// <summary>
        /// Returns Location Line
        /// </summary>
        /// <returns>Location Line</returns>
        public string GetLocationLine()
        {
            return string.Format("Location: \t {0}", EmployeeLocation);
        }

        /// <summary>
        /// Returns Gross Amount Line
        /// </summary>
        /// <returns>Gross Amount Line</returns>
        public string GetGrossAmountLine()
        {
            return string.Format("Gross Amount: \t {0} €", string.Format("{0:.00}",GetGrossAmount()));
        }

        /// <summary>
        /// Returns Net Amount Line
        /// </summary>
        /// <returns>Net Amount Line</returns>
        public string GetNetAmountLine()
        {
            return string.Format("Net Amount: \t {0} €", string.Format("{0:.00}", GetNetAmount()));
        }

        #endregion

    }

}


