
public class SavingsAccount : BankAccount
{
  public decimal InterestRate { get; set; }

  public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate, TransactionLogger logger) : base(accountNumber, initialBalance, logger)
  {
    InterestRate = interestRate;
  }
  public void ApplyInterest()
  {
    decimal interest = Balance * InterestRate;
    Balance += interest;
    Console.WriteLine($"Interest applied to {AccountNumber}. New Balance: {Balance:C}");
  }

  public override void Withdraw(decimal amount)
  {
    if (amount <= Balance)
    {
      Balance -= amount;
      Console.WriteLine($"Withdrew {amount:C} from account {AccountNumber}. New Balance: {Balance:C}");
    }
    else
    {
      Console.WriteLine($"Insufficient funds for Withdrawal: {amount:C} from {AccountNumber}");
    }
  }
}