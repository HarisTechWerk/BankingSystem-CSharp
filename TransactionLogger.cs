
public class TransactionLogger : ITransactionLogger
{
  private readonly List<string> transactions = new List<string>();

  public void LogTransaction(string message)
  {
    transactions.Add($"{DateTime.Now}: {message}");
    Console.WriteLine(message);
  }

  public void PrintStatement(string accountNumber, decimal balance)
  {
    // Transaction History
    Console.WriteLine($"\n===== Account Statement for {accountNumber} =====");
    Console.WriteLine($"Current Balance: {balance:C}");
    Console.WriteLine("Transaction History:");
    Console.WriteLine("------------------------------");

    foreach (var transaction in transactions)
    {
      Console.WriteLine(transaction);
    }
    Console.WriteLine("=============================================");
  }
}