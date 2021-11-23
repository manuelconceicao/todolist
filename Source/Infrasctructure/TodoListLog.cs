using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.TodoListContext;

namespace todoListBackEnd.Source.Infrasctructure
{
    public class TodoListLog
    {
        public Guid? id { get; set; }
        public string title { get; set; }
        
        public string date { get; set; }
        public List<TodoLog> todos { get; set; }

        public TodoListLog()
        {
            this.id = new Guid();
            this.title = title;
            this.date = date;
            this.todos = new List<TodoLog>();
        }
    }
}
