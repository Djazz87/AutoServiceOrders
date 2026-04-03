using Avalonia;
using System;
using AutoService_Order.DB;
using AutoService_Order.ViewModels;
using AutoService_Order.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutoService_Order;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();
            }).
            ConfigureServices((c, s) =>
            {
                s.Configure<DataBaseConnection>(c.Configuration.GetSection("DataBaseConnection"));
                s.AddTransient<MainWindow>();
                s.AddTransient<MainWindowViewModel>();
                s.AddTransient<ServicesRepository>();
                s.AddTransient<WorkWindow>();
                s.AddTransient<WorkWindowViewModel>();
                s.AddTransient<WorkRepository>();

            }).Build();
        BuildAvaloniaApp(host.Services)
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp(IServiceProvider hostServices)
        => AppBuilder.Configure(()=>new App(hostServices))
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}