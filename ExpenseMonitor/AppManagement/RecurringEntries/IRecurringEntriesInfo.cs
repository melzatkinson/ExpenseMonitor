using System.Collections.Generic;
using System.Xml;

namespace ExpenseMonitor.AppManagement.RecurringEntries
{
  public interface IRecurringEntriesInfo
  {
    IEnumerable<RecurringEntry> GetEntries();

    void Initialise( List<XmlElement> xmlList );

    void Add( string category, double amount, string description );

    void UpdateAtIndex( int index, string category, double amount, string description );

    void RemoveAt( int index );
  }
}