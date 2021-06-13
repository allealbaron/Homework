namespace RY2
{
    /// <summary>
    /// Interface for deduction methods
    /// </summary>
    public interface IDeductionMethod
    {
        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction calculated/returns>
        float CalculateDeduction(float payroll);
    }
}
