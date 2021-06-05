namespace RY
{
    /// <summary>
    /// Compulsory Pension Contribution (Ireland)
    /// </summary>
    public class IRCompulsoryPensionContributionDeduction : Deduction
    {
        /// <summary>
        /// Compulsory Pension Contribution percentage
        /// </summary>
        private const float COMPULSORY_PENSION_CONTRIBUTION_PERCENTAGE = 0.04F;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">base deduction</param>
        public IRCompulsoryPensionContributionDeduction(IDeduction ideduction) : base(ideduction)
        {
            name = "Compulsory Pension Contribution (Ireland)";
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public override float CalculateDeduction(float payroll)
        {
            return payroll * COMPULSORY_PENSION_CONTRIBUTION_PERCENTAGE;
        }

    }

}


