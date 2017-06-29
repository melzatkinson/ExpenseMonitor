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
    private readonly CategoryManager _categoryManager = GenerateManagerWithCategories();

    //-------------------------------------------------------------------------

    public static CategoryManager GenerateManagerWithCategories()
    {
      XmlDocument doc = new XmlDocument();

      var element1 = doc.CreateElement( "category" );
      element1.SetAttribute( "name", "test1" );
      element1.SetAttribute( "budget", "100" );

      var element2 = doc.CreateElement( "category" );
      element2.SetAttribute( "name", "test2" );
      element2.SetAttribute( "budget", "1000" );

      var list = new List<XmlElement> { element1, element2 };

      var categorymanager = new CategoryManager();

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

      foreach( var categoryInfo in _categoryManager.CategoryInfos )
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
      Assert.AreEqual( categoryNameToAdd, _categoryManager.CategoryInfos.Last().Key );
      Assert.AreEqual( budgetToAdd, _categoryManager.CategoryInfos.Last().Value );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithDuplicateNewName()
    {
      // Arrange
      var categoryNameToAdd = _categoryManager.CategoryInfos.First().Key;
      var budgetToAdd = 13;

      var lastAddedCategory = _categoryManager.CategoryInfos.Last().Key;

      // Act
      _categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( lastAddedCategory, _categoryManager.CategoryInfos.Last().Key );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithEmptyNewName()
    {
      // Arrange
      var categoryNameToAdd = "";
      var budgetToAdd = 13;

      var lastAddedCategory = _categoryManager.CategoryInfos.Last().Key;

      // Act
      _categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( lastAddedCategory, _categoryManager.CategoryInfos.Last().Key );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void UpdateCategoryBudget_UpdatesBudget()
    {
      // Arrange
      var categoryNameToUpdate = _categoryManager.CategoryInfos.First().Key;
      var budgetToUpdateTo = 20;

      // Act
      _categoryManager.UpdateCategoryBudget( categoryNameToUpdate, budgetToUpdateTo );

      // Assert
      double actual;
      _categoryManager.CategoryInfos.TryGetValue( categoryNameToUpdate, out actual );

      Assert.AreEqual( budgetToUpdateTo, actual );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetBudgetFromName_CorrectBudgetValue()
    {
      // Arrange
      var categoryToTest = _categoryManager.CategoryInfos.First().Key;

      // Act
      var actual = _categoryManager.GetBudgetFromName( categoryToTest );

      // Assert
      var expected = _categoryManager.CategoryInfos.First().Value;
      Assert.AreEqual( expected, actual );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetTotalBudget_CorrectAmount()
    {
      // Act
      var actual = _categoryManager.GetTotalBudgetAmount();

      // Assert
      var total = _categoryManager.CategoryInfos.Values.Sum();
   
      Assert.AreEqual( total, actual );
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
