using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ToDoManager.Entities;
using ToDoManager.Services;

namespace ToDoManager.Controllers
{
    /// <summary>
    /// Category Controller
    /// </summary>
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {

        /// <summary>
        /// Service
        /// </summary>
        private static readonly CategoryService service = new();

        /// <summary>
        /// Class builder
        /// </summary>
        public CategoryController()
        {
        }

        /// <summary>
        /// Adds a new Category
        /// </summary>
        /// <param name="newCategory">Category to add</param>
        /// <returns>Http result</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddCategory(Category newCategory)
        {

            try
            {
                Category result = (Category)service.Add(newCategory);
                return CreatedAtAction("Get", result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Updates category
        /// </summary>
        /// <param name="updatedCategory">Category to update</param>
        /// <returns>Http result</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateCategory([FromRoute] int id, Category updatedCategory)
        {

            try
            {
                Category result = (Category)service.Update(id, updatedCategory);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Deletes category
        /// </summary>
        /// <param name="id">Category's id to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory([FromRoute] int id)
        {

            try
            {
                service.Delete(id);
                return Ok(String.Format("Category with id {0} deleted succesfully", id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Searchs categories
        /// </summary>
        /// <param name="filter">Filter (Ignores case)</param>
        /// <returns>List of items where filter applies</returns>
        [HttpGet("Search/{filter}")]
        public ActionResult SearchCategory([FromRoute] string filter)
        {
            try
            {
                return Ok(service.SearchItems(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Return a category
        /// </summary>
        /// <param name="id">Category's id</param>
        /// <returns>Category</returns>
        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {

            try
            {
                return Ok(service.GetItem(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Return all the categories
        /// </summary>
        /// <returns>List of categories</returns>
        [HttpGet()]
        public ActionResult Get()
        {

            try
            {
                return Ok(service.GetAllItems().Select(p=> (Category)p).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
