using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Application.Commands;
using todoListBackEnd.Source.Application.DTOs;
using todoListBackEnd.Source.Domain.TodoListContext;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Infrasctructure;

namespace todoListBackEnd.Source.Application.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        // Create a new List and returns a response DTO with the list information
        [HttpPost("CreateList")]
        public CreateTodoListResponseDTO Post([FromBody] string title) // tentar fazer response com o dto para ter uma resposta no com o post
        {
            // Command for functionality
            CreateListCommand CreateListCmd = new CreateListCommand();

            // Create list and return response DTO
            var result = CreateListCmd.CreateList(title);


            return result;
        }

        // Create a Todo for an existent List and returns a response DTO with the created Todo information
        [HttpPost("CreateTodo")]
        public AddTodoResponseDTO Post([FromBody] string text, [FromQuery] string listId)
        {
            // Command functionality
            AddTodoCommand addTodoCmd = new AddTodoCommand();

            // Create Todo and return responde DTO
            var result = addTodoCmd.AddTodo(text, listId);


            return result;
        }

        // Get a List information
        [HttpGet("GetList")]
        public GetListResponseDTO Get([FromQuery] string listId)
        {
            // Command functionality
            GetListCommand getListCmd = new GetListCommand();

            // Get list and return responde DTO (to implement)
            var result = getListCmd.GetList(listId);


            return result;
        }

        // Search List by name
        [HttpGet("GetListsByName")]
        public List<TodoListLog> GetListsByName([FromQuery] string titleSearch)
        {
            // Command functionality
            GetListsByNameCommand GetListsByNameCmd = new GetListsByNameCommand();

            // Get list and return responde DTO(to implement)
            var result = GetListsByNameCmd.GetListsByName(titleSearch);


            return result;
        }

        // Get a List information
        [HttpGet("GetAllLists")]
        public List<TodoListLog> Get()
        {
            // Command functionality
            GetAllListsCommand getAllListsCmd = new GetAllListsCommand();

            // Create Todo and return responde DTO
            var result = getAllListsCmd.GetAllLists();


            return result;
        }


        // Do a search for title (with concat) list

        // Mock return people
        [HttpGet("MockGetPeople")]
        public List<Person> GetMockAllPeople()
        {
            // Command functionality
            GetListCommand getListCmd = new GetListCommand();

            // Create Todo and return responde DTO
            var result = getListCmd.MockGetAllPeople();


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
