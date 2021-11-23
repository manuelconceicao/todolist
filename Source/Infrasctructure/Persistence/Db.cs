using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;

namespace todoListBackEnd.Source.Infrasctructure.Persistence
{
    public class Db
    {
        // Mock to test get to another database
        public List<Person> MockTestGetPeople(string someVar)
        {

            //using (IDbConnection connection = new SqlConnection(Connection.ConnectionValue("DatabaseConnection")))
            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTutorial;Trusted_Connection=True;"))
            {
                var result = connection.Query<Person>("SELECT * FROM EmployeesDemographics").ToList();
                return result;
            }
        }

        //Create a new list in database
        public void CreateList(string id, string title, string date)
        {


            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTodoListApp;Trusted_Connection=True;"))
            {
                var result = connection.Query($"INSERT INTO Lists (id, title, date) VALUES ('{id}', '{title}', '{date}')").ToList();
                //return result;
            }


        }

        

        // Add todo to Db (identifiable with the id of the list it belongs to)
        public TodoListLog GetList(string idList)
        {

            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTodoListApp;Trusted_Connection=True;"))
            {
                var result = connection.QuerySingle<TodoListLog>($"SELECT * FROM lists WHERE id = '{idList}'");
                return result;
            }


        }

        // Add todo to Db (identifiable with the id of the list it belongs to)
        public List<TodoListLog> GetAllLists()
        {

            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTodoListApp;Trusted_Connection=True;"))
            {
                var result = connection.Query<TodoListLog>("SELECT * FROM lists").ToList();
                return result;
            }


        }

        // Implement a search list by title (concat)
        public List<TodoListLog> GetListsByName(string titleSearch)
        {
            // e.g. SELECT uid, username, id, FROM users WHERE `username` LIKE '%hatt%'
            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTodoListApp;Trusted_Connection=True;"))
            {
                var result = connection.Query<TodoListLog>($"SELECT * FROM Lists WHERE Title LIKE '%{titleSearch}%'").ToList();
                return result;
            }
            
        }


        // Add todo to Db (identifiable with the id of the list it belongs to)
        public void AddTodo(string todoStr, string idList)
        {

            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTodoListApp;Trusted_Connection=True;"))
            {
                connection.Query($"INSERT INTO Todos (ListId, TodoStr) VALUES ('{idList}', '{todoStr}')");
                //return result;
            }


        }

        // Get all Todos from a specific List
        public List<TodoLog> GetTodosOfAList(string idList)
        {

            using (IDbConnection connection = new SqlConnection("Server=PORTATIL-HUAWEI\\SQLEXPRESS;Database=SQLTodoListApp;Trusted_Connection=True;"))
            {
                var result = connection.Query<TodoLog>($"SELECT * FROM Todos WHERE ListId='{idList}'").ToList();
                return result;


            }
        }
    }
}
