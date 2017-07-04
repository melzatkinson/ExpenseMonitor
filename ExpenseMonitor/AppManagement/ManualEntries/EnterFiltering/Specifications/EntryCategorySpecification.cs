using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor.AppManagement.EntryFiltering.Specifications
{
  public class EntryCategorySpecification : ISpecification<Entry>
  {
    private readonly string _category;

    //-------------------------------------------------------------------------

    public EntryCategorySpecification( string category )
    {
      _category = category;
    }

    //-------------------------------------------------------------------------

    public bool IsSatisfied( Entry entry )
    {
      return entry.Category == _category;
    }

    //-------------------------------------------------------------------------
  }
}
