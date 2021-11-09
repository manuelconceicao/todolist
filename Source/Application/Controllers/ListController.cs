using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Application.Commands;
using todoListBackEnd.Source.Application.DTOs;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Domain.TodoListContext.VO;

namespace todoListBackEnd.Source.Application.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        [HttpPost("New")]
        public CreateTodoListResponseDTO Post([FromBody] string title) // tentar fazer response com o dto para ter uma resposta no com o post
        {
            // Command for functionality
            CreateListCommand CreateListCmd = new CreateListCommand();
            // Create list and return response DTO
            var result = CreateListCmd.CreateList(title);
            

            return result;
        }

        [HttpGet("GetMock")]
        public IActionResult GetMock() 
        {

            List<Todo> mockList = new List<Todo>();

            Todo todo1 = new Todo()
            {
                TodoStr = "first mocked todo"
            };

            Todo todo2 = new Todo()
            {
                TodoStr = "second mocked todo"
            };

            mockList.Add(todo1);
            mockList.Add(todo2);

            //List<Todo> mockListStr = new List<Todo>();

            //foreach (Todo todo in mockList)
            //{
            //    mockListStr.Add(todo);
            //}

            Title title = new Title()
            {
                titleStr = "Manuel's mocklist"
            };

            CreateTodoListResponseDTO responseDto = new CreateTodoListResponseDTO()
            {
                title = title,
                todos = mockList
            };

            Console.WriteLine($"This is the title: {responseDto.title}");

            foreach (Todo todo in responseDto.todos)
            {
                Console.WriteLine($"This is a todo: {todo.TodoStr}");
            }


            return Ok(responseDto); // The DTO or return object need to have { get; set; }
                                // in the properties to expose for the controller to be able to return information
        }
    }
}
