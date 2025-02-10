
public static class AccountFactory
{
  public static BankAccount CreateAccount(string type, string accountNumber, decimal initialBalance, TransactionLogger logger)
  {
    switch (type.ToLower())
    {
      case "savings":
        return new SavingsAccount(accountNumber, initialBalance, 0.05m, logger); // 5% interest rate
      case "checking":
        return new CheckingAccount(accountNumber, initialBalance, logger);
      default:
        throw new ArgumentException("Invalid account type specified.");
    }
  }
}