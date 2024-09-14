using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using MyFinanceManager.Presentation.Transactions;

namespace MyFinanceManager.Presentation;

public class MainWindowViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    
    private ObservableObject _currentViewModel;
    public ObservableObject CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public ICommand ShowTransactionViewCommand { get; }
    public ICommand ShowHomeViewCommand { get; }

    public MainWindowViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        ShowTransactionViewCommand = new RelayCommand(ShowTransactionView);
        ShowHomeViewCommand = new RelayCommand(ShowHomeView);
    }
    
    private void ShowTransactionView()
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<TransactionViewModel>();
    }
    
    private void ShowHomeView()
    {
        CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
    }
}