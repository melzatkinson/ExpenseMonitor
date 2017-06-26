using System.IO;
using System.Reflection;

namespace ExpenseMonitor.AppManagement
{
  public class AppManager
  {
    public CategoryManager CategoryManager = new CategoryManager();
    public ManualEntryManager ManualEntryManager = new ManualEntryManager();
    public RecurringEntryManager RecurringEntryManager = new RecurringEntryManager();

    private readonly XmlStream _xmlStream = new XmlStream();

    private string _xmlFilePath;

    //-------------------------------------------------------------------------

    public AppManager()
    {
      SetXmlFilePath();

      File.SetAttributes( _xmlFilePath, FileAttributes.Normal );

      _xmlStream.Load( _xmlFilePath );

      CategoryManager.Initialise( _xmlStream.GetElementsWithName( "Category" ) );
      ManualEntryManager.Initialise( _xmlStream.GetElementsWithName( "ManualEntry" ) );
      RecurringEntryManager.Initialise( _xmlStream.GetElementsWithName( "RecurringEntry" ) );
    }

    //-------------------------------------------------------------------------

    private void SetXmlFilePath()
    {
      string devPath = @"../../Records.xml";
      _xmlFilePath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ) + @"\Records.xml";

      if( !File.Exists( _xmlFilePath ) )
      {
        _xmlFilePath = devPath;
      }
    }

    //-------------------------------------------------------------------------

    public void Shutdown()
    {
      _xmlStream.WriteToXml( _xmlFilePath, CategoryManager, ManualEntryManager, RecurringEntryManager );
    }

    //-------------------------------------------------------------------------
  }
}