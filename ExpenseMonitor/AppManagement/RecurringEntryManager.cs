using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

public class RecurringEntryManager
{
  public struct RecurringEntry
  {
    public RecurringEntry( string category,
                           double amount,
                           string description )
    {
      Category = category;
      Amount = amount;
      Description = description;
    }

    public string Category;
    public double Amount;
    public string Description;
  }

  private List<RecurringEntry> _recurringEntries = new List<RecurringEntry>();
  public List<RecurringEntry> RecurringEntries => _recurringEntries;

  //-------------------------------------------------------------------------

  public void Initialise( List<XmlElement> xmlList )
  {
    foreach( var entryXml in xmlList )
    {
      RecurringEntry newRecurringEntry = new RecurringEntry();
      newRecurringEntry.Category = entryXml.GetAttribute( "category" );
      newRecurringEntry.Amount = double.Parse( entryXml.GetAttribute( "amount" ), CultureInfo.InvariantCulture );
      newRecurringEntry.Description = entryXml.GetAttribute( "description" );

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
    RecurringEntry matchingEntry = _recurringEntries.ElementAt( index );
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