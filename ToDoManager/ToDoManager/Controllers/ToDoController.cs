using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ToDoManager.Entities;
using ToDoManager.Services;

namespace ToDoManager.Controllers
{
    /// <summary>
    /// ToDo Controller
    /// </summary>
    [ApiController]
    [Route("todo")]
    public class ToDoController : ControllerBase
    {

        /// <summary>
        /// Service
        /// </summary>
        private static readonly ToDoService service = new();

        /// <summary>
        /// Class builder
        /// </summary>
        public ToDoController()
        {
        }

        /// <summary>
        /// Adds a new ToDo
        /// </summary>
        /// <param name="newToDo">ToDo to add</param>
        /// <returns>Http result</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddToDo(ToDo newToDo)
        {

            try
            {
                ToDo result = (ToDo)service.Add(newToDo);
                return CreatedAtAction("Get", result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Updates ToDo
        /// </summary>
        /// <param name="id">ToDo's id</param>
        /// <param name="updatedToDo">ToDo to update</param>
        /// <returns>Http result</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateToDo([FromRoute] int id,ToDo updatedToDo)
        {

            try
            {
                ToDo result = (ToDo)service.Update(id, updatedToDo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Deletes ToDo
        /// </summary>
        /// <param name="id">ToDo's id to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteToDo([FromRoute] int id)
        {
            try
            {
                service.Delete(id);
                return Ok(String.Format("ToDo with id {0} deleted succesfully", id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Searchs ToDo
        /// </summary>
        /// <param name="filter">Filter (Ignores case)</param>
        /// <returns>List of items where filter applies</returns>
        [HttpGet("Search/{filter}")]
        public ActionResult SearchToDo([FromRoute] string filter)
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
        /// Return a ToDo Task
        /// </summary>
        /// <param name="id">ToDo's id</param>
        /// <returns>List of ToDo</returns>
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
        /// Return all the ToDo
        /// </summary>
        /// <returns>List of ToDo</returns>
        [HttpGet()]
        public ActionResult Get()
        {

            try
            {
                return Ok(service.GetAllItems().Select(p => (ToDo)p).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Updates ToDo
        /// </summary>
        /// <param name="id">ToDo's id</param>
        /// <param name="updatedToDo">ToDo to update</param>
        /// <returns>Http result</returns>
        [HttpPut("{id}/Category/{categoryid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateToDoCategory([FromRoute] int id, [FromRoute] int categoryid)
        {

            try
            {
                ToDo result = (ToDo)service.SetCategory(id, categoryid);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
