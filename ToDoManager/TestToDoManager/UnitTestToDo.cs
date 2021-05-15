using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToDoManager.Controllers;
using ToDoManager.Entities;

namespace TestToDoAPI
{
    public class UnitTestToDo
    {

        /// <summary>
        /// Category Controller
        /// </summary>
        private static readonly CategoryController categoryController = new();

        /// <summary>
        /// Todo Controller
        /// </summary>
        private static readonly ToDoController controller = new();

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
        /// Gets ToDo #1
        /// </summary>
        [Test]
        public void TestGetToDoNumber1()
        {
            ActionResult result = controller.Get(1);

            Assert.IsInstanceOf<OkObjectResult>(result);


        }

        /// <summary>
        /// Gets ToDo #0 (should fail)
        /// </summary>
        [Test]
        public void TestGetToDoNumber0()
        {
            ActionResult result = controller.Get(0);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Adds a new ToDo
        /// </summary>
        [Test]
        public void TestAddToDoOk()
        {

            ToDo extra = new()
            {
                Name = "Extra",
                Description = "Extra ToDo",
                DateTime = DateTime.Now,
                Category = (Category)((OkObjectResult)categoryController.Get(1)).Value
            };

            ActionResult result = controller.AddToDo(extra);

            Assert.IsInstanceOf<CreatedAtActionResult>(result);

        }

        /// <summary>
        /// Tries to add a not valid ToDo (should fail)
        /// </summary>
        [Test]
        public void TestAddToDoFail1()
        {

            ToDo extra = new()
            {
                Name = string.Empty,
                Description = "Extra ToDo"
            };

            ActionResult result = controller.AddToDo(extra);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Tries to add a not valid ToDo (should fail)
        /// </summary>
        [Test]
        public void TestAddToDoFail2()
        {

            ToDo extra = new()
            {
                Name = "Extra",
                Description = string.Empty
            };

            ActionResult result = controller.AddToDo(extra);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        /// <summary>
        /// Tests filtered search
        /// </summary>
        [Test]
        public void TestFilteredSearch()
        {
            OkObjectResult result = (OkObjectResult)controller.SearchToDo("oo");

            Assert.Greater(((List<BaseItem>)result.Value).Count, 0);

        }

        /// <summary>
        /// Tests filtered search
        /// </summary>
        [Test]
        public void TestFilteredSearch0()
        {
            OkObjectResult result = (OkObjectResult)controller.SearchToDo("QWERTY");

            Assert.AreEqual(((List<BaseItem>)result.Value).Count, 0);

        }

        /// <summary>
        /// Test deleting an existing ToDo
        /// </summary>
        [Test]
        public void TestDeleteExistingToDo()
        {
            int id = 3;

            ToDo t= (ToDo)((OkObjectResult)controller.Get(id)).Value;

            ActionResult result = controller.DeleteToDo(t.Id);

            Assert.IsInstanceOf<OkObjectResult>(result);

            Assert.IsInstanceOf<BadRequestObjectResult>(controller.Get(id));

        }

        /// <summary>
        /// Test deleting not existing ToDo
        /// </summary>
        [Test]
        public void TestDeleteNotExistingToDo()
        {

            ActionResult result = controller.DeleteToDo(0);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }

        [Test]
        /// <summary>
        /// Test updating existing ToDo
        /// </summary>
        public void TestUpdateExistingToDo()
        {
            int id = 2;
            string newDescription = "Do it later";

            OkObjectResult items = (OkObjectResult)controller.Get(id);

            ToDo c = (ToDo)items.Value;

            c.Description = newDescription;

            ActionResult result = controller.UpdateToDo(id, c);

            Assert.IsInstanceOf<OkObjectResult>(result);

            ToDo todoUpdated = (ToDo)(((OkObjectResult)controller.Get(id)).Value);

            Assert.AreEqual(todoUpdated.Description, newDescription);

        }

        [Test]
        /// <summary>
        /// Test updating not existing ToDo
        /// </summary>
        public void TestUpdateNotExistingToDo()
        {
            int id = 1000;

            OkObjectResult items = (OkObjectResult)controller.Get(id);

            ToDo c = new() { Name = "Pepe", Description = "Pepe" };

            ActionResult ar = controller.UpdateToDo(0, c);

            Assert.IsInstanceOf<BadRequestObjectResult>(ar);

        }

        [Test]
        /// <summary>
        /// Test assign Category
        /// </summary>
        public void TestAssignCategory()
        {
            int id = 1;
            int idCategory = 3;

            ActionResult ar = controller.UpdateToDoCategory(id, idCategory);

            Assert.IsInstanceOf<OkObjectResult>(ar);

            ToDo result = (ToDo)(((OkObjectResult)controller.Get(id)).Value) ;

            Assert.AreEqual(result.Category.Id, idCategory);

        }

        [Test]
        /// <summary>
        /// Test assign not existing Category (should fail)
        /// </summary>
        public void TestAssignNotExistingCategory()
        {
            int id = 1;
            int idCategory = 1000;

            ActionResult ar = controller.UpdateToDoCategory(id, idCategory);

            Assert.IsInstanceOf<BadRequestObjectResult>(ar);

            ToDo result = (ToDo)(((OkObjectResult)controller.Get(id)).Value);

            Assert.AreNotEqual(result.Category.Id, idCategory);

        }


    }
}