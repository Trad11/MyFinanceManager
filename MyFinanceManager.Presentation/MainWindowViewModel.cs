using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyFinanceManager.Presentation.Transactions;

namespace MyFinanceManager.Presentation;

public class MainWindowViewModel : ObservableObject
{
    private ObservableObject _currentViewModel;
    public ObservableObject CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public ICommand ShowTransactionViewCommand { get; }
    public ICommand ShowHomeViewCommand { get; }

    public MainWindowViewModel()
    {
        CurrentViewModel = new HomeViewModel(); // Default view
        ShowTransactionViewCommand = new RelayCommand(ShowTransactionView);
        ShowHomeViewCommand = new RelayCommand(ShowHomeView);
    }
    
    private void ShowTransactionView()
    {
        CurrentViewModel = new TransactionViewModel();
    }
    
    private void ShowHomeView()
    {
        CurrentViewModel = new HomeViewModel();
    }
}