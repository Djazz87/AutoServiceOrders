using System;

namespace AutoService_Order.Models;

public class Order
{
    public int Id {get;set;}
    public string ClientName {get;set;}
    public string CarModel {get;set;}
    public int ServiceId {get;set;}
    public double TotalAmount {get;set;}
    public double DiscountPercent  {get;set;}
    public DateTime OrderDate {get;set;}
}