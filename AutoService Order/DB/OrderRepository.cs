using System;
using System.Collections.Generic;
using System.Data;
using AutoService_Order.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AutoService_Order.DB;

public class OrderRepository
{
    MySqlConnection  connection;

    public OrderRepository(IOptions<DataBaseConnection> options)
    {
        connection = new MySqlConnection(options.Value.ConnectionString);
    }

    public List<Order> GetOrders(Order order)
    {
        List<Order> orderList = new List<Order>();
        try
        {
            connection.Open();
            string sql = "SELECT * FROM Order ORDER BY id ASC;";
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read()) 
                {
                   orderList.Add(new Order
                   {
                       ClientName = dr.GetString("client_name"),
                       CarModel = dr.GetString("car_model"),
                       ServiceId = dr.GetInt32("service_id"),
                       TotalAmount = dr.GetDouble("total_amount"),
                       DiscountPercent = dr.GetInt32("discount_percent"),
                       OrderDate = dr.GetDateTime("order_date"),
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
        return orderList;
    }
}