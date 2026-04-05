using System.Collections.Generic;
using AutoService_Order.DB;
using AutoService_Order.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AutoService_Order.ViewModels;

public partial class WorkWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _username;
    [ObservableProperty] private string _carname;
    [ObservableProperty] private string _title;
    [ObservableProperty] private string _price;
    [ObservableProperty] works selectedWorks;
    private readonly WorkRepository _workRepository;
    private readonly ServicesRepository _serviceRepository;
    private readonly Services _services;
  
   

   [ObservableProperty] private List<works> _works;

   public WorkWindowViewModel(WorkRepository workRepository, ServicesRepository serviceRepository, Services services)
   {
       _workRepository = workRepository;
       _serviceRepository = serviceRepository;
       Works = WorkRepository.GetWorks(services);
       Title = services.Title;
       _services = services;
   }
}