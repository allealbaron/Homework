namespace RY
{
    /// <summary>
    /// INPS Contribution (Italy)
    /// </summary>
    public class ITINPSContributionDeduction : Deduction
    {
        /// <summary>
        /// INPS Contribution
        /// </summary>
        private const float INPS_CONTRIBUTION = 0.0919F;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">base deduction</param>
        public ITINPSContributionDeduction(IDeduction ideduction) : base(ideduction)
        {
            name = "INPS Contribution (Italy)";
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public override float CalculateDeduction(float payroll)
        {
            return payroll * INPS_CONTRIBUTION;
        }

    }

}


