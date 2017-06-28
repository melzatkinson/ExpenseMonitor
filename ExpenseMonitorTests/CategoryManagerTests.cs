using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using ExpenseMonitor;

namespace ExpenseMonitorTests
{
  public class Mock
  {
    public bool CategoriesChanged { get; set; } = false;

    public Mock( CategoryManager categoryManager )
    {
      categoryManager.CategoriesChanged += OnCategoriesChanged;
    }

    public void OnCategoriesChanged( object source, EventArgs e )
    {
      CategoriesChanged = true;
    }
  }

  //-------------------------------------------------------------------------

  [TestClass]
  public class CategoryManagerTests
  {
    public CategoryManager GenerateManagerWithCategories()
    {
      XmlDocument doc = new XmlDocument();

      XmlElement element1 = doc.CreateElement( "category" );
      element1.SetAttribute( "name", "test1" );
      element1.SetAttribute( "budget", "100" );

      XmlElement element2 = doc.CreateElement( "category" );
      element2.SetAttribute( "name", "test2" );
      element2.SetAttribute( "budget", "1000" );

      List<XmlElement> list = new List<XmlElement>();
      list.Add( element1 );
      list.Add( element2 );

      CategoryManager categorymanager = new CategoryManager();

      categorymanager.Initialise( list );

      return categorymanager;
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void Initialise_UpdatesCategoryList()
    {
      // Arrange and act
      var categorymanager = GenerateManagerWithCategories();

      // Assert
      var expectedNames = new List<string>();
      var expectedBudgets = new List<double>();

      expectedNames.Add( "test1" );
      expectedNames.Add( "test2" );

      expectedBudgets.Add( 100 );
      expectedBudgets.Add( 1000 );

      int index = 0;

      foreach( var categoryInfo in categorymanager.CategoryInfos )
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
      string categoryNameToAdd = "newCategoryAdded";
      double budgetToAdd = 13;

      var categoryManager = GenerateManagerWithCategories();

      // Act
      categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( categoryNameToAdd, categoryManager.CategoryInfos.Last().Key );
      Assert.AreEqual( budgetToAdd, categoryManager.CategoryInfos.Last().Value );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithDuplicateNewName()
    {
      // Arrange
      string categoryNameToAdd = "test1";
      double budgetToAdd = 13;

      var categoryManager = GenerateManagerWithCategories();

      string lastAddedCategory = categoryManager.CategoryInfos.Last().Key;

      // Act
      categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( lastAddedCategory, categoryManager.CategoryInfos.Last().Key );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_WithEmptyNewName()
    {
      // Arrange
      string categoryNameToAdd = "";
      double budgetToAdd = 13;

      var categoryManager = GenerateManagerWithCategories();

      string lastAddedCategory = categoryManager.CategoryInfos.Last().Key;

      // Act
      categoryManager.AddCategory( categoryNameToAdd, budgetToAdd );

      // Assert
      Assert.AreEqual( lastAddedCategory, categoryManager.CategoryInfos.Last().Key );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void UpdateCategoryBudget_UpdatesBudget()
    {
      // Arrange
      string categoryNameToUpdate = "test1";
      double budgetToUpdateTo = 20;

      var categoryManager = GenerateManagerWithCategories();

      // Act
      categoryManager.UpdateCategoryBudget( categoryNameToUpdate, budgetToUpdateTo );

      // Assert
      double actual;
      categoryManager.CategoryInfos.TryGetValue( categoryNameToUpdate, out actual );

      Assert.AreEqual( budgetToUpdateTo, actual );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetBudgetFromName_CorrectBudgetValue()
    {
      // Arrange
      string categoryToTest = "test1";

      var categoryManager = GenerateManagerWithCategories();

      // Act
      double actual = categoryManager.GetBudgetFromName( categoryToTest );

      // Assert
      Assert.AreEqual( 100, actual );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetTotalBudget_CorrectAmount()
    {
      // Arrange
      var categoryManager = GenerateManagerWithCategories();

      // Act
      double actual = categoryManager.GetTotalBudgetAmount();

      // Assert
      Assert.AreEqual( 1100, actual );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddCategory_InvokesEvent()
    {
      // Arrange
      var categoryManager = GenerateManagerWithCategories();
      Mock mock = new Mock( categoryManager );

      string lastAddedCategory = categoryManager.CategoryInfos.Last().Key;

      // Act
      categoryManager.AddCategory( "something", 10 );

      // Assert
      Assert.AreEqual( true, mock.CategoriesChanged );
    }

    //-------------------------------------------------------------------------
  }
}
