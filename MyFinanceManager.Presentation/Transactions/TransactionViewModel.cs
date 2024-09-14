using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using ErrorOr;
using MyFinanceManager.Application.Transactions.Commands;
using MyFinanceManager.Domain.Transactions;

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
        CreateTransactionCommand = new AsyncRelayCommand(CreateTransaction);
        // GetTransactionCommand = new RelayCommand(GetTransaction);
    }

    // Command Methods
    private async Task CreateTransaction()
    {
        var command = new CreateTransactionCommand("Income", Description, Amount);

        var createTransactionResult = await _mediator.Send(command);

        if (createTransactionResult.IsError)
        {
            Console.Error.WriteLine(createTransactionResult.FirstError.Description);
            MessageBox.Show(createTransactionResult.FirstError.Description, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
        {
            RetrievedTransaction = createTransactionResult.Value;
        }
        
        // TODO: Save the transaction using a service or repository.
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