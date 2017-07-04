using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using ExpenseMonitor.AppManagement.RecurringEntries;

public class RecurringEntryManager : IRecurringEntriesInfo
{
  private readonly List<RecurringEntry> _recurringEntries = new List<RecurringEntry>();

  //-------------------------------------------------------------------------

  public IEnumerable<RecurringEntry> GetEntries()
  {
    return _recurringEntries;
  }

  //-------------------------------------------------------------------------

  public void Initialise( List<XmlElement> xmlList )
  {
    foreach( var entryXml in xmlList )
    {
      var newRecurringEntry = new RecurringEntry
      {
        Category = entryXml.GetAttribute( "category" ),
        Amount = double.Parse( entryXml.GetAttribute( "amount" ), CultureInfo.InvariantCulture ),
        Description = entryXml.GetAttribute( "description" )
      };

      _recurringEntries.Add( newRecurringEntry );
    }
  }

  //-------------------------------------------------------------------------

  public void Add( string category, double amount, string description )
  {
    _recurringEntries.Add( new RecurringEntry( category, amount, description ) );
  }

  //-------------------------------------------------------------------------

  public void UpdateAtIndex( int index, string category, double amount, string description )
  {
    var matchingEntry = _recurringEntries.ElementAt( index );
    matchingEntry.Category = category;
    matchingEntry.Amount = amount;
    matchingEntry.Description = description;
    _recurringEntries[ index ] = matchingEntry;
  }

  //-------------------------------------------------------------------------

  public void RemoveAt( int index )
  {
    _recurringEntries.RemoveAt( index );
  }

  //-------------------------------------------------------------------------
}