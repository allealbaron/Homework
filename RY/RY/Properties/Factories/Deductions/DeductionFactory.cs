using System;

namespace RY
{
    /// <summary>
    /// Deductions Factory
    /// </summary>
    public class DeductionFactory
    {
        /// <summary>
        /// Returns the (Pattern Decorator) object containing all the 
        /// taxes for a country
        /// </summary>
        /// <param name="country">Country</param>
        /// <returns>Deductions</returns>
        public static IDeduction GetDeduction(string country)
        {
            return country switch
            {
                "DE" => new DECompulsoryPensionContributionDeduction(new DEIncomeTaxDeduction(new BaseDeduction())),
                "IT" => new ITIncomeTaxDeduction(new ITINPSContributionDeduction(new BaseDeduction())),
                "IR" => new IRCompulsoryPensionContributionDeduction(new IRIncomeTaxDeduction(
                                new IRUniversalSocialChargeDeduction(new BaseDeduction()))),
                _ => throw new Exception("Not implemented"),
            };
        }
    }

}


