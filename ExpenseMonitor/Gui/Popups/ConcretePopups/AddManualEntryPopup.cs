using System;
using System.Drawing;
using System.Globalization;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  public partial class AddManualEntryPopup : BasePopup
  {
    private readonly InfoCollection _infoCollection;

    //-------------------------------------------------------------------------

    public AddManualEntryPopup( MainForm form, InfoCollection infoCollection ) : base( form, infoCollection )
    {
      _infoCollection = infoCollection;

      InitializeComponent();

      popupGroupBox.Location = new Point( 12, 92 );
      popupGroupBox.Visible = false;
      form.Controls.Add( popupGroupBox );
    }

    //-------------------------------------------------------------------------

    public override void ShowPopup()
    {
      popupGroupBox.Visible = true;
      RefreshCategoriesComboBox();
    }

    //-------------------------------------------------------------------------

    public override string GetName()
    {
      return "Add Manual Entry";
    }

    //-------------------------------------------------------------------------

    private void AddNewEntry_Click( object sender, EventArgs e )
    {
      _infoCollection.ManualEntriesInfo.Add( DateTime.Now.Date,
                                             existingCategories.SelectedItem.ToString(),
                                             double.Parse( amountInput.Text, CultureInfo.InvariantCulture ),
                                             descriptionInput.Text );

      HidePopup();
      OnPopupClosed();
    }

    //-------------------------------------------------------------------------

    private void RefreshCategoriesComboBox()
    {
      if( existingCategories.Items.Count > 0 )
        existingCategories.Items.Clear();

      foreach( var category in _infoCollection.CategoriesInfo.GetCategories() )
      {
        existingCategories.Items.Add( category.Key );
      }

      existingCategories.SelectedIndex = 0;
    }

    //-------------------------------------------------------------------------
  }
}
