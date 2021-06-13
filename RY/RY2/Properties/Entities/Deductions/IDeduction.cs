namespace RY2
{
    /// <summary>
    /// Deduction Interface
    /// </summary>
    public interface IDeduction
    {
        /// <summary>
        /// Deduction Name
        /// </summary>
        /// <returns>Deduction Name</returns>
        public string Name();

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>           
        public float CalculateDeduction(float payroll);

        /// <summary>
        /// Deduction Method
        /// </summary>
        /// <returns>Deduction Method</returns>
        public IDeductionMethod DeductionMethod();

        /// <summary>
        /// Deduction line
        /// </summary>
        /// <returns>Deduction line</returns>
        public string GetDeductionLine(float payroll);

    }

}


