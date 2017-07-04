using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor.AppManagement.EntryFiltering
{
  public class EntryFilter : IFilter<Entry>
  {
    //-------------------------------------------------------------------------

    public IEnumerable<Entry> Filter( IEnumerable<Entry> entries,
                                      ISpecification<Entry> spec )
    {
      foreach( var entry in entries )
        if( spec.IsSatisfied( entry ) )
          yield return entry;
    }

    //-------------------------------------------------------------------------
  }
}
