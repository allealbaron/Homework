using System;

namespace RY
{
    /// <summary>
    /// Implements IDeduction
    /// </summary>
    public abstract class Deduction : IDeduction
    {            
        /// <summary>
        /// Base Deduction
        /// </summary>
        private readonly IDeduction deduction;

        /// <summary>
        /// Name
        /// </summary>
        protected string name = String.Empty;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="ideduction">IDeduction</param>
        public Deduction(IDeduction ideduction)
        {
            deduction = ideduction;
        }

        /// <summary>
        /// Deduction Name
        /// </summary>
        /// <param name="payroll">PayRoll</param>
        /// <returns>Deduction Name and deduction</returns>
        public string Name(float payroll)
        {
            return deduction.Name(payroll) + "\n" + String.Format("{0} : {1}", name, CalculateDeduction(payroll));
        }

        /// <summary>
        /// Calculates total deduction
        /// </summary>
        /// <param name="payroll">Payroll</param>
        /// <returns>Total deduction</returns>
        public float CalculateTotalDeduction(float payroll)
        {
            return deduction.CalculateTotalDeduction(payroll) + CalculateDeduction(payroll);
        }

        /// <summary>
        /// Calculates deduction
        /// </summary>
        /// <param name="payroll">payroll</param>
        /// <returns>Deduction</returns>    
        public abstract float CalculateDeduction(float payroll);

    }

}


