namespace RY2
{

    /// <summary>
    /// Simple deduction method
    /// Implements <see cref="IDeductionMethod"/>
    /// </summary>
    public class SimpleDeductionMethod : IDeductionMethod
    {

        #region "Class Members"

        /// <summary>
        /// Percentage
        /// </summary>
        private readonly float percentage;

        #endregion

        #region "Class Constructor"

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="percentage">Percentage</param>
        public SimpleDeductionMethod(float percentage)
        {
            this.percentage = percentage;
        }

        #endregion

        #region "Interface IDeductionMethod Implementation"

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public float CalculateDeduction(float payroll)
        {
            return payroll * percentage;
        }

        #endregion

    }
}
