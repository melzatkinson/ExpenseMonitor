using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor
{
  static class Program
  {
    public static AppManager AppManager { get; set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      AppManager = new AppManager();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault( false );
      Application.Run( new MainForm( AppManager ) );

      AppManager.Shutdown();
    }
  }
}
