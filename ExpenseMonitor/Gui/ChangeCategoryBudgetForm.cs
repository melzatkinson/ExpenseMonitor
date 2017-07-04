using System;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui
{
  public partial class ChangeCategoryBudgetForm : Form
  {
    private readonly ICategoriesInfo _categoriesInfo;

    public delegate void BudgetChangedEventHandler( object source, EventArgs args );
    public event BudgetChangedEventHandler BudgetChanged;

    //-------------------------------------------------------------------------

    public ChangeCategoryBudgetForm( ICategoriesInfo categoriesInfo )
    {
      InitializeComponent();

      _categoriesInfo = categoriesInfo;

      Shown += OnShown;
    }

    //-------------------------------------------------------------------------

    private void changeCategoryBudget_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      _categoriesInfo.UpdateCategoryBudget( categoryInput.SelectedItem.ToString(), double.Parse( newBudgetInput.Text, CultureInfo.InvariantCulture ) );
      newBudgetInput.Text = "";

      OnBudgetChanged();

      Close();
    }

    //-------------------------------------------------------------------------

    public void OnShown( object sender, EventArgs e )
    {
      categoryInput.Items.Clear();

      foreach( var category in _categoriesInfo.GetCategories() )
      {
        categoryInput.Items.Add( category.Key );
        newBudgetInput.Text = Convert.ToString( category.Value, CultureInfo.InvariantCulture );
      }

      categoryInput.SelectedIndex = 0;
    }

    //-------------------------------------------------------------------------

    private void categoryInput_SelectedIndexChanged( object sender, EventArgs e )
    {
      newBudgetInput.Text = Convert.ToString( _categoriesInfo.GetBudgetForCategory( categoryInput.Text ), CultureInfo.InvariantCulture );
    }

    //-------------------------------------------------------------------------

    protected virtual void OnBudgetChanged()
    {
      BudgetChanged?.Invoke( this, EventArgs.Empty );
    }

    //-------------------------------------------------------------------------
  }
}
