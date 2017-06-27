using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace ExpenseMonitor
{
  public class ManualEntryManager
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

    public delegate void ManualEntriesChangedEventHandler( object source, EventArgs args );
    public event ManualEntriesChangedEventHandler ManualEntriesChanged;

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

      OnManualEntriesChanged();
    }

    //-------------------------------------------------------------------------

    public void RemoveAt( int index )
    {
      _entries.RemoveAt( index );

      OnManualEntriesChanged();
    }

    //-------------------------------------------------------------------------

    protected virtual void OnManualEntriesChanged()
    {
      ManualEntriesChanged?.Invoke( this, EventArgs.Empty );
    }

    //-------------------------------------------------------------------------

    public int GetTotalAmountForCategory( string categoryName, DateTime startDate, DateTime endDate )
    {
      double total = 0.0;

      foreach( var entry in _entries )
      {
        if( entry.Category == categoryName &&
            DateTime.Compare( startDate, entry.Date ) <= 0 &&
            DateTime.Compare( endDate, entry.Date ) >= 0 )
          total += entry.Amount;
      }

      return ( int )total;
    }

    //-------------------------------------------------------------------------

    public int GetTotalAmountForMonth( DateTime date )
    {
      double total = 0.0;

      foreach( var entry in _entries )
      {
        if( entry.Date.Month == date.Month &&
            entry.Date.Year == date.Year )
          total += entry.Amount;
      }

      return ( int )total;
    }

    //-------------------------------------------------------------------------

    public int GetTotalAmountForCategoryInMonth( string categoryName, DateTime date )
    {
      double total = 0.0;

      foreach( var entry in _entries )
      {
        if( entry.Category == categoryName && 
            entry.Date.Month == date.Month &&
            entry.Date.Year == date.Year )
          total += entry.Amount;
      }

      return ( int )total;
    }
    
    //-------------------------------------------------------------------------
  }
}