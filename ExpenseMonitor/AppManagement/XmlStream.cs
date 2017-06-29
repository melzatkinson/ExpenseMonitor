using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor
{
  public class XmlStream
  {
    XmlDocument _xmlDoc;

    //-------------------------------------------------------------------------

    public void Load( string fileName )
    {
      _xmlDoc = new XmlDocument();
      _xmlDoc.Load( fileName );
    }

    //-------------------------------------------------------------------------

    public List<XmlElement> GetElementsWithName( string name )
    {
      List<XmlElement> list = new List<XmlElement>();

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

    public void WriteToXml( string fileName, CategoryManager categoryManager, ManualEntryManager manualEntryManager, RecurringEntryManager recurringEntryManager )
    {
      XmlDocument doc = new XmlDocument();
      XmlElement root = doc.CreateElement( "Root" );
      root.AppendChild( CreateCategoriesElement( doc, categoryManager ) );
      root.AppendChild( CreateEntriesElement( doc, manualEntryManager ) );
      root.AppendChild( CreateRecurringEntriesElement( doc, recurringEntryManager ) );
      doc.AppendChild( root );

      doc.Save( fileName );
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateEntriesElement( XmlDocument doc, ManualEntryManager manualEntryManager )
    {
      XmlElement entriesElement = CreateElement( doc, "ManualEntries" );

      foreach( var entry in manualEntryManager.Entries )
      {
        XmlElement entryElement = CreateElement( doc, "ManualEntry" );

        entryElement.SetAttribute( "date", entry.Date.ToString( "dd/MM/yyyy" ) );
        entryElement.SetAttribute( "category", entry.Category );
        entryElement.SetAttribute( "amount", Convert.ToString( entry.Amount, CultureInfo.InvariantCulture ) );
        entryElement.SetAttribute( "description", entry.Description );

        entriesElement.AppendChild( entryElement );
      }

      return entriesElement;
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateCategoriesElement( XmlDocument doc, CategoryManager categoryManager )
    {
      XmlElement categoriesElement = CreateElement( doc, "Categories" );

      foreach( var category in categoryManager.CategoryInfos )
      {
        XmlElement categoryElement = CreateElement( doc, "Category" );

        categoryElement.SetAttribute( "name", category.Key );
        categoryElement.SetAttribute( "budget", Convert.ToString( category.Value, CultureInfo.CurrentCulture ) );

        categoriesElement.AppendChild( categoryElement );
      }

      return categoriesElement;
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateRecurringEntriesElement( XmlDocument doc, RecurringEntryManager recurringEntryManager )
    {
      XmlElement entriesElement = CreateElement( doc, "RecurringEntries" );

      foreach( var entry in recurringEntryManager.RecurringEntries )
      {
        XmlElement entryElement = CreateElement( doc, "RecurringEntry" );

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