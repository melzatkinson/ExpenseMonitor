using System.Collections.Generic;
using System.Xml;

namespace ExpenseMonitor.AppManagement
{
  public interface ICategoriesInfo
  {
    void Initialise( List<XmlElement> xmlList );

    IEnumerable<KeyValuePair<string, double>> GetCategories();

    IEnumerable<string> GetCategoryNames();

    bool AddCategory( string categoryName, double amount );

    void UpdateCategoryBudget( string categoryName, double newAmount );

    string GetCategoryNameAtIndex( int index );

    int GetCategoryCount();

    double GetBudgetForCategory( string category );

    double GetTotalBudgetAmount();

    event CategoriesManager.CategoriesChangedEventHandler CategoriesChanged;
  }
}