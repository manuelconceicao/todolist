using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Domain.TodoListContext.VO;

namespace todoListBackEnd.Source.Domain.InternalServices.Interfaces
{
    interface IListService
    {
        TodoList CreateList(string titleString);
        //Task<Todo> AddTodo(Title title, List<Todo> todos, CreationDate date);

    }
}
