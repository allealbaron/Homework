using System;
using System.Collections.Generic;
using System.Linq;
using ToDoManager.Entities;

namespace ToDoManager.Services
{
    /// <summary>
    /// Category Service
    /// </summary>
    public class CategoryService : BaseService
    {

        /// <summary>
        /// Items list
        /// </summary>
        private static readonly List<BaseItem> items = new();

        /// <summary>
        /// Class Builder
        /// </summary>
        public CategoryService()
        {
            if (Items.Count == 0)
            {
                Items.Add(new Category() { Name = "Urgent", Description = "Do it ASAP" });
                Items.Add(new Category() { Name = "High", Description = "Do it in the next two days" });
                Items.Add(new Category() { Name = "Medium", Description = "Do it during this week" });
                Items.Add(new Category() { Name = "Low", Description = "Do it this month" });
            }
        }

        /// <summary>
        /// Items (Read only property)
        /// </summary>
        protected override List<BaseItem> Items => items;

        /// <summary>
        /// Updates Category
        /// </summary>
        /// <param name="id">Category's id</param>
        /// <param name="item">Category to update</param>
        /// <returns>Category's id</returns>
        public override BaseItem Update(int id, BaseItem item)
        {
            Category itemToUpdate = (Category)Items.Where(p => p.Id == id).FirstOrDefault();

            if (!(itemToUpdate is null) || !item.IsValid())
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Description = item.Description;
                return itemToUpdate;
            }
            else
            {
                throw new Exception("Item not valid");
            }
        }

        /// <summary>
        /// Deletes an item
        /// </summary>
        /// <param name="id">Item</param>
        /// <returns>item's id</returns>
        public new int Delete(int id)
        {

            ToDoService toDoService = new();

            if (!toDoService.GetAllItems().Where(p => ((ToDo)p).Category.Id == id).Any())
            {
                return base.Delete(id);
            }
            else
            {
                throw new Exception("There are ToDo with this category, it can not be deleted");
            }
        }

    }
}
