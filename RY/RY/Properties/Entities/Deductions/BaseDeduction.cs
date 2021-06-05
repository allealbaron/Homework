namespace RY
{
    /// <summary>
    /// Base Deduction
    /// </summary>
    public class BaseDeduction : IDeduction
    {

        /// <summary>
        /// Deduction Name
        /// </summary>
        /// <param name="payroll">PayRoll</param>
        /// <returns>Deduction Name and deduction</returns>
        public string Name(float payroll)
        {
            return string.Empty;
        }

        /// <summary>
        /// Calculates total deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Total deduction</returns>
        public float CalculateTotalDeduction(float payroll)
        {
            return 0;
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">payroll</param>
        /// <returns>Deduction</returns>    
        public float CalculateDeduction(float payroll)
        {
            return 0;
        }

    }

}


