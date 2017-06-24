using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace ExpenseMonitor
{
  public class EntryManager
  {
    public struct Entry
    {
      public DateTime Date;
      public string Category;
      public double Amount;
      public string Description;
    }

    private List<Entry> _entries = new List<Entry>();
    public List<Entry> Entries => _entries;

    //-------------------------------------------------------------------------

    public void Initialise( List<XmlElement> xmlList )
    {
      foreach( var entryXml in xmlList )
      {
        Entry newEntry = new Entry();
        newEntry.Date = DateTime.ParseExact( entryXml.GetAttribute( "date" ), "dd/MM/yyyy", CultureInfo.InvariantCulture );
        newEntry.Category = entryXml.GetAttribute( "category" );
        newEntry.Amount = double.Parse( entryXml.GetAttribute( "amount" ), CultureInfo.InvariantCulture );
        newEntry.Description = entryXml.GetAttribute( "description" );

        _entries.Add( newEntry );
      }
    }

    //-------------------------------------------------------------------------

    public void Add( DateTime date, string category, double amount, string description )
    {
      Entry newEntry = new Entry();
      newEntry.Date = date;
      newEntry.Category = category;
      newEntry.Amount = amount;
      newEntry.Description = description;

      _entries.Add( newEntry );
    }

    //-------------------------------------------------------------------------
  }
}