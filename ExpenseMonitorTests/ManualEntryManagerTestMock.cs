using System;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitorTests
{
  public class ManualEntryManagerTestMock
  {
    public bool EntriesChanged { get; set; }

    //-------------------------------------------------------------------------

    public ManualEntryManagerTestMock( IManualEntriesInfo manualEntriesInfo )
    {
      manualEntriesInfo.ManualEntriesChanged += OnManualEntriesChanged;
    }

    //-------------------------------------------------------------------------

    public void OnManualEntriesChanged( object sender, EventArgs e )
    {
      EntriesChanged = true;
    }

    //-------------------------------------------------------------------------
  }
}