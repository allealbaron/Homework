using System;

namespace ToDoManager.Entities
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category : BaseItem
    {
        /// <summary>
        /// Categories counter
        /// </summary>
        private static int CATEGORY_COUNTER = 0;
       
        /// <summary>
        /// Counter
        /// </summary>
        protected override int Counter
        {
            get
            {
                CATEGORY_COUNTER++;
                return CATEGORY_COUNTER;
            }
        }

        /// <summary>
        /// Clones Object
        /// </summary>
        /// <returns>Cloned object</returns>
        public override object Clone()
        {
            Category result = new();

            result._id = this.Id;
            result.Name = this.Name;
            result.Description = this.Description;

            return result;

        }

    }
}
