using MediatR;
using ErrorOr;
using MyFinanceManager.Domain.Transactions;

namespace MyFinanceManager.Application.Transactions.Commands;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ErrorOr<Transaction>>
{
    public async Task<ErrorOr<Transaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        if (request.Amount <= 0)
        {
            return Error.Validation(description: "Amount must be greater than 0");
        }
        
        var newTransaction = new Transaction
        {
            Id = Guid.NewGuid(),
            TransactionType = request.TransactionType,
            Description = request.Description,
            Amount = request.Amount
        };
        return newTransaction;
    }
}