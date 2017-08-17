using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  public partial class UpdateExistingCategoryBudgetPopup : BasePopup
  {
    private readonly InfoCollection _infoCollection;

    //-------------------------------------------------------------------------

    public UpdateExistingCategoryBudgetPopup( MainForm form, InfoCollection infoCollection ) : base( form, infoCollection )
    {
      _infoCollection = infoCollection;

      InitializeComponent();

      popupGroupBox.Location = new Point( 12, 92 );
      popupGroupBox.Visible = false;
      form.Controls.Add( popupGroupBox );

      RefreshCategoriesComboBox();
    }

    //-------------------------------------------------------------------------

    public override string GetName()
    {
      return "Update Existing Category Budget";
    }

    //-------------------------------------------------------------------------

    private void categoryInput_SelectedIndexChanged( object sender, EventArgs e )
    {
      newBudgetInput.Text = Convert.ToString( _infoCollection.CategoriesInfo.GetBudgetForCategory( categoryInput.Text ), CultureInfo.InvariantCulture );
    }

    //-------------------------------------------------------------------------

    private void changeCategoryBudget_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      _infoCollection.CategoriesInfo.UpdateCategoryBudget( categoryInput.SelectedItem.ToString(), double.Parse( newBudgetInput.Text, CultureInfo.InvariantCulture ) );
      newBudgetInput.Text = "";

      HidePopup();
    }

    //-------------------------------------------------------------------------

    private void RefreshCategoriesComboBox()
    {
      if( categoryInput.Items.Count > 0 )
          categoryInput.Items.Clear();

      foreach( var category in _infoCollection.CategoriesInfo.GetCategories() )
      {
        categoryInput.Items.Add( category.Key );
      }

      if( categoryInput.Items.Count > 0 )
        categoryInput.SelectedIndex = 0;
    }

    //-------------------------------------------------------------------------
  }
}
