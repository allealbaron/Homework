using System;
using System.Text.Json.Serialization;

namespace ToDoManager.Entities
{
    /// <summary>
    /// ToDo
    /// </summary>
    public class ToDo : BaseItem
    {

        /// <summary>
        /// ToDos counter
        /// </summary>
        private static int TODO_COUNTER = 0;

        /// <summary>
        /// Creation time
        /// </summary>
        [JsonPropertyName("DateTime")]
        public DateTime DateTime;

        /// <summary>
        /// Category
        /// </summary>
        [JsonPropertyName("Category")]
        public Category Category { get; set; }

        protected override int Counter { 
            get 
            {
                TODO_COUNTER++;
                return TODO_COUNTER;
            } 
        }

        /// <summary>
        /// Indicates if a Category is valid
        /// </summary>
        /// <returns>True if it is valid</returns>
        public new bool IsValid()
        {
            return base.IsValid() && !Category.Equals(null);
        }

        /// <summary>
        /// Clones Object
        /// </summary>
        /// <returns>Cloned object</returns>
        public override object Clone()
        {
            ToDo result = new();

            result._id = this.Id;
            result.Name = this.Name;
            result.Description = this.Description;
            result.Category = this.Category;

            return result;
        }
    }
}
