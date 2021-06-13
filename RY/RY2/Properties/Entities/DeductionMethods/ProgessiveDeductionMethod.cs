using System;
using System.Collections.Generic;

namespace RY2
{

    /// <summary>
    /// Progressive deduction method
    /// Implements <see cref="IDeductionMethod"/>
    /// </summary>
    public class ProgressiveDeductionMethod : IDeductionMethod
    {

        #region "Class Members"

        /// <summary>
        /// Sections
        /// </summary>
        private readonly List<Tuple<float, float>> sections;

        #endregion

        #region "Class Constructor"

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="sections">Sections</param>
        public ProgressiveDeductionMethod(List<Tuple<float, float>> sections)
        {
            this.sections = sections;
        }

        #endregion

        #region "Interface IDeductionMethod Implementation"

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public float CalculateDeduction(float payroll)
        {

            float result = 0;
            float tempValue = payroll;

            for (int i = sections.Count - 1; i >= 0; i--)
            {
                if (tempValue - sections[i].Item1 > 0)
                {
                    result += ((tempValue- sections[i].Item1) * sections[i].Item2);
                    tempValue = sections[i].Item1;
                }
            }

            return result;

        }

        #endregion

    }
}
