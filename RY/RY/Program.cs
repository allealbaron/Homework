using System;

namespace RY
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main Thread
        /// </summary>
        /// <param name="args">Args</param>
        static void Main(string[] args)
        {

            IDeduction deductions = DeductionFactory.GetDeduction(args[0]);

            PayRoll payRoll = new(deductions);

            payRoll.EmployeeLocation = args[0];
            payRoll.HourlyRate = float.Parse(args[1]);
            payRoll.HoursWorked = int.Parse(args[2]);

            Console.WriteLine(payRoll.GetLocationLine());
            Console.WriteLine(payRoll.GetGrossAmountLine());
            Console.WriteLine(payRoll.GetDeductionsDescription());
            Console.WriteLine(payRoll.GetNetAmountLine());

        }

    }

}


