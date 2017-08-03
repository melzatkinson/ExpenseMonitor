using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;
using ExpenseMonitor.Gui.Popups;

namespace ExpenseMonitor.Gui
{
  class PopupManager
  {
    readonly List<BasePopup> _popups = new List<BasePopup>();

    //-------------------------------------------------------------------------

    public PopupManager( MainForm form, InfoCollection infoCollection )
    {
      object[] constructorArgs = { form, infoCollection };

      foreach( var type in Assembly.GetAssembly( typeof( BasePopup ) ).GetTypes().
                           Where( myType => myType.IsSubclassOf( typeof( BasePopup ) ) ) )
      {
        _popups.Add( ( BasePopup )Activator.CreateInstance( type, constructorArgs ) );
      }
    }

    //-------------------------------------------------------------------------

    public void CreatePopup( string selectedOperation )
    {
      foreach( var popup in _popups )
      {
        popup.HidePopup();
      }

      GetPopupWithName( selectedOperation ).ShowPopup();
    }

    //-------------------------------------------------------------------------

    private BasePopup GetPopupWithName( string name )
    {
      foreach( var popup in _popups )
        if( popup.GetName().Equals( name ) )
          return popup;

      return null;
    }

    //-------------------------------------------------------------------------
  }
}
