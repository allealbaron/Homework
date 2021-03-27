using System;
using System.Collections.Generic;

namespace PE
{
        /// <summary>
        /// Column from CSV file
        /// </summary>
        public class Column : IComparable<Column>
        {

            /// Column Name
            public string Name;

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
    }