using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MyFinanceManager.Application;
using MyFinanceManager.Presentation.Transactions;

namespace MyFinanceManager.Presentation;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    //override OnStartup method
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ServiceCollection services = new ServiceCollection();
        services.AddScoped<MainWindow>();
        services.AddScoped<MainWindowViewModel>();
        services.AddScoped<HomeView>();
        services.AddScoped<HomeViewModel>();
        services.AddScoped<TransactionView>();
        services.AddScoped<TransactionViewModel>();
        services.AddApplication();
        
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        MainWindow window = serviceProvider.GetService<MainWindow>()!;
        
        window.Show();
    }
}