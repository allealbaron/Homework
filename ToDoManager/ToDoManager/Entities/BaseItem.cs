using System;
using System.Text.Json.Serialization;

namespace ToDoManager.Entities
{
    /// <summary>
    /// Base Item
    /// </summary>
    public abstract class BaseItem : ICloneable
    {

        /// <summary>
        /// Id
        /// </summary>
        protected int _id;

        /// <summary>
        /// Counter (abstract property)
        /// </summary>
        protected abstract int Counter { get; }

        /// <summary>
        /// Id (Read only property)
        /// </summary>
        [JsonPropertyName("Id")]
        public int Id
        {
            get
            {
                if (_id == 0)
                {
                    _id = Counter;
                }

                return _id;
            }
            set 
            {
                _id = value;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        /// 
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Clones object
        /// </summary>
        /// <returns>Object cloned</returns>
        public abstract object Clone();

        /// <summary>
        /// Indicates if the object is valid
        /// </summary>
        /// <returns>True if it is valid</returns>

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Description);
        }

    }
}
