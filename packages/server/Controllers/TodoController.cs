using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoItem), 200)]
        public async Task<IActionResult> Post(string body)
        {
            try
            {
                return Ok(await _service.Add(body));
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Check(Guid todoItemId)
        {
            try
            {
                await _service.Check(todoItemId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Delete(Guid todoItemId)
        {
            try
            {
                await _service.Delete(todoItemId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
