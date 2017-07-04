using System;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor.AppManagement.EntryFiltering
{
  public class EntryMonthSpecification : ISpecification<Entry>
  {
    private readonly DateTime _date;

    //-------------------------------------------------------------------------

    public EntryMonthSpecification( DateTime date )
    {
      _date = date;
    }

    //-------------------------------------------------------------------------

    public bool IsSatisfied( Entry entry )
    {
      return entry.Date.Month == _date.Month;
    }

    //-------------------------------------------------------------------------
  }
}
