using System;
using System.Collections.Generic;

namespace RY2
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
  
            List<IDeduction> deductions = DeductionsFactory.GetDeductions(args[0]);

            PayRoll payRoll = new(deductions)
            {
                EmployeeLocation = args[0],
                HourlyRate = float.Parse(args[1]),
                HoursWorked = int.Parse(args[2])
            };

            Console.WriteLine(payRoll.GetLocationLine());
            Console.WriteLine(payRoll.GetGrossAmountLine());
            Console.WriteLine(payRoll.GetDeductionsDescription());
            Console.WriteLine(payRoll.GetNetAmountLine());

        }

    }

}


