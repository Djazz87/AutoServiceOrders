using System;
using System.Collections.Generic;
using AutoService_Order.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AutoService_Order.DB;

public class WorkRepository
{
     MySqlConnection connection;
    public WorkRepository(IOptions<DataBaseConnection> options)
    {
        connection = new MySqlConnection(options.Value.ConnectionString);
    }

    public List<works> GetWorks()
    {
       List<works> works = new List<works>();
       try
       {
            connection.Open();
            string sql = 
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           throw;
       }
    }
}