using System;
using System.Collections.Generic;
using AutoService_Order.DB;
using AutoService_Order.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoService_Order.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _client;

    [ObservableProperty]
    private string _auto;

    [ObservableProperty]
    private List<services> _services;
    
    [ObservableProperty]
    private services _selectedService;
    
    public  MainWindowViewModel(IServiceRepository serviceRepository)
    {
        _iServiceRepository = serviceRepository;
        
        Services = _iServiceRepository.GetAll().ToList();
    }
}