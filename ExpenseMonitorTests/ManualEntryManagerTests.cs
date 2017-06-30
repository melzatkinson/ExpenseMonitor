using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using ExpenseMonitor.AppManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseMonitorTests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class ManualEntryManagerTests
  {
    private readonly ManualEntryManager _manualEntryManager = GenerateManualEntryManager();

    //-------------------------------------------------------------------------

    public static ManualEntryManager GenerateManualEntryManager()
    {
      XmlDocument doc = new XmlDocument();

      var element1 = doc.CreateElement( "Entry" );
      element1.SetAttribute( "date", "29/06/2017" );
      element1.SetAttribute( "category", "petrol" );
      element1.SetAttribute( "amount", "500" );
      element1.SetAttribute( "description", "test1" );

      var element2 = doc.CreateElement( "Entry" );
      element2.SetAttribute( "date", "11/05/2017" );
      element2.SetAttribute( "category", "food" );
      element2.SetAttribute( "amount", "1000" );
      element2.SetAttribute( "description", "test2" );

      var xmlList = new List<XmlElement> { element1, element2 };

      var manualEntryManager = new ManualEntryManager();
      manualEntryManager.Initialise( xmlList );

      return manualEntryManager;
    }

    //-------------------------------------------------------------------------

    public ManualEntryManagerTests()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext { get; set; }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    //-------------------------------------------------------------------------

    [TestMethod]
    public void Initialise_UpdatesEntriesList()
    {
      var expectedDates = new List<DateTime> { DateTime.ParseExact( "29/06/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
                                               DateTime.ParseExact( "11/05/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ) };
      var expectedCategories = new List<string> { "petrol", "food" };
      var expectedAmounts = new List<double> { 500, 1000 };
      var expectedDescriptions = new List<string> { "test1", "test2" };

      var index = 0;

      foreach( var entry in _manualEntryManager.Entries )
      {
        Assert.AreEqual( expectedDates[ index ], entry.Date );
        Assert.AreEqual( expectedCategories[ index ], entry.Category );
        Assert.AreEqual( expectedAmounts[ index ], entry.Amount );
        Assert.AreEqual( expectedDescriptions[ index ], entry.Description );

        index++;
      }
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void Add_NewEntryGetsAdded()
    {
      // Arrange
      var newEntry = new ManualEntryManager.Entry
      {
        Date = DateTime.ParseExact( "01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
        Category = "testCategory",
        Amount = 2000,
        Description = "testDescription"
      };

      // Act
      _manualEntryManager.Add( newEntry.Date, newEntry.Category, newEntry.Amount, newEntry.Description );

      // Assert
      var lastEntry = _manualEntryManager.Entries[ _manualEntryManager.Entries.Count - 1 ];

      Assert.AreEqual( newEntry.Date, lastEntry.Date );
      Assert.AreEqual( newEntry.Category, lastEntry.Category );
      Assert.AreEqual( newEntry.Amount, lastEntry.Amount );
      Assert.AreEqual( newEntry.Description, lastEntry.Description );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void Remove_CorrectEntryRemoved()
    {
      // Arrange
      var indexToRemove = 0;
      var entry = _manualEntryManager.Entries[ indexToRemove + 1 ];

      // Act
      _manualEntryManager.RemoveAt( indexToRemove );

      // Assert
      var newEntry = _manualEntryManager.Entries[ indexToRemove ];

      Assert.AreEqual( newEntry.Date, entry.Date );
      Assert.AreEqual( newEntry.Category, entry.Category );
      Assert.AreEqual( newEntry.Amount, entry.Amount );
      Assert.AreEqual( newEntry.Description, entry.Description );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void AddEntry_InvokesEvent()
    {
      // Arrange
      var mock = new ManualEntryManagerTestMock( _manualEntryManager );

      // Act
      _manualEntryManager.Add( DateTime.ParseExact( "01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
                               "testCategory",
                               2000,
                               "testDescription" );

      // Assert
      Assert.AreEqual( true, mock.EntriesChanged );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void RemoveEntry_InvokesEvent()
    {
      // Arrange
      var mock = new ManualEntryManagerTestMock( _manualEntryManager );

      // Act
      _manualEntryManager.RemoveAt( _manualEntryManager.Entries.Count - 1 );

      // Assert
      Assert.AreEqual( true, mock.EntriesChanged );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetTotalAmountForCategory_ReturnsCorrectTotal()
    {
      // Arrange
      var manualEntryManager = GenerateManualEntryManager();

      manualEntryManager.Add( DateTime.ParseExact( "01/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
        "petrol",
        2000,
        "testDescription" );

      var startDate = DateTime.ParseExact( "01/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture );
      var endDate = DateTime.ParseExact( "01/01/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture );

      // Act
      var total = manualEntryManager.GetTotalAmountForCategory( "petrol", startDate, endDate );

      // Assert
      Assert.AreEqual( 2500, actual: total );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetTotalAmountForMonth_ReturnsCorrectTotal()
    {
      // Arrange
      var manualEntryManager = GenerateManualEntryManager();

      manualEntryManager.Add( DateTime.ParseExact( "01/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
        "petrol",
        2000,
        "testDescription" );

      var date = DateTime.ParseExact( "01/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture );

      // Act
      var total = manualEntryManager.GetTotalAmountForMonth( date );

      // Assert
      Assert.AreEqual( 2000, actual: total );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void GetTotalAmountForCategoryInMonth_ReturnsCorrectTotal()
    {
      // Arrange
      var manualEntryManager = GenerateManualEntryManager();

      manualEntryManager.Add( DateTime.ParseExact( "01/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
        "petrol",
        2000,
        "testDescription" );

      manualEntryManager.Add( DateTime.ParseExact( "01/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
        "food",
        3000,
        "testDescription" );

      var date = DateTime.ParseExact( "01/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture );

      // Act
      var total = manualEntryManager.GetTotalAmountForCategoryInMonth( "petrol", date );

      // Assert
      Assert.AreEqual( 2000, actual: total );
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void FilterByMonth_FiltersCorrectly()
    {
      // Arrange
      var manualEntryManager = GenerateManualEntryManager();

      var testDates = new List<DateTime>
      {
        DateTime.ParseExact("13/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
        DateTime.ParseExact("26/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)
      };

      var testCategories = new List<string> { "petrol", "food" };
      var testAmounts = new List<double> { 2000, 3000 };
      var testDescriptions = new List<string> { "testDescription1", "testDescription2" };

      var index = 0;

      foreach( var date in testDates )
      {
        manualEntryManager.Add( date,
          testCategories[ index ],
          testAmounts[ index ],
          testDescriptions[ index ] );

        index++;
      }

      // Act
      var filteredEntries = manualEntryManager.FilterByMonth( DateTime.ParseExact( "01/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ) );

      // Assert
      index = 0;
      foreach( var entry in filteredEntries )
      {
        Assert.AreEqual( testDates[ index ], entry.Date );
        Assert.AreEqual( testCategories[ index ], entry.Category );
        Assert.AreEqual( testAmounts[ index ], entry.Amount );
        Assert.AreEqual( testDescriptions[ index ], entry.Description );

        index++;
      }
    }

    //-------------------------------------------------------------------------

    [TestMethod]
    public void FilterByDate_FiltersCorrectly()
    {
      // Arrange
      var manualEntryManager = GenerateManualEntryManager();

      var testDates = new List<DateTime>
      {
        DateTime.ParseExact("13/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture),
        DateTime.ParseExact("26/02/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture)
      };

      var testCategories = new List<string> { "petrol", "food" };
      var testAmounts = new List<double> { 2000, 3000 };
      var testDescriptions = new List<string> { "testDescription1", "testDescription2" };

      var index = 0;

      foreach( var date in testDates )
      {
        manualEntryManager.Add( date,
                                testCategories[ index ],
                                testAmounts[ index ],
                                testDescriptions[ index ] );

        index++;
      }

      // Act
      var filteredEntries = manualEntryManager.FilterByDate(
        DateTime.ParseExact( "12/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ),
        DateTime.ParseExact( "13/04/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture ) );

      // Assert
      index = 0;
      foreach( var entry in filteredEntries )
      {
        Assert.AreEqual( testDates[ index ], entry.Date );
        Assert.AreEqual( testCategories[ index ], entry.Category );
        Assert.AreEqual( testAmounts[ index ], entry.Amount );
        Assert.AreEqual( testDescriptions[ index ], entry.Description );

        index++;
      }
    }

    //-------------------------------------------------------------------------
  }
}
