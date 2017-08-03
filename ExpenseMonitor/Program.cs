using System;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor
{
  static class Program
  {
    private static AppManager _appManager;
    private static InfoCollection _infoCollection;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      _infoCollection = new InfoCollection( new ManualEntriesManager(),
                                            new CategoriesManager(),
                                            new RecurringEntryManager() );

      _appManager = new AppManager( _infoCollection );

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new MainForm( _infoCollection ) );

      _appManager.Shutdown();
    }
  }
}
