namespace RY
{
    /// <summary>
    /// Income Tax (Italy)
    /// </summary>
    public class ITIncomeTaxDeduction : Deduction
    {
        /// <summary>
        /// Income Tax in Italy
        /// </summary>
        private const float INCOME_TAX_ITALY = 0.25F;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">base deduction</param>
        public ITIncomeTaxDeduction(IDeduction ideduction) : base(ideduction)
        {
            name = "Income Tax (Italy)";
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public override float CalculateDeduction(float payroll)
        {
            return payroll * INCOME_TAX_ITALY;
        }

    }

}


