namespace ExpenseMonitor.AppManagement.RecurringEntries
{
  public struct RecurringEntry
  {
    public RecurringEntry( string category,
      double amount,
      string description )
    {
      Category = category;
      Amount = amount;
      Description = description;
    }

    public string Category;
    public double Amount;
    public string Description;
  }
}