using System;

namespace ExpenseMonitor.AppManagement.ManualEntries
{
  public struct Entry
  {
    public DateTime Date;
    public string Category;
    public double Amount;
    public string Description;
  }
}