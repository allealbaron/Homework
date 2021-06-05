
namespace RY
{
    /// <summary>
    /// Universal Social Charge (Ireland)
    /// </summary>
    public class IRUniversalSocialChargeDeduction : Deduction
    {

        /// <summary>
        /// Income boundary
        /// </summary>
        private const int INCOME_BOUNDARY = 500;

        /// <summary>
        /// First group percentage
        /// </summary>
        private const float FIRST_GROUP_PERCENTAGE = 0.07F;

        /// <summary>
        /// Second group percentage
        /// </summary>
        private const float SECOND_GROUP_PERCENTAGE = 0.08F;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">base deduction</param>
        public IRUniversalSocialChargeDeduction(IDeduction ideduction) : base(ideduction)
        {
            name = "Universal Social Charge (Ireland)";
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


