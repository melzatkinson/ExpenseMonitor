using System;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitorTests
{
  public class ManualEntryManagerTestMock
  {
    public bool EntriesChanged { get; set; }

    //-------------------------------------------------------------------------

    public ManualEntryManagerTestMock( ManualEntryManager manualEntryManager )
    {
      manualEntryManager.ManualEntriesChanged += OnManualEntriesChanged;
    }

    //-------------------------------------------------------------------------

    public void OnManualEntriesChanged( object sender, EventArgs e )
    {
      EntriesChanged = true;
    }

    //-------------------------------------------------------------------------
  }
}