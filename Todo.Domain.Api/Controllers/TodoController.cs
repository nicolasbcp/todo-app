using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetAll("nicolasplaisant");
        }

        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("nicolasplaisant");
        }

        [HttpGet]
        [Route("done")]
        public IEnumerable<TodoItem> GetAllUndone(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone("nicolasplaisant");
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "nicolasplaisant",
                DateTime.Now.Date,
                true
            );
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<TodoItem> GetUndoneForToday(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "nicolasplaisant",
                DateTime.Now.Date,
                false
            );
        }

        [HttpGet]
        [Route("done/tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "nicolasplaisant",
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [HttpGet]
        [Route("undone/tomorrow")]
        public IEnumerable<TodoItem> GetUndoneForTomorrow(
            [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "nicolasplaisant",
                DateTime.Now.Date.AddDays(1),
                false
            );
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "nicolasplaisant";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("")]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "nicolasplaisant";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("mark-as-done")]
        public GenericCommandResult MarkAsDone(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "nicolasplaisant";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("mark-as-undone")]
        public GenericCommandResult MarkAsUndone(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "nicolasplaisant";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}