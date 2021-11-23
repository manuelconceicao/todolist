using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.TodoListContext;
using todoListBackEnd.Source.Infrasctructure;

namespace todoListBackEnd.Source.Application.DTOs
{
    public class GetListResponseDTO
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<TodoLog> todos { get; set; } // This should be a List<string> because Todo is a domain object.
                                              // I should not expost domain objects (it's in a DTO)
        public string date { get; set; }

        public GetListResponseDTO()
        {
            id = string.Empty;
            title = string.Empty;
            todos = new List<TodoLog>();
            date = string.Empty;

        }


    }
}
