using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.TodoListContext;
using todoListBackEnd.Source.Infrasctructure;

namespace todoListBackEnd.Source.Domain.InternalServices.Interfaces
{
    interface IListService
    {
        TodoList CreateList(string titleString);
        Todo CreateTodo(string text);
        // Implement a GetAllLists
        List<TodoListLog>GetAllLists();
        //TodoList GetList(string idList);
        List<TodoListLog> GetListsByName(string titleSearch);

    }
}
