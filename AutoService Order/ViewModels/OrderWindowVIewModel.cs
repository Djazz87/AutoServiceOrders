using System.Collections.Generic;
using AutoService_Order.DB;
using AutoService_Order.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoService_Order.ViewModels;

public partial class OrderWindowVIewModel : ViewModelBase
{
    private readonly OrderRepository _repository;
    [ObservableProperty] Order _order;
    [ObservableProperty] IEnumerable<works> _works;

    public OrderWindowVIewModel(OrderRepository _repository, Order order, IEnumerable<works> works)
    {
        this._repository = _repository;
        Order = order;
        Works = works;

        if (order.TotalAmount >= 10000)
        {
            order.DiscountPercent = order.TotalAmount*0.1;
            order.TotalAmount = order.TotalAmount - order.DiscountPercent;
        }

        else if  (order.TotalAmount >= 5000)
        {
            order.DiscountPercent = order.TotalAmount*0.05;
            order.TotalAmount = order.TotalAmount - order.DiscountPercent;;
        }
    }

    [RelayCommand]
    public void Load()
    {
        _repository.GetOrders(Order);
    }
    
}