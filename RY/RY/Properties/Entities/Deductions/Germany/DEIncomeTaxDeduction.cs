namespace RY
{
    /// <summary>
    /// Income Tax (Germany)
    /// </summary>
    public class DEIncomeTaxDeduction : Deduction
    {
        /// <summary>
        /// Income boundary
        /// </summary>
        private const int INCOME_BOUNDARY = 400;

        /// <summary>
        /// First group percentage
        /// </summary>
        private const float FIRST_GROUP_PERCENTAGE = 0.25F;

        /// <summary>
        /// Second group percentage
        /// </summary>
        private const float SECOND_GROUP_PERCENTAGE = 0.32F;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">base deduction</param>
        public DEIncomeTaxDeduction(IDeduction ideduction) : base(ideduction)
        {
            name = "Income Tax (Germany)";
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public override float CalculateDeduction(float payroll)
        {

            float result;

            if (payroll > INCOME_BOUNDARY)
            {
                result = (payroll - INCOME_BOUNDARY) * SECOND_GROUP_PERCENTAGE;
                result += INCOME_BOUNDARY * FIRST_GROUP_PERCENTAGE;
            }
            else
            {
                result = payroll * FIRST_GROUP_PERCENTAGE;
            }

            return result;

        }

    }

}


