﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListBackEnd.Source.Domain.InternalServices;
using todoListBackEnd.Source.Domain.InternalServices.Interfaces;
using todoListBackEnd.Source.Domain.TodoListContext.Entity;
using todoListBackEnd.Source.Infrasctructure;
using todoListBackEnd.Source.Infrasctructure.Persistence;

namespace todoListBackEnd.Source.Application.Commands
{
    public class GetAllListsCommand
    {
        // Instance of database
        Db db = new Db();

        IListService iListService = new ListService();

        public List<TodoListLog> GetAllLists()
        {

            //Get all lists
            var result = iListService.GetAllLists();
            return result;
            //return db.GetAllLists();

        }

    }
}
