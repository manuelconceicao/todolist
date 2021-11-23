using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext;
using todoListBackEnd.Source.Infrasctructure;
using todoListBackEnd.Source.Infrasctructure.Persistence;

namespace todoListBackEnd.Source.Domain.InternalServices
{
    public class ListService : IListService
    {
        Db db = new Db();

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

        public Todo CreateTodo(string text)
        {
            
            
            //// Create CreationDate
            //CreationDate creationDate = new CreationDate()
            //{
            //    creationDate = DateTime.Parse(date)
            //};


            // Create and return Todo
            return new Todo(){TodoStr = text};
        }


        //public TodoListLog GetList(string idList)
        //{
        //    // Get list from db and return it
            

        //    // For now, I will mock a list. Replace for a query to db once I have a db
        //    //Title title = new Title()
        //    //{
        //    //    titleStr = "mockedList for get List"
        //    //};

        //    //CreationDate creationDate = new CreationDate()
        //    //{
        //    //    creationDate = DateTime.Now
        //    //};

        //    //TodoList mockList = new TodoList(title, creationDate);


        //    //return result;
        //}

        public List<TodoListLog> GetAllLists()
        {
            //Get all lists from db
            List<TodoListLog> allLists = db.GetAllLists();

            //Get all todos for for each list
            foreach (TodoListLog list in allLists)
            {
                // Get all todos per list
                List<TodoLog> todos = db.GetTodosOfAList(list.id.ToString());

                // Adds all todos to the list
                list.todos.AddRange(todos);
                               
            }

            return allLists;
        }

        public List<TodoListLog> GetListsByName(string titleSearch)
        {

            var result = db.GetListsByName(titleSearch);


            return result;

        }


    }
}
