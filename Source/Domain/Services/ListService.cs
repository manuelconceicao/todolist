using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Domain.TodoListContext.VO;

namespace todoListBackEnd.Source.Domain.InternalServices
{
    public class ListService : IListService
    {

        public TodoList CreateList(string titleString)
        {

            // Create new Title
            Title title = new Title
            {
                titleStr = titleString
            };


            // New DateTime with current time
            DateTime timeStamp = DateTime.Now;

            // Create new CreationDate
            CreationDate date = new CreationDate
            {
                creationDate = timeStamp
            };

            // Instantiate todolist
            TodoList result = new TodoList(title, date);


            return result;
        }

        //public Task<Todo> AddTodo(Title title, List<Todo> todos, CreationDate date)
        //{
        //    return ;
        //}
    }
}
