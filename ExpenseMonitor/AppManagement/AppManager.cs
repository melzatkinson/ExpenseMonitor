namespace ExpenseMonitor.AppManagement
{
  public class AppManager
  {
    public CategoryManager CategoryManager = new CategoryManager();
    public EntryManager EntryManager = new EntryManager();

    private readonly XmlStream _xmlStream = new XmlStream();

    //-------------------------------------------------------------------------

    public AppManager()
    {
      _xmlStream.Load( @"../../Records.xml" );

      CategoryManager.Initialise( _xmlStream.GetElementsWithName( "Category" ) );
      EntryManager.Initialise( _xmlStream.GetElementsWithName( "Entry" ) );
    }

    //-------------------------------------------------------------------------

    public void Shutdown()
    {
      _xmlStream.WriteToXml( @"../../Records.xml", CategoryManager, EntryManager );
    }

    //-------------------------------------------------------------------------
  }
}