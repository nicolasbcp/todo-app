using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "UsuarioA"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "UsuarioA"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "nicolasplaisant"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "UsuarioA"));
            _items.Add(new TodoItem("Tarefa 5", DateTime.Now, "nicolasplaisant"));
        }
        
        [TestMethod]
        public void Deve_retornar_tarefas_apenas_do_usuario_nicolasplaisant()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("nicolasplaisant"));
            Assert.AreEqual(2, result.Count());
        }
    }
}