using System;
using System.Collections.Generic;
using System.Xml;

namespace ExpenseMonitor.AppManagement.ManualEntries
{
  public interface IManualEntriesInfo
  {
    void Initialise( List<XmlElement> xmlList );

    IEnumerable<Entry> GetEntries();

    void Add( DateTime date, string category, double amount, string description );

    double GetTotal( ISpecification<Entry> specification );

    void RemoveAt( int index );

    event ManualEntriesManager.ManualEntriesChangedEventHandler ManualEntriesChanged;
  }
}
