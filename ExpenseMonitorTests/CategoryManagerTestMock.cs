using System;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitorTests
{
  public class CategoryManagerTestMock
  {
    public bool CategoriesChanged { get; set; }

    //-------------------------------------------------------------------------

    public CategoryManagerTestMock( CategoriesManager categoriesManager )
    {
      categoriesManager.CategoriesChanged += OnCategoriesChanged;
    }

    //-------------------------------------------------------------------------

    public void OnCategoriesChanged( object source, EventArgs e )
    {
      CategoriesChanged = true;
    }

    //-------------------------------------------------------------------------
  }
}