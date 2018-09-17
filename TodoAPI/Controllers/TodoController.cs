using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

namespace TodoAPI.Controllers {

    [Route("api/todo")]
    public class TodoController : ControllerBase {
        private readonly TodoContext _context;

        public TodoController(TodoContext context) {
            _context = context;
            if (_context.TodoItems.Count() == 0) {
                
                //Create a new TodoItem if collection is empty which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item 1" });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Lists all TODO items.
        /// </summary>
        /// <returns>List with all TODO items</returns>
        [Produces("application/json")]
        [HttpGet]
        public List<TodoItem> GetAll() {

            return _context.TodoItems.ToList();
        }

        /// <summary>
        /// Lists the TODO item of the corresponding id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TODO item</returns>
        /// <response code="200">Returns the expected TODO item</response>
        /// <response code="404">If no TODO item with the same id was found</response>
        [ProducesResponseType(typeof(TodoItem), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id) {
            var item = _context.TodoItems.Find(id);
            if(item == null){
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Creates a new TODO.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Todo added</returns>
        /// <remarks>
        /// Request example:
        ///
        ///     POST /todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the todo item created</response>
        /// <response code="400">If the todo item is null</response>
        [ProducesResponseType(400)]
        [ProducesResponseTypeAttribute(201)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item) {
            if(item == null) {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item) {
            if (item == null || item.Id != id) {
                return BadRequest();
            }


            var todo = _context.TodoItems.Find(id);
            if (todo == null) {
                return NotFound();
            }

            todo.IsCompleted = item.IsCompleted;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            var todo = _context.TodoItems.Find(id);

            if (todo == null) {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
