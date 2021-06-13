using System;
using System.Collections.Generic;

namespace RY2
{
    /// <summary>
    /// Deductions Factory
    /// </summary>
    public class DeductionsFactory
    {
        /// <summary>
        /// Returns the (Pattern Decorator) object containing all the 
        /// taxes for a country
        /// </summary>
        /// <param name="country">Country</param>
        /// <returns>Deductions</returns>
        public static List<IDeduction> GetDeductions(string country)
        {
            return country switch
            {
                "DE" => GenerateGEDeductions(),
                "IT" => GenerateITDeductions(),
                "IE" => GenerateIEDeductions(),
                "ES" => GenerateESDeductions(),
                _ => throw new Exception("Not implemented"),
            };
        }

        /// <summary>
        /// Generates German Deductions
        /// </summary>
        /// <returns>List of German deductions</returns>
        private static List<IDeduction> GenerateGEDeductions()
        {
            List<IDeduction> result = new();

            result.Add(new Deduction("Compulsory Pension Contribution (Germany)",
                       new SimpleDeductionMethod(0.02F)));
            result.Add(new Deduction("Income Tax (Germany)",
                       new ProgressiveDeductionMethod(
                           new()
                           {
                               new Tuple<float, float>(0F, 0.25F),
                               new Tuple<float, float>(400F, 0.32F)
                           }
                            )));

            return result;

        }

        /// <summary>
        /// Generates Italian Deductions
        /// </summary>
        /// <returns>List of Italian deductions</returns>
        private static List<IDeduction> GenerateITDeductions()
        {
            List<IDeduction> result = new();

            result.Add(new Deduction("INPS Contribution (Italy)",
                       new SimpleDeductionMethod(0.0919F)));
            result.Add(new Deduction("Income Tax (Italy)",
                       new SimpleDeductionMethod(0.25F)));

            return result;

        }


        /// <summary>
        /// Generates Irish Deductions
        /// </summary>
        /// <returns>List of Irish deductions</returns>
        private static List<IDeduction> GenerateIEDeductions()
        {
            List<IDeduction> result = new();

            result.Add(new Deduction("Compulsory Pension Contribution (Ireland)",
                       new SimpleDeductionMethod(0.04F)));
            result.Add(new Deduction("Universal Social Charge (Ireland)",
                       new ProgressiveDeductionMethod(
                           new()
                           {
                               new Tuple<float, float>(0F, 0.07F),
                               new Tuple<float, float>(500F, 0.08F)
                           }
                            )));
            result.Add(new Deduction("Income Tax (Ireland)",
                       new ProgressiveDeductionMethod(
                           new()
                           {
                               new Tuple<float, float>(0F, 0.25F),
                               new Tuple<float, float>(600F, 0.40F)
                           }
                            )));

            return result;

        }

        /// <summary>
        /// Generates Spanish Deductions
        /// </summary>
        /// <returns>List of Irish deductions</returns>
        private static List<IDeduction> GenerateESDeductions()
        {
            List<IDeduction> result = new();

            result.Add(new Deduction("IRPF (Spain)",
                       new ProgressiveDeductionMethod(
                           new()
                           {
                               new Tuple<float, float>(0F, 0.19F),
                               new Tuple<float, float>(12450, 0.24F),
                               new Tuple<float, float>(20200, 0.30F),
                               new Tuple<float, float>(35200, 0.37F),
                               new Tuple<float, float>(60000, 0.45F)
                           }
                            )));       

            return result;

        }
    }

}


