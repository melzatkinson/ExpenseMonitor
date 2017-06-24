using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace ExpenseMonitor
{
  public class CategoryManager
  {
    private List<string> _categories = new List<string>();
    public List<string> Categories => _categories;

    public delegate void CategoriesChangedEventHandler( object source, EventArgs args );
    public event CategoriesChangedEventHandler CategoriesChanged;

    //-------------------------------------------------------------------------

    public void Initialise( List<XmlElement> xmlList )
    {
      foreach( var category in xmlList )
      {
        if( category != null ) _categories.Add( category.GetAttribute( "name" ) );
      }
    }

    //-------------------------------------------------------------------------

    public void AddCategory( string categoryName )
    {
      if( _categories.Contains( categoryName ) || categoryName == "" )
      {
        MessageBox.Show( "Invalid! Empty or duplicate." );
      }
      else
      {
        _categories.Add( categoryName );
        OnCategoriesChanged();
      }
    }

    //-------------------------------------------------------------------------

    protected virtual void OnCategoriesChanged()
    {
      CategoriesChanged?.Invoke( this, EventArgs.Empty );
    }

    //-------------------------------------------------------------------------
  }
}