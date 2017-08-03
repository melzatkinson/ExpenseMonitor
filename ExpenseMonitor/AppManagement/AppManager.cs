using System.IO;
using System.Reflection;

namespace ExpenseMonitor.AppManagement
{
  public class AppManager
  {
    private readonly InfoCollection _infoCollection;

    private readonly XmlStream _xmlStream = XmlStream.Instance;

    private string _xmlFilePath;

    //-------------------------------------------------------------------------

    public AppManager( InfoCollection infoCollection )
    {
      _infoCollection = infoCollection;

      SetXmlFilePath();

      File.SetAttributes( _xmlFilePath, FileAttributes.Normal );

      _xmlStream.Load( _xmlFilePath );

      _infoCollection.CategoriesInfo.Initialise( _xmlStream.GetElementsWithName( "Category" ) );
      _infoCollection.ManualEntriesInfo.Initialise( _xmlStream.GetElementsWithName( "ManualEntry" ) );
      _infoCollection.RecurringEntriesInfo.Initialise( _xmlStream.GetElementsWithName( "RecurringEntry" ) );
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
      _xmlStream.WriteToXml( _xmlFilePath,
                             _infoCollection.CategoriesInfo,
                             _infoCollection.ManualEntriesInfo,
                             _infoCollection.RecurringEntriesInfo );
    }

    //-------------------------------------------------------------------------
  }
}