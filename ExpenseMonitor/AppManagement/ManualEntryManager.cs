using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace ExpenseMonitor.AppManagement
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

    private readonly List<Entry> _entries = new List<Entry>();
    public List<Entry> Entries => _entries;

    public delegate void ManualEntriesChangedEventHandler( object source, EventArgs args );
    public event ManualEntriesChangedEventHandler ManualEntriesChanged;

    //-------------------------------------------------------------------------

    public void Initialise( List<XmlElement> xmlList )
    {
      foreach( var entryXml in xmlList )
      {
        var newEntry = new Entry
        {
          Date = DateTime.ParseExact( entryXml.GetAttribute( "date" ), "dd/MM/yyyy", CultureInfo.InvariantCulture ),
          Category = entryXml.GetAttribute( "category" ),
          Amount = double.Parse( entryXml.GetAttribute( "amount" ), CultureInfo.InvariantCulture ),
          Description = entryXml.GetAttribute( "description" )
        };

        _entries.Add( newEntry );
      }
    }

    //-------------------------------------------------------------------------

    public void Add( DateTime date, string category, double amount, string description )
    {
      var newEntry = new Entry
      {
        Date = date,
        Category = category,
        Amount = amount,
        Description = description
      };

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
      return ( int )FilterByDate( startDate, endDate ).Where( entry => entry.Category == categoryName ).Sum( entry => entry.Amount );
    }

    //-------------------------------------------------------------------------

    public int GetTotalAmountForMonth( DateTime date )
    {
      return ( int )FilterByMonth( date ).Sum( entry => entry.Amount );
    }

    //-------------------------------------------------------------------------

    public int GetTotalAmountForCategoryInMonth( string categoryName, DateTime date )
    {
      return ( int )FilterByMonth( date ).Where( entry => entry.Category == categoryName ).Sum( entry => entry.Amount );
    }

    //-------------------------------------------------------------------------

    public IEnumerable<Entry> FilterByMonth( DateTime date )
    {
      return _entries.Where( entry => entry.Date.Month == date.Month && entry.Date.Year == date.Year );
    }

    //-------------------------------------------------------------------------

    public IEnumerable<Entry> FilterByDate( DateTime startDate, DateTime endDate )
    {
      return _entries.Where( entry => DateTime.Compare( startDate, entry.Date ) <= 0 && DateTime.Compare( endDate, entry.Date ) >= 0 );
    }

    //-------------------------------------------------------------------------
  }
}