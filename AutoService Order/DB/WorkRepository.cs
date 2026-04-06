using System;
using System.Collections.Generic;
using System.Data;
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

    public List<works> GetWorks(Services services)
    {
       List<works> works = new List<works>();
       try
       {
            connection.Open();
            string sql = "Select * from works where service_id="+services.Id;
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    works.Add(new works
                    {
                        Id = dr.GetInt32("id"),
                        WorkName = dr.GetString("work_name"),
                        Price = dr.GetDouble("price"),
                    });
                }
            }
       }
       catch (Exception e)
       {
           Console.WriteLine(e);
           throw;
       }
       finally
       {
           if(connection.State == ConnectionState.Open)
               connection.Close();
       }
       return works;
    }
}