using System;

namespace RY
{
    /// <summary>
    /// PayRoll
    /// </summary>
    public class PayRoll
    {
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
        private readonly IDeduction deductions;

        /// <summary>
        /// Class creator
        /// </summary>
        /// <param name="ideductions">Deductions</param>
        public PayRoll(IDeduction ideductions)
        {
            deductions = ideductions;
        }

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
            return deductions.CalculateTotalDeduction(GetGrossAmount());
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
            return deductions.Name(GetGrossAmount());
        }

        /// <summary>
        /// Returns Location Line
        /// </summary>
        /// <returns>Location Line</returns>
        public string GetLocationLine()
        {
            return String.Format("Employee Location: {0}", EmployeeLocation);
        }

        /// <summary>
        /// Returns Gross Amount Line
        /// </summary>
        /// <returns>Gross Amount Line</returns>
        public string GetGrossAmountLine()
        {
            return String.Format("Gross Amount: {0} €", GetGrossAmount());
        }

        /// <summary>
        /// Returns Net Amount Line
        /// </summary>
        /// <returns>Net Amount Line</returns>
        public string GetNetAmountLine()
        {
            return String.Format("Net Amount: {0} €", GetNetAmount());
        }

    }

}


