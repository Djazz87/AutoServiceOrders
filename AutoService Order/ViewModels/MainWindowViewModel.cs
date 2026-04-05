using System;
using System.Collections.Generic;
using AutoService_Order.DB;
using AutoService_Order.Models;
using AutoService_Order.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService_Order.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]  private string _client;
    [ObservableProperty]  private string _auto;
    [ObservableProperty]  private List<Services> _services;
    [ObservableProperty]  private Services _selectedService;
    [ObservableProperty] List<Services> works;
    [ObservableProperty] works selectedWork;
    private readonly IServiceProvider _provider;

    public  MainWindowViewModel(IServiceProvider provider, ServicesRepository repository)
    {
       _provider = provider;
       Services = repository.GetAll();

    }
    [RelayCommand]
    public void StartWork()
    {
        if (SelectedService == null)
        {
            return;
        }
        var vm = ActivatorUtilities.CreateInstance<WorkWindowViewModel>(_provider, selectedWork);
        var win = _provider.GetService<WorkWindow>();
        win.DataContext = vm;
        win.Show();
    }
}