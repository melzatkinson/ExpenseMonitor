using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace ExpenseMonitor
{
  public class CategoryManager
  {
    private Dictionary<string, double> _categoryInfos = new Dictionary<string, double>();
    public Dictionary<string, double> CategoryInfos => _categoryInfos;

    public delegate void CategoriesChangedEventHandler( object source, EventArgs args );
    public event CategoriesChangedEventHandler CategoriesChanged;

    //-------------------------------------------------------------------------

    public void Initialise( List<XmlElement> xmlList )
    {
      foreach( var category in xmlList )
      {
        _categoryInfos.Add( category.GetAttribute( "name" ), double.Parse( category.GetAttribute( "budget" ), CultureInfo.InvariantCulture ) );
      }
    }

    //-------------------------------------------------------------------------

    public void AddCategory( string categoryName, double amount )
    {
      if( _categoryInfos.ContainsKey( categoryName ) || categoryName == "" )
      {
        MessageBox.Show( "Invalid! Empty or duplicate." );
      }
      else
      {
        _categoryInfos.Add( categoryName, amount );
        OnCategoriesChanged();
      }
    }

    //-------------------------------------------------------------------------

    public void UpdateCategoryBudget( string categoryName, double newAmount )
    {
      _categoryInfos[ categoryName ] = newAmount;
    }

    //-------------------------------------------------------------------------

    public double GetBudgetFromName( string categoryName )
    {
      double budget;
      _categoryInfos.TryGetValue( categoryName, out budget );

      return budget;
    }

    //-------------------------------------------------------------------------

    protected virtual void OnCategoriesChanged()
    {
      CategoriesChanged?.Invoke( this, EventArgs.Empty );
    }

    //-------------------------------------------------------------------------
  }
}