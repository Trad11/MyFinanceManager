using System.Transactions;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;

namespace MyFinanceManager.Presentation.Transactions;

public class TransactionViewModel : ObservableObject
{
    private readonly ISender _mediator;
    private double _amount;
    public double Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    private string _description;
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    private Transaction _retrievedTransaction;
    public Transaction RetrievedTransaction
    {
        get => _retrievedTransaction;
        set => SetProperty(ref _retrievedTransaction, value);
    }

    // Commands
    public ICommand CreateTransactionCommand { get; }
    public ICommand GetTransactionCommand { get; }

    // Constructor
    public TransactionViewModel(ISender mediator)
    {
        _mediator = mediator;
        CreateTransactionCommand = new RelayCommand(CreateTransaction);
        // GetTransactionCommand = new RelayCommand(GetTransaction);
    }

    // Command Methods
    private void CreateTransaction()
    {
        
        // TODO: Save the transaction using a service or repository.

        // Clear input fields
        Amount = 0;
        Description = string.Empty;
    }

    // private void GetTransaction()
    // {
    //     // For demonstration, we'll retrieve a dummy transaction.
    //     // TODO: Retrieve the transaction from a data source.
    //     RetrievedTransaction = new Transaction
    //     {
    //         Id = 1,
    //         Amount = 100.00m,
    //         Description = "Sample Transaction"
    //     };
    // }
}