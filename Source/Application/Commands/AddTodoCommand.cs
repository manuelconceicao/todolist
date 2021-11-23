using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Application.DTOs;
using todoListBackEnd.Source.Domain.InternalServices;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext;
using todoListBackEnd.Source.Infrasctructure.Persistence;

namespace todoListBackEnd.Source.Application.Commands
{
    public class AddTodoCommand
    {
        // Implement interface of ListService
        IListService iListService = new ListService();
        Db db = new Db();

        public AddTodoCommand()
        {

        }

        //Creates and adds a Todo to Todolist
        public AddTodoResponseDTO AddTodo(string text, string idTodoList)
        {

            // Create a todo
            Todo todo = iListService.CreateTodo(text);

            // Save todo in DB to respective TodoList
            // idTodoList
            db.AddTodo(text, idTodoList);


            //db.GetListTodos(idTodoList);

            // Create response DTO
            AddTodoResponseDTO result = new AddTodoResponseDTO
            {
                text = todo.TodoStr,
                id = idTodoList
            };


            return result;
        }




        }
}
