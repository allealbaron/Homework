namespace RY
{
    /// <summary>
    /// Deduction Interface
    /// </summary>
    public interface IDeduction
    {
        /// <summary>
        /// Deduction Name
        /// </summary>
        /// <param name="payroll">PayRoll</param>
        /// <returns>Deduction Name and deduction</returns>
        string Name(float payroll);

        /// <summary>
        /// Calculates total deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Total deduction</returns>
        float CalculateTotalDeduction(float payroll);

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">payroll</param>
        /// <returns>Deduction</returns>           
        float CalculateDeduction(float payroll);

    }

}


