
public abstract class BankAccount : IAccountOperations
{
  public string AccountNumber { get; set; }
  public decimal Balance { get; protected set; }
  private readonly ITransactionLogger logger; // Use interface instead of concrete class

  public BankAccount(string accountNumber, decimal initialBalance, TransactionLogger logger)
  {
    AccountNumber = accountNumber;
    Balance = initialBalance;
    this.logger = logger;
  }
  public void Deposit(decimal amount)
  {
    Balance += amount;
    logger.LogTransaction($"Deposited {amount:C} into {AccountNumber}. New Balance: {Balance:C}");
  }
  public abstract void Withdraw(decimal amount);
  public void PrintStatement()
  {
    logger.PrintStatement(AccountNumber, Balance);
  }
}
