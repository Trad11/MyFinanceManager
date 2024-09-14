namespace MyFinanceManager.Domain.Transactions;

public class Transaction
{
    public Guid Id { get; set; }
    // Income or Expense type
    public string TransactionType { get; set; } = null!;
    public double Amount {get; set; }
}