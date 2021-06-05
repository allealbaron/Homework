namespace RY
{
    /// <summary>
    /// Compulsory Pension Contribution (Germany)
    /// </summary>
    public class DECompulsoryPensionContributionDeduction : Deduction
    {
        /// <summary>
        /// Compulsory pension contribution
        /// </summary>
        private const float COMPULSORY_PENSION_CONTRIBUTION = 0.02F;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">base deduction</param>
        public DECompulsoryPensionContributionDeduction(IDeduction ideduction) : base(ideduction)
        {
            name = "Compulsory Pension Contribution (Germany)";
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public override float CalculateDeduction(float payroll)
        {
            return payroll * COMPULSORY_PENSION_CONTRIBUTION;
        }

    }

}


