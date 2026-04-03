using System;
using System.Collections.Generic;
using System.Data;
using AutoService_Order.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Tmds.DBus.Protocol;

namespace AutoService_Order.DB;

public class ServicesRepository
{ 
    MySqlConnection connection;
    public ServicesRepository(IOptions<DataBaseConnection> options)
    {
        connection = new MySqlConnection(options.Value.ConnectionString);
    }

    public List<Services> GetAll()
    {
        List<Services> services = new List<Services>();
        try
        {
            connection.Open();
            string sql = "SELECT * FROM services";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    services.Add(new Services
                    {
                        Id = dr.GetInt32("id"),
                        Title = dr.GetString("title")
                    });
                }
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if(connection.State == ConnectionState.Open)
                connection.Close();
        }
        return services;
    }
}