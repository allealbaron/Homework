using System;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Column from CSV file
/// </summary>
public class Column : IComparable<Column>
{

    /// Column Name
    public string Name
    { get; set; }

    /// Items stored in the column
    public List<string> Items;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name to give to the column</param>
    public Column(string name)
    {
        this.Name = name;
        this.Items = new List<string>();
    }

    /// <summary>
    /// Comparer by name
    /// </summary>
    /// <param name="other">Other <see cref="Column"/></param>
    /// <returns>Comparation</returns>
    public int CompareTo(Column other)
    {
        if (other == null)
        {
            return 1;
        }
        else
        {
            return Name.CompareTo(other.Name);
        }
    }

}

public class Challenge
{
    /// <summary>
    /// Imports a csv file (as string) and returns it
    ///as a <see cref="List{Column}"/>
    /// </summary>
    /// <param name="csv_data">CSV data</param>
    /// <returns>CSV data content but as a <see cref="List{Column}"/> 
    /// </returns>
    private static List<Column> ImportCsvData(string csv_data)
    {

        List<Column> result = new List<Column>();

        string[] everyRow = csv_data.Split("\n");

        foreach (string s in everyRow[0].Split(","))
        {
            result.Add(new Column(s));
        }

        int i = 1;

        while (i < everyRow.Length)
        {
            int j = 0;

            foreach (string s in everyRow[i].Split(","))
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
        StringBuilder result = new StringBuilder();

        foreach (Column c in columns)
        {
            result.Append(c.Name).Append(",");
        }

        result.Remove(result.Length - 1, 1);
        result.Append("\n");

        int i = 0;

        while (i < columns[0].Items.Count)
        {

            foreach (Column c in columns)
            {
                result.Append(c.Items[i]).Append(",");
            }

            result.Remove(result.Length - 1, 1);
            result.Append("\n");

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