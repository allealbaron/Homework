using System;
using System.Collections.Generic;
using System.Linq;

namespace Market
{
    public class Market
    {
        /// <summary>
        /// Realizes then market signdown process
        /// </summary>
        /// <param name="TotalOrder">Totla order</param>
        /// <param name="MarketElements">List of <see cref="MarketElement"/></param>
        /// <returns>The market signdown processed</returns>
        public List<MarketElement> MarketSigndown(float TotalOrder, List<MarketElement> MarketElements)
        {

            return CalculateSignedLines(TotalOrder, MarketElements);

        }

        /// <summary>
        /// Assign signed lines value in a List of <see cref="MarketElement"/>
        /// </summary>
        /// <param name="ratio">Ratio</param>
        /// <param name="MarketElements">MarketElements</param>
        /// <returns>List of <see cref="MarketElement"/> with assigned  signledlines</returns>
        private List<MarketElement> AssignSignedLines(float ratio, List<MarketElement> MarketElements)
        {
            
            foreach (MarketElement u in MarketElements)
            {
                u.SignedLine = u.WrittenLine * ratio;
            }

            return MarketElements;

        }

        /// <summary>
        /// For a <paramref name="TotalOrder"/> returns the ratio
        /// </summary>
        /// <param name="TotalOrder">Total Order</param>
        /// <param name="MarketElements">Ratio</param>
        /// <returns>Ratio</returns>
        private float GetRatio(float TotalOrder, List<MarketElement> MarketElements)
        {
            return (TotalOrder / MarketElements.Sum(p => p.WrittenLine));
        }

        /// <summary>
        /// Calculate signed lines and retry the process if any MarketElement does not 
        /// get its minimum share
        /// </summary>
        /// <param name="TotalOrder">Total order</param>
        /// <param name="MarketElements">List of MarketElements</param>
        /// <returns>List of MarketElements with their signed lines calculated</returns>
        private List<MarketElement> CalculateSignedLines(float TotalOrder, List<MarketElement> MarketElements)
        {

            if (MarketElements.Count > 0)
            {
                float ratio = GetRatio(TotalOrder, MarketElements);

                if (ratio <= 1)
                {

                    MarketElements = AssignSignedLines(ratio, MarketElements);

                }

                MarketElement failedItem = CheckMinimumsEarned(MarketElements);

                List<MarketElement> failedItems = new List<MarketElement>();

                while (!(failedItem is null) && MarketElements.Count > 0)
                {

                    failedItems.Add(failedItem);

                    failedItem.SignedLine = failedItem.MinLine;

                    MarketElements.Remove(failedItem);

                    TotalOrder -= failedItem.SignedLine;
                    
                    MarketElements = AssignSignedLines(GetRatio(TotalOrder, MarketElements), MarketElements);

                    failedItem = CheckMinimumsEarned(MarketElements);

                }

                if (MarketElements.Count == 0)
                {
                    throw new Exception("Failed configuration");
                }
                else
                {
                    MarketElements.AddRange(failedItems);
                }
            }

            return MarketElements;

        }

        /// <summary>
        /// Checks if every MarketElement has its minimum calculated
        /// </summary>
        /// <param name="MarketElements">MarketElements</param>
        /// <returns>If an MarketElement (or more) has not its minimum, function
        /// returns the first item which does not have its minimum</returns>
        private MarketElement CheckMinimumsEarned(List<MarketElement> MarketElements)
        {
            return (MarketElements.Where(p => p.SignedLine < p.MinLine).FirstOrDefault());
        }

    }
}


