using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using ToDoManager.Controllers;
using ToDoManager.Entities;

namespace TestToDoAPI
{
    public class UnitTestCategory
    {

        private static  readonly CategoryController controller = new();

        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Obtains all categories
        /// </summary>
        [Test]
        public void TestGetAllCategories()
        {
            ActionResult result = controller.Get();

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        /// <summary>
        /// Gets Category #1
        /// </summary>
        [Test]
        public void TestGetCategoryNumber1()
        {
            ActionResult result = controller.Get(1);

            Assert.IsInstanceOf<OkObjectResult>(result);


        }

        /// <summary>
        /// Gets Category #0 (should fail)
        /// </summary>
        [Test]
        public void TestGetCategoryNumber0()
        {
            ActionResult result = controller.Get(0);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Adds a new category
        /// </summary>
        [Test]
        public void TestAddCategoryOk()
        {

            Category extra = new()
            {
                Name = "Extra",
                Description = "Extra category"
            };

            ActionResult result = controller.AddCategory(extra);

            Assert.IsInstanceOf<CreatedAtActionResult>(result);

        }

        /// <summary>
        /// Tries to add a not valid category (should fail)
        /// </summary>
        [Test]
        public void TestAddCategoryFail1()
        {

            Category extra = new()
            {
                Name = string.Empty,
                Description = "Extra category"
            };

            ActionResult result = controller.AddCategory(extra);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Tries to add a not valid category (should fail)
        /// </summary>
        [Test]
        public void TestAddCategoryFail2()
        {

            Category extra = new()
            {
                Name = "Extra",
                Description = string.Empty
            };

            ActionResult result = controller.AddCategory(extra);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Tests filtered search
        /// </summary>
        [Test]
        public void TestFilteredSearch()
        {
            OkObjectResult result = (OkObjectResult)controller.SearchCategory("Do it");

            Assert.Greater(((List<BaseItem>)result.Value).Count, 0);

        }

        /// <summary>
        /// Tests filtered search
        /// </summary>
        [Test]
        public void TestFilteredSearch0()
        {
            OkObjectResult result = (OkObjectResult)controller.SearchCategory("QWERTY");

            Assert.AreEqual(((List<BaseItem>)result.Value).Count, 0);

        }

        /// <summary>
        /// Test deleting an existing category
        /// </summary>
        [Test]
        public void TestDeleteExistingCategory()
        {

            ActionResult result = controller.DeleteCategory(3);

            Assert.IsInstanceOf<OkObjectResult>(result);

        }

        /// <summary>
        /// Test deleting an existing category (should fail)
        /// </summary>
        [Test]
        public void TestDeleteExistingCategoryInToDo()
        {

            ActionResult result = controller.DeleteCategory(1);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Test deleting not existing category
        /// </summary>
        [Test]
        public void TestDeleteNotExistingCategory()
        {

            ActionResult result = controller.DeleteCategory(0);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        [Test]
        /// <summary>
        /// Test updating existing category
        /// </summary>
        public void TestUpdateExistingCategory()
        {
            int id = 1;

            OkObjectResult result = (OkObjectResult)controller.Get(id);

            Category c = (Category)result.Value;

            c.Description = "Do it later";

            ActionResult ar = controller.UpdateCategory(id, c);

            Assert.IsInstanceOf<OkObjectResult>(ar);

        }

        [Test]
        /// <summary>
        /// Test updating not existing category
        /// </summary>
        public void TestUpdateNotExistingCategory()
        {

            Category c = new() { Name = "Pepe", Description = "Pepe" };

            ActionResult ar = controller.UpdateCategory(0, c);

            Assert.IsInstanceOf<BadRequestObjectResult>(ar);

        }

    }
}