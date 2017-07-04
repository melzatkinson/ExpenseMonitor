using System.IO;
using System.Reflection;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;

namespace ExpenseMonitor.AppManagement
{
  public class AppManager
  {
    private readonly ICategoriesInfo _categoriesInfo;
    private readonly IManualEntriesInfo _manualEntriesInfo;
    private readonly IRecurringEntriesInfo _recurringEntriesInfo;

    private readonly XmlStream _xmlStream = new XmlStream();

    private string _xmlFilePath;

    //-------------------------------------------------------------------------

    public AppManager( IManualEntriesInfo manualEntriesInfo, ICategoriesInfo categoriesInfo, IRecurringEntriesInfo recurringEntriesInfo )
    {
      _manualEntriesInfo = manualEntriesInfo;
      _categoriesInfo = categoriesInfo;
      _recurringEntriesInfo = recurringEntriesInfo;

      SetXmlFilePath();

      File.SetAttributes( _xmlFilePath, FileAttributes.Normal );

      _xmlStream.Load( _xmlFilePath );

      _categoriesInfo.Initialise( _xmlStream.GetElementsWithName( "Category" ) );
      _manualEntriesInfo.Initialise( _xmlStream.GetElementsWithName( "ManualEntry" ) );
      _recurringEntriesInfo.Initialise( _xmlStream.GetElementsWithName( "RecurringEntry" ) );
    }

    //-------------------------------------------------------------------------

    private void SetXmlFilePath()
    {
      _xmlFilePath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ) + @"\Records.xml";

      if( !File.Exists( _xmlFilePath ) )
      {
        _xmlFilePath = @"../../Records.xml";
      }
    }

    //-------------------------------------------------------------------------

    public void Shutdown()
    {
      _xmlStream.WriteToXml( _xmlFilePath, _categoriesInfo, _manualEntriesInfo, _recurringEntriesInfo );
    }

    //-------------------------------------------------------------------------
  }
}