using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
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
        public async Task<IActionResult> Post([FromBody] PostTodoDTO request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                return Ok(await _service.Add(request.body));
            }
            catch(ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Check(CheckTodoDTO request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await _service.Check(request.Id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
