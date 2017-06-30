using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseMonitor.AppManagement.EntryFiltering
{
  public class EntryFilter : IFilter<ManualEntryManager.Entry>
  {
    //-------------------------------------------------------------------------

    public IEnumerable<ManualEntryManager.Entry> Filter( IEnumerable<ManualEntryManager.Entry> entries,
                                                         ISpecification<ManualEntryManager.Entry> spec )
    {
      foreach( var entry in entries )
        if( spec.IsSatisfied( entry ) )
          yield return entry;
    }

    //-------------------------------------------------------------------------
  }
}
