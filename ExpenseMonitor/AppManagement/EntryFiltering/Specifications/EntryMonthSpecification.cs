using System;

namespace ExpenseMonitor.AppManagement.EntryFiltering
{
  public class EntryMonthSpecification : ISpecification<ManualEntryManager.Entry>
  {
    private readonly DateTime _date;

    //-------------------------------------------------------------------------

    public EntryMonthSpecification( DateTime date )
    {
      _date = date;
    }

    //-------------------------------------------------------------------------

    public bool IsSatisfied( ManualEntryManager.Entry entry )
    {
      return entry.Date.Month == _date.Month;
    }

    //-------------------------------------------------------------------------
  }
}
