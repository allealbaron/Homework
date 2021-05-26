using System;
using System.Collections.Generic;
using System.Linq;
using ToDoManager.Entities;
using System.IO;
using System.Text.Json;

namespace ToDoManager.Services
{
    /// <summary>
    /// ToDo Service
    /// </summary>
    public class ToDoService : BaseService
    {
        /// <summary>
        /// Items list
        /// </summary>
        private static readonly List<BaseItem> items = new();

        /// <summary>
        /// Category Service
        /// </summary>
        private static readonly CategoryService categoryService = new();

        /// <summary>
        /// Class Builder
        /// </summary>
        public ToDoService()
        {

            if (Items.Count == 0)
            {

                items.AddRange(
                        JsonSerializer.Deserialize<List<ToDo>>(
                            File.ReadAllText(Path.Combine(ResourcesPath, "InitialToDos.json"))
                            )
                        );

            }
        }

        /// <summary>
        /// Items (Read only property)
        /// </summary>
        protected override List<BaseItem> Items => items;

        /// <summary>
        /// File Storage (Read only property)
        /// </summary>
        protected override string FileStorage => "FinalToDos.json";


        /// <summary>
        /// Updates ToDo
        /// </summary>
        /// <param name="id">ToDo's id</param>
        /// <param name="item">ToDo to update</param>
        /// <returns>ToDo's id</returns>

        public override BaseItem Update(int id, BaseItem item)
        {
            ToDo itemToUpdate = (ToDo)Items.Where(p => p.Id == id).FirstOrDefault();

            if (!(itemToUpdate is null) || !item.IsValid())
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Description = item.Description;
                itemToUpdate.Category = ((ToDo)item).Category;
                SaveItems();
                return itemToUpdate;
            }
            else
            {
                throw new Exception("Item not valid");
            }
        }

        /// <summary>
        /// Updates ToDo with category
        /// </summary>
        /// <param name="id">ToDo to update</param>
        /// <param name="categoryid">Category to assign</param>
        /// <returns></returns>
        public ToDo SetCategory(int id, int categoryid)
        {
            ToDo itemToUpdate = (ToDo)Items.Where(p => p.Id == id).FirstOrDefault();

            if (!(itemToUpdate is null))
            {
                Category category = (Category)categoryService.GetItem(categoryid);

                if (!(category is null))
                {

                    itemToUpdate.Category = category;
                    return (ToDo)itemToUpdate.Clone();

                }
                else
                {
                    throw new Exception("Category does not exist");
                }
            }
            else
            {
                throw new Exception("ToDo does not exist");
            }
        }
    }
}
