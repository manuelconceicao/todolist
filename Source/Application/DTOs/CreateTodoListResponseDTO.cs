using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.TodoListContext;

namespace todoListBackEnd.Source.Application.DTOs
{
    public class CreateTodoListResponseDTO
    {
        public List<Todo> todos { get; set; } // It needs get for the controller to have access to the fields and expose them in the API
        public Title title { get; set; }

        public CreateTodoListResponseDTO()
        {
            title = new Title();
            todos = new List<Todo>();
        }

    }
}
