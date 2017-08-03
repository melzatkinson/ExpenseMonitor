using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;

namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  public partial class AddNewCategoryPopup : BasePopup
  {
    private readonly InfoCollection _infoCollection;

    //-------------------------------------------------------------------------

    public AddNewCategoryPopup( MainForm form, InfoCollection infoCollection ) : base( form, infoCollection )
    {
      _infoCollection = infoCollection;

      InitializeComponent();

      popupGroupBox.Location = new Point( 12, 92 );
      popupGroupBox.Visible = false;
      form.Controls.Add( popupGroupBox );
    }

    //-------------------------------------------------------------------------

    public override string GetName()
    {
      return "Add New Category";
    }

    //-------------------------------------------------------------------------

    private void addNewCategory_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      if( !_infoCollection.CategoriesInfo.AddCategory( newCategoryInput.Text, double.Parse( budgetInput.Text, CultureInfo.InvariantCulture ) ) )
      {
        MessageBox.Show( "Invalid! Empty or duplicate." );
      }

      newCategoryInput.Text = "";
      budgetInput.Text = "0.0";

      HidePopup();
      OnPopupClosed();
    }

    //-------------------------------------------------------------------------
  }
}
