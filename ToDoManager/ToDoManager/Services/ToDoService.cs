using System;
using System.Collections.Generic;
using System.Linq;
using ToDoManager.Entities;

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

                Items.Add(new ToDo()
                {
                    Name = "Task 1",
                    Description = "Clean your room",
                    DateTime = DateTime.Now,
                    Category = (Category)categoryService.GetItem(1)
                });
                Items.Add(new ToDo()
                {
                    Name = "Task 2",
                    Description = "Go to the dentist",
                    DateTime = DateTime.Now,
                    Category = (Category)categoryService.GetItem(1)
                });
                Items.Add(new ToDo()
                {
                    Name = "Task 3",
                    Description = "Meet John",
                    DateTime = DateTime.Now,
                    Category = (Category)categoryService.GetItem(1)
                });
                Items.Add(new ToDo()
                {
                    Name = "Task 4",
                    Description = "Read a book",
                    DateTime = DateTime.Now,
                    Category = (Category)categoryService.GetItem(1)
                });
            }

        }

        /// <summary>
        /// Items (Read only property)
        /// </summary>
        protected override List<BaseItem> Items => items;

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
