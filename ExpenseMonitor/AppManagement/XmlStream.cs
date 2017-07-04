using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;

namespace ExpenseMonitor
{
  public class XmlStream
  {
    private XmlDocument _xmlDoc;

    //-------------------------------------------------------------------------

    public void Load( string fileName )
    {
      _xmlDoc = new XmlDocument();
      _xmlDoc.Load( fileName );
    }

    //-------------------------------------------------------------------------

    public List<XmlElement> GetElementsWithName( string name )
    {
      var list = new List<XmlElement>();

      foreach( var child in _xmlDoc.GetElementsByTagName( name ) )
      {
        list.Add( child as XmlElement );
      }

      return list;
    }

    //-------------------------------------------------------------------------

    public XmlElement CreateElement( XmlDocument doc, string nodeName )
    {
      return doc.CreateElement( nodeName );
    }

    //-------------------------------------------------------------------------

    public void WriteToXml( string fileName, ICategoriesInfo categoriesInfo, IManualEntriesInfo manualEntriesInfo, IRecurringEntriesInfo recurringEntriesInfo )
    {
      var doc = new XmlDocument();
      var root = doc.CreateElement( "Root" );
      root.AppendChild( CreateCategoriesElement( doc, categoriesInfo ) );
      root.AppendChild( CreateEntriesElement( doc, manualEntriesInfo ) );
      root.AppendChild( CreateRecurringEntriesElement( doc, recurringEntriesInfo ) );
      doc.AppendChild( root );

      doc.Save( fileName );
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateEntriesElement( XmlDocument doc, IManualEntriesInfo manualEntriesInfo )
    {
      var entriesElement = CreateElement( doc, "ManualEntries" );

      foreach( var entry in manualEntriesInfo.GetEntries() )
      {
        var entryElement = CreateElement( doc, "ManualEntry" );

        entryElement.SetAttribute( "date", entry.Date.ToString( "dd/MM/yyyy" ) );
        entryElement.SetAttribute( "category", entry.Category );
        entryElement.SetAttribute( "amount", Convert.ToString( entry.Amount, CultureInfo.InvariantCulture ) );
        entryElement.SetAttribute( "description", entry.Description );

        entriesElement.AppendChild( entryElement );
      }

      return entriesElement;
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateCategoriesElement( XmlDocument doc, ICategoriesInfo categoriesInfo )
    {
      var categoriesElement = CreateElement( doc, "Categories" );

      foreach( var category in categoriesInfo.GetCategories() )
      {
        var categoryElement = CreateElement( doc, "Category" );

        categoryElement.SetAttribute( "name", category.Key );
        categoryElement.SetAttribute( "budget", Convert.ToString( category.Value, CultureInfo.CurrentCulture ) );

        categoriesElement.AppendChild( categoryElement );
      }

      return categoriesElement;
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateRecurringEntriesElement( XmlDocument doc, IRecurringEntriesInfo recurringEntriesInfo )
    {
      var entriesElement = CreateElement( doc, "RecurringEntries" );

      foreach( var entry in recurringEntriesInfo.GetEntries() )
      {
        var entryElement = CreateElement( doc, "RecurringEntry" );

        entryElement.SetAttribute( "category", entry.Category );
        entryElement.SetAttribute( "amount", Convert.ToString( entry.Amount, CultureInfo.InvariantCulture ) );
        entryElement.SetAttribute( "description", entry.Description );

        entriesElement.AppendChild( entryElement );
      }

      return entriesElement;
    }

    //-------------------------------------------------------------------------
  }
}