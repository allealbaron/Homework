using System.Collections.Generic;
using System.Linq;

namespace Sp
{
    /// <summary>
    /// Task 2
    /// </summary>
    public class Task3
    {
        /// <summary>
        /// Gets the arrays A and B and returns the number of possible
        /// indexes that allow to split them in two parts and every subarray
        /// sums the same 
        /// </summary>
        /// <param name="A">Array</param>
        /// <param name="B">Array</param>
        /// <returns>Number of possible items</returns>
        static public int Solution(int[] A, int[] B)
        {
            
            int solutions = 0;

            var indexedListA = A.ToList<int>().Select((item, index) => new { item, index });
            var indexedListB = B.ToList<int>().Select((item, index) => new { item, index });

            for (int i = 1; i < A.Length; i++)
            {

                int sumA1 = (from a in indexedListA where a.index < i select a.item).Sum();
                int sumA2 = (from a in indexedListA where a.index >= i select a.item).Sum();

                if (sumA1 == sumA2)
                {
                    int sumB1 = (from b in indexedListB where b.index < i select b.item).Sum();

                    if (sumA1 == sumB1)
                    {
                        int sumB2 = (from b in indexedListB where b.index >= i select b.item).Sum();

                        if (sumB1 == sumB2)
                        {
                            solutions++;
                        }
                    }
                }
            }

            return solutions;

        }

        /// <summary>
        /// Gets the arrays A and B and returns the number of possible
        /// indexes that allow to split them in two parts and every subarray
        /// sums the same 
        /// </summary>
        /// <param name="A">Array</param>
        /// <param name="B">Array</param>
        /// <returns>Number of possible items</returns>
        static public int BestSolution(int[] A, int[] B)
        {

            List<int> sumsALeft = new();
            List<int> sumsARight = new();
            List<int> sumsBLeft = new();
            List<int> sumsBRight = new();

            sumsALeft.Add(A[0]);
            sumsARight.Add(A[^1]);

            sumsBLeft.Add(B[0]);
            sumsBRight.Add(B[^1]);

            /// Sums precalculated
            for (int i = 1; i < A.Length; i++)
            {

                sumsALeft.Add(A[i]+ sumsALeft.Last());
                sumsARight.Insert(0, A[A.Length - i - 1] + sumsARight.First());

                sumsBLeft.Add(B[i] + sumsBLeft.Last());
                sumsBRight.Insert(0, B[B.Length - i - 1] + sumsBRight.First());

            }

            return (from a1 in sumsALeft.Select((item, index) => new { item, index })
                    from a2 in sumsARight.Select((item, index) => new { item, index })
                    from b1 in sumsBLeft.Select((item, index) => new { item, index })
                    from b2 in sumsBRight.Select((item, index) => new { item, index })
                    where
                        (a1.item == a2.item) && (a1.item == b1.item) && (a1.item == b2.item)
                        && (a1.index + a2.index == A.Length)
                        && (b1.index + b2.index == A.Length)
                    select a1.item).Count(); 

        }

    }
}
