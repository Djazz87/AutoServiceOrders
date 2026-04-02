using System;

namespace AutoService_Order.Models;

public class orders
{
    public int Id {get;set;}
    public string ClientName {get;set;}
    public string CarModel {get;set;}
    public int ServiceId {get;set;}
    public double TotalAmount {get;set;}
    public int DiscountPercent  {get;set;}
    public DateTime OrderDate {get;set;}
}