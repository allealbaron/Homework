using System;
using System.Text;
using System.Collections.Generic;

namespace PE
{
    /// <summary>
    /// Challenge 02
    /// </summary>
    public class Challenge02
    {

        /// <summary>
        /// Separator
        /// </summary>
        private const char SEPARATOR = ',';

        /// <summary>
        /// Return line
        /// </summary>
        private const char RETURN_LINE = '\n';

        /// <summary>
        /// Imports a csv file (as string) and returns it
        ///as a <see cref="List{Column}"/>
        /// </summary>
        /// <param name="csv_data">CSV data</param>
        /// <returns>CSV data content but as a <see cref="List{Column}"/> 
        /// </returns>
        private static List<Column> ImportCsvData(string csv_data)
        {

            List<Column> result = new();

            string[] everyRow = csv_data.Split(RETURN_LINE);

            foreach (string s in everyRow[0].Split(SEPARATOR))
            {
                result.Add(new Column(s));
            }

            int i = 1;

            while (i < everyRow.Length)
            {
                int j = 0;

                foreach (string s in everyRow[i].Split(SEPARATOR))
                {
                    result[j].Items.Add(s);
                    j++;
                }

                i++;

            }

            return result;

        }

        /// <summary>
        /// Takes a List<Column> and returns the list as a CSV
        /// (stored in a String)
        /// </summary>
        /// <param name="columns">Columns</param>
        /// <returns>Returns the collection as a CSV file (stored
        /// in a string) </returns>
        private static string ColumnsToString(List<Column> columns)
        {
            StringBuilder result = new();

            foreach (Column c in columns)
            {
                result.Append(c.Name).Append(SEPARATOR);
            }

            result.Remove(result.Length - 1, 1);
            result.Append(RETURN_LINE);

            int i = 0;

            while (i < columns[0].Items.Count)
            {

                foreach (Column c in columns)
                {
                    result.Append(c.Items[i]).Append(SEPARATOR);
                }

                result.Remove(result.Length - 1, 1);
                result.Append(RETURN_LINE);

                i++;

            }

            result.Remove(result.Length - 1, 1);

            return result.ToString();

        }

        /// <summary>
        /// Sorts CSV columns
        /// </summary>
        /// <param name="csv_data">Unordened CSV file</param>
        /// <returns>Ordened CSV file</returns>
        public static string SortCsvColumns(string csv_data)
        {

            List<Column> columns = ImportCsvData(csv_data);

            columns.Sort();

            return ColumnsToString(columns);

        }
    }
}