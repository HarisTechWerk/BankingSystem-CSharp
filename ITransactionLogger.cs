
public interface ITransactionLogger
{
  void LogTransaction(string message);
  void PrintStatement(string accountNumber, decimal balance);
}