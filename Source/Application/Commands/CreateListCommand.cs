using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Application.DTOs;
using todoListBackEnd.Source.Domain.InternalServices;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext;
using todoListBackEnd.Source.Infrasctructure;
using todoListBackEnd.Source.Infrasctructure.Persistence;

namespace todoListBackEnd.Source.Application.Commands
{
    public class CreateListCommand
    {
        // Implement interface of ListService
        IListService iListService = new ListService();
        Db db = new Db();

        public CreateListCommand()
        {

        }

        // Creates a Todo
        public CreateTodoListResponseDTO CreateList(string title)
        {
            
            // Create todolist
            TodoList todoList = iListService.CreateList(title);

            // Save todoList database
            //Save here to DB
            db.CreateList(
                todoList.id.guid.ToString(),
                todoList.title.titleStr,
                todoList.date.creationDate.ToString("yyyy-MM-dd HH:mm:ss.fff") // defines format for string
            );


            // Prepare and return response DTO (This should be in a mapper to be called here)
            // Convert List<Todo> to List<string> to be used in DTO response. This is supposed to be in a DTO mapper
            List<Todo> todos = new List<Todo>();

            //db.getListTodos para colocar no dto

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
