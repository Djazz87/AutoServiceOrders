namespace AutoService_Order.Models;

public class order_items
{
    public int Id {get;set;}
    public int OrderId {get;set;}
    public int WorkId {get;set;}
    public decimal WorkPrice {get;set;}
    
}