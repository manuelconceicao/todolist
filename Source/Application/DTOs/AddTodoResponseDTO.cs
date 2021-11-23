using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoListBackEnd.Source.Application.DTOs
{
    public class AddTodoResponseDTO
    {
        public string text { get; set; }
        public string id { get; set; }

        public AddTodoResponseDTO()
        {
            text = string.Empty;
            id = string.Empty;
        }

    }
}
