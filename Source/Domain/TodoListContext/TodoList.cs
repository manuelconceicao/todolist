using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.TodoListContext;

namespace todoListBackEnd.Source.Domain.TodoListContext
{
    public class TodoList
    {
        public IdTodoList id;
        public Title title;
        public List<Todo> todos;
        public CreationDate date;

        public TodoList(Title title, CreationDate date)
        {
            this.id = new IdTodoList();
            this.title = title;
            this.todos = new List<Todo>();
            this.date = date;
        }

        // method add todo

}
}
