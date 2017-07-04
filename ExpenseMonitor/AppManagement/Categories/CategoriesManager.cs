using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace ExpenseMonitor.AppManagement
{
  public class CategoriesManager : ICategoriesInfo
  {
    private readonly Dictionary<string, double> _categoryInfos = new Dictionary<string, double>();

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

    public IEnumerable<KeyValuePair<string, double>> GetCategories()
    {
      return _categoryInfos;
    }

    //-------------------------------------------------------------------------

    public IEnumerable<string> GetCategoryNames()
    {
      return _categoryInfos.Select( categoryInfo => categoryInfo.Key );
    }

    //-------------------------------------------------------------------------

    public string GetCategoryNameAtIndex( int index )
    {
      int currentIndex = 0;
      foreach( var categoryInfo in _categoryInfos )
      {
        if( currentIndex == index ) return categoryInfo.Key;
        currentIndex++;
      }

      return "";
    }

    //-------------------------------------------------------------------------

    public int GetCategoryCount()
    {
      return _categoryInfos.Count;
    }

    //-------------------------------------------------------------------------

    public double GetBudgetForCategory( string category )
    {
      double budget;
      _categoryInfos.TryGetValue( category, out budget );

      return budget;
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