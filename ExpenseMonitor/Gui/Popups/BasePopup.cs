using System;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui.Popups
{
  public partial class BasePopup : UserControl
  {
    public delegate void PopupClosedEventHandler( object source, EventArgs args );

    public event PopupClosedEventHandler PopupClosed;

    //-------------------------------------------------------------------------

    public BasePopup()
    {
      InitializeComponent();
    }

    //-------------------------------------------------------------------------

    public BasePopup( MainForm form, InfoCollection infoCollection )
    {
      InitializeComponent();

      PopupClosed += form.OnPopupClosed;
    }

    //-------------------------------------------------------------------------

    public virtual void HidePopup()
    {
      popupGroupBox.Visible = false;
    }

    //-------------------------------------------------------------------------

    public virtual void ShowPopup()
    {
      popupGroupBox.Visible = true;
    }

    //-------------------------------------------------------------------------

    public virtual string GetName()
    {
      return "Not implemented.";
    }

    //-------------------------------------------------------------------------

    protected virtual void OnPopupClosed()
    {
      PopupClosed?.Invoke( this, EventArgs.Empty );
    }

    //-------------------------------------------------------------------------

    private void closePopup_Click( object sender, EventArgs e )
    {
      HidePopup();
      OnPopupClosed();
    }

    //-------------------------------------------------------------------------
  }
}
