using System;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor
{
  static class Program
  {
    private static AppManager _appManager;
    private static ManualEntriesManager _manualEntriesManager;
    private static CategoriesManager _categoriesManager;
    private static RecurringEntryManager _recurringEntryManager;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      _manualEntriesManager = new ManualEntriesManager();
      _categoriesManager = new CategoriesManager();
      _recurringEntryManager = new RecurringEntryManager();
      _appManager = new AppManager( _manualEntriesManager, _categoriesManager, _recurringEntryManager );

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new MainForm( _manualEntriesManager,
                                     _categoriesManager,
                                     _recurringEntryManager ) );

      _appManager.Shutdown();
    }
  }
}
