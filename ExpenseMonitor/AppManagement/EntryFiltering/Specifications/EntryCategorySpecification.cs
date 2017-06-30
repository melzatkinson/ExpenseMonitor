using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseMonitor.AppManagement.EntryFiltering.Specifications
{
  public class EntryCategorySpecification : ISpecification<ManualEntryManager.Entry>
  {
    private readonly string _category;

    //-------------------------------------------------------------------------

    public EntryCategorySpecification( string category )
    {
      _category = category;
    }

    //-------------------------------------------------------------------------

    public bool IsSatisfied( ManualEntryManager.Entry entry )
    {
      return entry.Category == _category;
    }

    //-------------------------------------------------------------------------
  }
}
