
public class CheckingAccount : BankAccount
{
  public decimal OverdraftFee { get; set; } = 35m;
  public bool AllowOverdraft { get; set; }  // New flag
  public CheckingAccount(string accountNumber, decimal initialBalance, TransactionLogger logger, bool allowOverdraft = true) : base(accountNumber, initialBalance, logger)
  {
    AllowOverdraft = allowOverdraft;
  }
  public override void Withdraw(decimal amount)
  {
    if (amount > Balance)
    {
      if (AllowOverdraft)
      {
        Balance -= (amount + OverdraftFee);
        Console.WriteLine($"Overdraft! {OverdraftFee:C} fee charged on {AccountNumber}. New Balance: {Balance:C}");
      }
      else
      {
        Console.WriteLine($"Insufficient funds for withdrawal: {amount:C} from account {AccountNumber}. Overdraft is not allowed.");
      }
    }
    else
    {
      Balance -= amount;
      Console.WriteLine($"Withdrew {amount:C} from account {AccountNumber}. New Balance: {Balance:C}");
    }
  }
}
