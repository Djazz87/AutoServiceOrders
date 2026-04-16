using System;
using System.Collections.Generic;
using System.Linq;
using AutoService_Order.DB;
using AutoService_Order.Models;
using AutoService_Order.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AutoService_Order.ViewModels;

public partial class WorkWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _username;
    [ObservableProperty] private string _carname;
    [ObservableProperty] private string _title;
    [ObservableProperty] private string _price;
    private readonly WorkRepository _workRepository;
    private readonly ServicesRepository _serviceRepository;
    private readonly Services _services;
    private readonly IServiceProvider _provider;

  
   

   [ObservableProperty] private List<SelectedWorks> _works;

   public WorkWindowViewModel(IServiceProvider provider,  WorkRepository workRepository, ServicesRepository serviceRepository, Services services)
   {
       _provider = provider;
       _workRepository = workRepository;
       _serviceRepository = serviceRepository;
       Works = workRepository.GetWorks(services).Select(s=>new SelectedWorks{ Works = s}).ToList();
       Title = services.Title;
       _services = services;
      
   }

   [RelayCommand]
   public void GetItog()
   {
       var vm = ActivatorUtilities.CreateInstance<OrderWindowVIewModel>(_provider, new Order(), Works.Select(s=>s.Works));
       var win = _provider.GetService<OrderWindow>();
       win.DataContext = vm;
       win.Show();
   }
}