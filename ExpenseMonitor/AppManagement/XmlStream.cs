using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

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

    public void WriteToXml( string fileName, CategoryManager categoryManager, EntryManager entryManager )
    {
      XmlDocument doc = new XmlDocument();
      XmlElement root = doc.CreateElement("Root");
      root.AppendChild( CreateCategoriesElement( doc, categoryManager ) );
      root.AppendChild( CreateEntriesElement( doc, entryManager ) );
      doc.AppendChild(root);

      doc.Save( fileName );
    }

    //-------------------------------------------------------------------------

    private XmlElement CreateEntriesElement( XmlDocument doc, EntryManager entryManager )
    {
      XmlElement entriesElement = CreateElement( doc, "Entries" );

      foreach( var entry in entryManager.Entries )
      {
        XmlElement entryElement = CreateElement( doc, "Entry" );
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

      foreach( var category in categoryManager.Categories )
      {
        XmlElement categoryElement = CreateElement( doc, "Category" );
        categoryElement.SetAttribute( "name", category );

        categoriesElement.AppendChild( categoryElement );
      }

      return categoriesElement;
    }

    //-------------------------------------------------------------------------
  }
}