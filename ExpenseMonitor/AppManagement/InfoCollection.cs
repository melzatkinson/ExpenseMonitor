using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;

namespace ExpenseMonitor.AppManagement
{
  public class InfoCollection
  {
    //-------------------------------------------------------------------------

    public IManualEntriesInfo ManualEntriesInfo { get; }

    public ICategoriesInfo CategoriesInfo { get; }

    public IRecurringEntriesInfo RecurringEntriesInfo { get; }

    //-------------------------------------------------------------------------

    public InfoCollection( IManualEntriesInfo manualEntriesInfo, ICategoriesInfo categoriesInfo, IRecurringEntriesInfo recurringEntriesInfo )
    {
      ManualEntriesInfo = manualEntriesInfo;
      CategoriesInfo = categoriesInfo;
      RecurringEntriesInfo = recurringEntriesInfo;
    }

    //-------------------------------------------------------------------------
  }
}
