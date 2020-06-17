using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services
{
    public interface ITodoService
    {
        public Task<IEnumerable<TodoItem>> GetAll();

        public Task<TodoItem> Get(Guid todoItemId);

        public Task<TodoItem> Add(string body);

        public Task Delete(Guid todoItemId);

        public Task Check(Guid todoItemId);
    }
}
