using System;

namespace RY2
{
    /// <summary>
    /// Implements IDeduction
    /// </summary>
    public class Deduction : IDeduction
    {

        #region "Class Members"

        /// <summary>
        /// Name
        /// </summary>
        protected string name = String.Empty;

        /// <summary>
        /// Deduction Method
        /// </summary>
        protected IDeductionMethod deductionMethod;

        #endregion

        #region "Class constructor"

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="deductionMethod">Deduction Method</param>
        public Deduction(string name, IDeductionMethod deductionMethod)
        {
            this.name = name;
            this.deductionMethod = deductionMethod; 
        }

        #endregion

        #region "Interface IDeduction Implementation "

        /// <summary>
        /// Deduction Name
        /// </summary>
        /// <returns>Deduction Name</returns>
        public string Name()
        {
            return name;
        }

        /// <summary>
        /// Calculates Deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction</returns>
        public float CalculateDeduction(float payroll)
        {
            return deductionMethod.CalculateDeduction(payroll);
        }

        /// <summary>
        /// Deduction Method
        /// </summary>
        /// <returns>Deduction Method</returns>
        public IDeductionMethod DeductionMethod()
        {
            return deductionMethod;
        }

        /// <summary>
        /// Gets deduction line
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Deduction line</returns>
        public string GetDeductionLine(float payroll)
        {
            return string.Format("{0}: \t {1} €", Name(), 
                        string.Format("{0:.00}", CalculateDeduction(payroll)));
        }

        #endregion

    }

}


