
class Program
{
  static void Main(string[] args)
  {
    TransactionLogger logger = new TransactionLogger(); // Inject dependency

    // Factory pattern to create accounts
    BankAccount savings = AccountFactory.CreateAccount("savings", "SAV-123", 1000m, logger);
    var checkingWithOverdraft = new CheckingAccount("CHK-456", 500m, logger, true);
    var checkingWithoutOverdraft = new CheckingAccount("CHK-789", 500m, logger, false);

    savings.Deposit(500m);
    ((SavingsAccount)savings).ApplyInterest();
    savings.Withdraw(300m);

    checkingWithOverdraft.Deposit(200m);
    checkingWithOverdraft.Withdraw(800m); // allow overdraft

    checkingWithoutOverdraft.Deposit(200m);
    checkingWithoutOverdraft.Withdraw(800m); // no overdraft

    savings.PrintStatement();
    checkingWithOverdraft.PrintStatement();
    checkingWithoutOverdraft.PrintStatement();

    Console.WriteLine("\nBanking transactions completed.");
  }
}