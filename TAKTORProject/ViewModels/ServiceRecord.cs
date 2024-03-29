﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAKTORProject.Models;

namespace TAKTORProject.ViewModels
{
   
    public class ServiceRecord
    {
    
        //create connection object
        private SQLiteAsyncConnection _connection;

        public ServiceRecord()
        {
            Init();
        }
        
        //initialze database connection 
        async Task Init()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Taktor.db3");
            _connection = new SQLiteAsyncConnection(dbPath);
            await _connection.CreateTableAsync<Record>();
            
                
        }
        //method for add record in database
        public async Task AddRec(string username,int score,string time)
        {
            await Init();
            var record = new Record
            {
          
                Username = username,
                Score = score,
                Time = time
            };
            await _connection.InsertAsync(record);
                

        }
        //method for get list of model 
        public async Task<List<Record>> GetRec()
        {
            await Init();
            var constants = await _connection.Table<Record>().ToListAsync();
            return constants;
        }

    }

    
}
