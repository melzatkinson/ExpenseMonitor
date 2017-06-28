using System;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui
{
  public partial class ChangeCategoryBudgetForm : Form
  {
    private readonly AppManager _appManager;

    public delegate void BudgetChangedEventHandler( object source, EventArgs args );
    public event BudgetChangedEventHandler BudgetChanged;

    //-------------------------------------------------------------------------

    public ChangeCategoryBudgetForm( AppManager appManager )
    {
      InitializeComponent();

      _appManager = appManager;
      Shown += OnShown;
    }

    //-------------------------------------------------------------------------

    private void changeCategoryBudget_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      _appManager.CategoryManager.UpdateCategoryBudget( categoryInput.SelectedItem.ToString(), double.Parse( newBudgetInput.Text, CultureInfo.InvariantCulture ) );
      newBudgetInput.Text = "";

      OnBudgetChanged();

      Close();
    }

    //-------------------------------------------------------------------------

    public void OnShown( object sender, EventArgs e )
    {
      categoryInput.Items.Clear();

      foreach( var category in _appManager.CategoryManager.CategoryInfos )
      {
        categoryInput.Items.Add( category.Key );
        newBudgetInput.Text = Convert.ToString( category.Value, CultureInfo.InvariantCulture );
      }

      categoryInput.SelectedIndex = 0;
    }

    //-------------------------------------------------------------------------

    private void categoryInput_SelectedIndexChanged( object sender, EventArgs e )
    {
      newBudgetInput.Text = Convert.ToString( _appManager.CategoryManager.GetBudgetFromName( categoryInput.Text ), CultureInfo.InvariantCulture );
    }

    //-------------------------------------------------------------------------

    protected virtual void OnBudgetChanged()
    {
      BudgetChanged?.Invoke( this, EventArgs.Empty );
    }

    //-------------------------------------------------------------------------
  }
}
