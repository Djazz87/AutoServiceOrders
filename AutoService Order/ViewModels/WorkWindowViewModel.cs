using System.Collections.Generic;
using System.Linq;
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
    private readonly WorkRepository _workRepository;
    private readonly ServicesRepository _serviceRepository;
    private readonly Services _services;
  
   

   [ObservableProperty] private List<SelectedWorks> _works;

   public WorkWindowViewModel(WorkRepository workRepository, ServicesRepository serviceRepository, Services services)
   {
       _workRepository = workRepository;
       _serviceRepository = serviceRepository;
       Works = workRepository.GetWorks(services).Select(s=>new SelectedWorks{ Works = s}).ToList();
       Title = services.Title;
       _services = services;
   }

   public void GetItog()
   {
       
   }
}