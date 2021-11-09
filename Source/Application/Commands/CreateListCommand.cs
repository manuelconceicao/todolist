using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Application.DTOs;
using todoListBackEnd.Source.Domain.InternalServices;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Domain.TodoListContext.VO;

namespace todoListBackEnd.Source.Application.Commands
{
    public class CreateListCommand
    {
        // Implement interface of ListService
        IListService iListService = new ListService();

        public CreateListCommand()
        {

        }

        // Creates a Todo
        public CreateTodoListResponseDTO CreateList(string title)
        {
            
            // Create todolist
            TodoList todoList = iListService.CreateList(title);

            // Save todoList database

            // Convert List<Todo> to List<string> to be used in DTO response
            List<Todo> todos = new List<Todo>();

            foreach (Todo todo in todoList.todos)
            {
                todos.Add(todo);
            }

            // Create DTO to return (I should use a mapper later to create a DTO)
            CreateTodoListResponseDTO result =
            new CreateTodoListResponseDTO()
            {
                title = todoList.title,
                todos = todos
            };

            
            return result;
        }

        


    }
}
