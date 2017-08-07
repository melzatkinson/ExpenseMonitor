using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseMonitor.Gui.Popups
{
  class PopupHelper
  {
    //-------------------------------------------------------------------------

    public static BasePopup GetPopupWithName( IEnumerable<BasePopup> popups, string name )
    {
      foreach( var popup in popups )
        if( popup.GetName().Equals( name ) )
          return popup;

      return null;
    }

    //-------------------------------------------------------------------------

    public static void HideAllPopups( IEnumerable<BasePopup> popups )
    {
      foreach( var popup in popups )
       popup.HidePopup();
    }

    //-------------------------------------------------------------------------
  }
}
