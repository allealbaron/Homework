using System.Collections.Generic;
using System.Linq;

namespace Sp
{
    /// <summary>
    /// Task 2
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Gets the array A and returns the number of movements
        /// to make every item different and with 1 unit of difference
        /// betweeen each item
        /// </summary>
        /// <param name="A">Array</param>
        /// <returns>Number of movements</returns>
        static public int Solution(int[] A)
        {

            int movements = 0;

            List<int> itemsAsList = A.ToList<int>();

            var indexedItems = itemsAsList.Select((item, index) => new { item, index });

            var groupedItems = indexedItems.GroupBy(s => s.item).Where(g => g.Count() > 1);

            int firstFreePlace = 1;

            while (groupedItems.Any())
            {

                foreach (var repeatedItem in groupedItems)                                
                {

                    int itemToReplace = repeatedItem.Key;

                    for (int iteration = 0; iteration < repeatedItem.Count()-1; iteration++)
                    {
                        
                        int item = itemToReplace;
                        int i = firstFreePlace;
                        
                        bool found = false;
                        
                        while (!found && i < item)
                        {
                            if (!itemsAsList.Contains(i))
                            {
                                found = true;
                                firstFreePlace = i + 1;
                                while (item > i)
                                {
                                    item--;
                                    movements++;
                                }
                            }
                            i++;
                        }

                        if (!found)
                        {
                            while (!found)
                            {
                                if (!itemsAsList.Contains(i))
                                {
                                    found = true;
                                    firstFreePlace = i + 1;
                                    while (item < i)
                                    {
                                        item++;
                                        movements++;
                                    }
                                }
                                i++;
                            }
                        }

                        itemsAsList[itemsAsList.IndexOf(itemToReplace)] = item;
                    }
                }
            }

            return movements;

        }
    }
}
