using System;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor.AppManagement
{
  public class EntryDateSpecification : ISpecification<Entry>
  {
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    //------------------------------------------------------------------------

    public EntryDateSpecification( DateTime startDate, DateTime endDate )
    {
      _startDate = startDate;
      _endDate = endDate;
    }

    //-------------------------------------------------------------------------

    public bool IsSatisfied( Entry entry )
    {
      return entry.Date >= _startDate && entry.Date <= _endDate;
    }

    //-------------------------------------------------------------------------
  }
}