using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui.Popups
{
  class PopupFactory
  {
    //-------------------------------------------------------------------------

    public static IEnumerable<BasePopup> CreatePopups( MainForm form, InfoCollection infoCollection )
    {
      object[] constructorArgs = { form, infoCollection };

      foreach( var type in Assembly.GetAssembly( typeof( BasePopup ) ).GetTypes().
               Where( myType => myType.IsSubclassOf( typeof( BasePopup ) ) ) )
      {
        yield return ( BasePopup )Activator.CreateInstance( type, constructorArgs );
      }
    }

    //-------------------------------------------------------------------------
  }
}
