using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using ExpenseMonitor.AppManagement.EntryFiltering;

namespace ExpenseMonitor.AppManagement.ManualEntries
{
  public class ManualEntriesManager : IManualEntriesInfo
  {
    private readonly List<Entry> _entries = new List<Entry>();

    private readonly EntryFilter _entryFilter = new EntryFilter();

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

    public double GetTotal( ISpecification<Entry> specification )
    {
      return _entryFilter.Filter( _entries, specification ).Sum( entry => entry.Amount );
    }

    //-------------------------------------------------------------------------

    public IEnumerable<Entry> GetEntries()
    {
      return _entries;
    }

    //-------------------------------------------------------------------------
  }
}