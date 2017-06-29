using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace ExpenseMonitor.AppManagement
{
  public class CategoryManager
  {
    private readonly Dictionary<string, double> _categoryInfos = new Dictionary<string, double>();
    public Dictionary<string, double> CategoryInfos => _categoryInfos;

    public delegate void CategoriesChangedEventHandler( object source, EventArgs args );
    public event CategoriesChangedEventHandler CategoriesChanged;

    //-------------------------------------------------------------------------

    public void Initialise( List<XmlElement> xmlList )
    {
      foreach( var category in xmlList )
        _categoryInfos.Add( category.GetAttribute( "name" ), 
                            double.Parse( category.GetAttribute( "budget" ), 
                            CultureInfo.InvariantCulture ) );
    }

    //-------------------------------------------------------------------------

    public bool AddCategory( string categoryName, double amount )
    {
      if( _categoryInfos.ContainsKey( categoryName ) || categoryName == "" )
        return false;

      _categoryInfos.Add( categoryName, amount );
      OnCategoriesChanged();

      return true;
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

    public double GetTotalBudgetAmount()
    {
      return _categoryInfos.Values.Sum();
    }

    //-------------------------------------------------------------------------
  }
}