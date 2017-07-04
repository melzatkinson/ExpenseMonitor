using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using ExpenseMonitor.AppManagement;

//-------------------------------------------------------------------------

namespace ExpenseMonitorTests
{
  //-------------------------------------------------------------------------

  [TestClass]
  public class CategoryManagerTests
  {
    private readonly CategoriesManager _categoryManager = GenerateManagerWithCategories();

    //-------------------------------------------------------------------------

    public static CategoriesManager GenerateManagerWithCategories()
    {
      XmlDocument doc = new XmlDocument();

      var element1 = doc.CreateElement( "category" );
      element1.SetAttribute( "name", "test1" );
      element1.SetAttribute( "budget", "100" );

      var element2 = doc.CreateElement( "category" );
      element2.SetAttribute( "name", "test2" );
      element2.SetAttribute( "budget", "1000" );

      var list = new List<XmlElement> { element1, element2 };

      var categorymanager = new CategoriesManager();

      categorymanager.Initialise( list );

      return categorymanager;
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void Initialise_UpdatesCategoryList()
    {
      var expectedNames = new List<string> { "test1", "test2" };
      var expectedBudgets = new List<double> { 100, 1000 };

      var index = 0;

      foreach( var categoryInfo in _categoryManager.GetCategories() )
      {
        Assert.AreEqual( expectedNames[ index ], categoryInfo.Key );
        Assert.AreEqual( expectedBudgets[ index ], categoryInfo.Value );

        index++;
      }
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithCorrectNewName()
    {
      // Arrange
      var categoryNameToAdd = "newCategoryAdded";
      var budgetToAdd = 13;

      // Act
      _categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      var categoryName = _categoryManager.GetCategoryNameAtIndex( _categoryManager.GetCategoryCount() - 1 );

      Assert.AreEqual( categoryNameToAdd, categoryName );
      Assert.AreEqual( budgetToAdd, _categoryManager.GetBudgetForCategory( categoryName ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithDuplicateNewName()
    {
      // Arrange
      var categoryNameToAdd = _categoryManager.GetCategoryNameAtIndex( 0 );
      var budgetToAdd = 13;

      var lastAddedCategory = _categoryManager.GetCategoryNameAtIndex( _categoryManager.GetCategoryCount() - 1 );

      // Act
      _categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( lastAddedCategory, _categoryManager.GetCategoryNameAtIndex( _categoryManager.GetCategoryCount() - 1 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithEmptyNewName()
    {
      // Arrange
      var categoryNameToAdd = "";
      var budgetToAdd = 13;

      var lastAddedCategory = _categoryManager.GetCategoryNameAtIndex( _categoryManager.GetCategoryCount() - 1 );

      // Act
      _categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( lastAddedCategory, _categoryManager.GetCategoryNameAtIndex( _categoryManager.GetCategoryCount() - 1 ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void UpdateCategoryBudget_UpdatesBudget()
    {
      // Arrange
      var categoryNameToUpdate = _categoryManager.GetCategoryNameAtIndex( 0 );
      var budgetToUpdateTo = 20;

      // Act
      _categoryManager.UpdateCategoryBudget( categoryNameToUpdate, budgetToUpdateTo );

      // Assert
      Assert.AreEqual( budgetToUpdateTo, _categoryManager.GetBudgetForCategory( categoryNameToUpdate ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetBudgetFromName_CorrectBudgetValue()
    {
      // Arrange
      var categoryToTest = _categoryManager.GetCategoryNameAtIndex( 0 );

      // Act
      var actual = _categoryManager.GetBudgetForCategory( categoryToTest );

      // Assert
      var expected = _categoryManager.GetCategories().First().Value;
      Assert.AreEqual( expected, _categoryManager.GetBudgetForCategory( categoryToTest ) );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetTotalBudget_CorrectAmount()
    {
      // Assert
      Assert.AreEqual( 1100, _categoryManager.GetTotalBudgetAmount() );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_InvokesEvent()
    {
      // Arrange
      var mock = new CategoryManagerTestMock( _categoryManager );

      // Act
      _categoryManager.AddCategory( "something", 10 );

      // Assert
      Assert.AreEqual( true, mock.CategoriesChanged );
    }

    //-------------------------------------------------------------------------
  }
}
