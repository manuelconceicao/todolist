using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Application.DTOs;
using todoListBackEnd.Source.Domain.InternalServices;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Infrasctructure;
using todoListBackEnd.Source.Infrasctructure.Persistence;

namespace todoListBackEnd.Source.Application.Commands
{
    public class GetListCommand
    {
        // Implement interface of ListService
        IListService iListService = new ListService();

        
        // Instance of database
        Db db = new Db();

        public GetListResponseDTO GetList(string idList)
        {

            // Get list from db
            TodoListLog todoListlog = db.GetList(idList);

            // Get todos from corresponding list
            List<TodoLog> todoslog = db.GetTodosOfAList(idList);

            //Console.WriteLine($"List ID: {todoList.id.guid}");
            //Console.WriteLine($"Test with GUID: {Guid.NewGuid()}");
            

            // Return response DTO
            GetListResponseDTO result = new GetListResponseDTO()
            {
                id = todoListlog.id.ToString(),
                title = todoListlog.title,
                date = todoListlog.date,
                todos = todoslog

            };

            return result;
        }


            public List<Person> MockGetAllPeople()
        {
            var mockresult = db.MockTestGetPeople("some info");


            return mockresult;
        }

    }
}
