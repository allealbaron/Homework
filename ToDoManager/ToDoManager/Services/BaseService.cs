using System;
using System.Collections.Generic;
using System.Linq;
using ToDoManager.Entities;
using System.IO;
using System.Text.Json;

namespace ToDoManager.Services
{
    /// <summary>
    /// Base Service
    /// </summary>
    abstract public class BaseService
    {

        /// <summary>
        /// Resources path
        /// </summary>
        protected string ResourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

        /// <summary>
        /// List of items (abstract property)
        /// </summary>
        protected abstract List<BaseItem> Items { get; }

        /// <summary>
        /// File Storage
        /// </summary>
        protected abstract string FileStorage { get; }

        /// <summary>
        /// Adds an item
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns>new item's id</returns>
        public BaseItem Add(BaseItem item)
        {

            if (item.IsValid())
            {
                item.Id = Items.Count + 1;
                Items.Add(item);
                _ = item.Id;

                SaveItems();

                return (BaseItem)item.Clone();
            }
            else
            {
                throw new Exception("Not valid Item");
            }

        }

        /// <summary>
        /// Serialize the items as a JSON File
        /// </summary>
        protected void SaveItems()
        {
            string filePath = Path.Combine(ResourcesPath, FileStorage);
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.WriteAllText(filePath, JsonSerializer.Serialize(Items));

        }

        /// <summary>
        /// Updates an item
        /// </summary>
        /// <param name="id">Item's id</param>
        /// <param name="item">Item to update</param>
        /// <returns>Updated item</returns>
        public abstract BaseItem Update(int id, BaseItem item);

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="id">Item</param>
        /// <returns>item's id</returns>
        public int Delete(int id)
        {
            if (Items.Where(t => t.Id == id).Any())
            {
                _ = Items.RemoveAll(t => t.Id == id);
                SaveItems();
                return id;
            }
            else
            {
                throw new Exception("Item does not exist");
            }
        }

        /// <summary>
        /// Search items using a filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>filtered items</returns>
        public List<BaseItem> SearchItems(string filter)
        {

            List<BaseItem> result = new();

            foreach (BaseItem item in Items.Where(
                        p => p.Name.Contains(filter, StringComparison.InvariantCultureIgnoreCase) ||
                        p.Description.Contains(filter, StringComparison.InvariantCultureIgnoreCase)))
            {
                result.Add((BaseItem)item.Clone());
            }

            return result;

        }

        /// <summary>
        /// Gets an item
        /// </summary>
        /// <param name="id">Item's id</param>
        /// <returns>Item or default value</returns>
        public BaseItem GetItem(int id)
        {
            BaseItem result = Items.Where(t => t.Id == id).FirstOrDefault();

            if (!(result is null))
            {
                return (BaseItem)result.Clone();
            }
            else
            {
                throw new Exception("Item does not exist");
            }

        }

        /// <summary>
        /// Gets all items
        /// </summary>
        /// <returns>Returns all items</returns>
        public List<BaseItem> GetAllItems()
        {
            List<BaseItem> result = new();

            foreach (BaseItem item in Items)
            {
                result.Add((BaseItem)item.Clone());
            }

            return result;

        }

    }
}
