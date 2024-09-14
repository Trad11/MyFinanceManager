using MediatR;
using ErrorOr;
using MyFinanceManager.Domain.Transactions;

namespace MyFinanceManager.Application.Transactions.Commands;

public record CreateTransactionCommand(
    string TransactionType,
    string Description,
    double Amount) : IRequest<ErrorOr<Transaction>>;