using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> inMemoryDatabase = new List<TodoItem>();

        public Task<IEnumerable<TodoItem>> GetAll()
        {
            return Task.FromResult(this.inMemoryDatabase.OrderBy(m => m.CreationDate).AsEnumerable());
        }

        public Task<TodoItem> Add(string body)
        {
            if(String.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentNullException("body", "body cannot be empty");
            }

            var item = new TodoItem
            {
                Body = body,
                Checked = false,
                CreationDate = DateTime.Now
            };
            this.inMemoryDatabase.Add(item);
            return Task.FromResult(item);
        }

        public async Task Check(Guid todoItemId)
        {
            var todoItem = await Get(todoItemId);
            todoItem.Checked = !todoItem.Checked;
        }

        public async Task Delete(Guid todoItemId)
        {
            inMemoryDatabase.Remove(await Get(todoItemId));
        }

        public Task<TodoItem> Get(Guid todoItemId)
        {
            return Task.FromResult(inMemoryDatabase.Single(t => t.Id.Equals(todoItemId)));
        }
    }
}
