using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace server.Services
{
    public class TodoServiceTests
    {
        [Fact]
        public async void GetAll_Is_Empty()
        {
            var service = new TodoService();
            Assert.Empty(await service.GetAll());
        }

        [Fact]
        public async void GetAll_Returns_Value()
        {
            var service = new TodoService();
            await service.Add("Complete my todo list");
            var todos = await service.GetAll();
            Assert.Single(todos);
            Assert.Equal("Complete my todo list", todos.First().Body);
        }

        [Fact]
        public async void Add_Is_Ok()
        {
            var service = new TodoService();
            var todoItem = await service.Add("Complete my todo list");
            Assert.Equal("Complete my todo list", todoItem.Body);
        }

        [Fact]
        public async void Add_With_Empty_Body()
        {
            var service = new TodoService();
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Add(""));
        }

        [Fact]
        public async void Add_With_Null_Body()
        {
            var service = new TodoService();
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Add(null));
        }

        [Fact]
        public async void Check_Is_OK()
        {
            var service = new TodoService();
            var todo = await service.Add("Complete my todo list");
            await service.Check(todo.Id);
            var checkedTodo = await service.Get(todo.Id);
            Assert.True(checkedTodo.Checked);
        }

        [Fact]
        public async void Check_Not_Found()
        {
            var service = new TodoService();
            var todo = await service.Add("Complete my todo list");
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.Check(Guid.NewGuid()));
        }

        [Fact]
        public async void Delete_Is_OK()
        {
            var service = new TodoService();
            var todo = await service.Add("Complete my todo list");
            await service.Delete(todo.Id);
            var todos = await service.GetAll();
            Assert.Empty(todos);
        }

        [Fact]
        public async void Delete_Not_Found()
        {
            var service = new TodoService();
            var todo = await service.Add("Complete my todo list");
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.Delete(Guid.NewGuid()));
        }

        [Fact]
        public async void Get_Is_OK()
        {
            var service = new TodoService();
            var todo = await service.Add("Complete my todo list");
            var newTodo = await service.Get(todo.Id);
            Assert.Equal(todo.Id, newTodo.Id);
            Assert.Equal(todo.Body, newTodo.Body);
        }

        [Fact]
        public async void Get_Not_Found()
        {
            var service = new TodoService();
            var todo = await service.Add("Complete my todo list");
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.Get(Guid.NewGuid()));
        }
    }
}
