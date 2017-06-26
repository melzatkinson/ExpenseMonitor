using System;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.Gui;

namespace ExpenseMonitor
{
  public partial class MainForm : Form
  {
    private readonly AddNewCategoryForm _addNewCategoryForm;
    private readonly ChangeCategoryBudgetForm _changeCategoryBudgetForm;
    private readonly AddFixedEntryForm _addFixedEntryForm;


    private readonly AppManager _appManager;


    //-------------------------------------------------------------------------

    public MainForm( AppManager appManager )
    {
      _appManager = appManager;
      _addNewCategoryForm = new AddNewCategoryForm( _appManager );
      _changeCategoryBudgetForm = new ChangeCategoryBudgetForm( _appManager );
      _addFixedEntryForm = new AddFixedEntryForm( _appManager );

      _appManager.CategoryManager.CategoriesChanged += OnCategoriesChanged;
      _appManager.ManualEntryManager.ManualEntriesChanged += OnManualEntriesChanged;

      InitializeComponent();

      RefreshCategoriesComboBox( _appManager.CategoryManager );
      existingCategories.SelectedIndex = 0;

      RefreshRecords();

      DateTime threeMonthsAgo = DateTime.Now.AddMonths( -3 );
      startDatePicker.Value = threeMonthsAgo;
    }


    //-------------------------------------------------------------------------

    private void addNewCategory_Click( object sender, EventArgs e )
    {
      _addNewCategoryForm.ShowDialog( this );
    }


    //-------------------------------------------------------------------------

    private void changeBudget_Click( object sender, EventArgs e )
    {
      _changeCategoryBudgetForm.ShowDialog( this );
    }


    //-------------------------------------------------------------------------

    private void addFixedEntryButton_Click( object sender, EventArgs e )
    {
      _addFixedEntryForm.ShowDialog();
    }

    //-------------------------------------------------------------------------

    public void OnCategoriesChanged( object source, EventArgs e )
    {
      CategoryManager categoryManager = ( CategoryManager )source;
      if( categoryManager == null )
        return;

      RefreshCategoriesComboBox( categoryManager );

      existingCategories.SelectedIndex = existingCategories.Items.Count - 1;

      _addNewCategoryForm.Close();
    }

    //-------------------------------------------------------------------------

    public void OnManualEntriesChanged( object source, EventArgs e )
    {
      RefreshRecords();
    }

    //-------------------------------------------------------------------------

    private void RefreshCategoriesComboBox( CategoryManager categoryManager )
    {
      existingCategories.Items.Clear();

      foreach( var category in categoryManager.CategoryInfos )
      {
        existingCategories.Items.Add( category.Key );
      }
    }

    //-------------------------------------------------------------------------

    private void RefreshRecords()
    {
      recordsTable.Rows.Clear();

      foreach( var entry in _appManager.ManualEntryManager.Entries )
      {
        if( DateTime.Compare( startDatePicker.Value.Date, entry.Date ) <= 0 &&
            DateTime.Compare( endDatePicker.Value.Date, entry.Date ) >= 0 )
        {
          var index = recordsTable.Rows.Add();
          recordsTable.Rows[ index ].Cells[ "EntryCategory" ].Value = entry.Category;
          recordsTable.Rows[ index ].Cells[ "EntryAmount" ].Value = entry.Amount;
          recordsTable.Rows[ index ].Cells[ "EntryDate" ].Value = entry.Date.ToString( "dd/MM/yyyy" ); ;
          recordsTable.Rows[ index ].Cells[ "EntryDescription" ].Value = entry.Description;
        }
      }
    }

    //-------------------------------------------------------------------------

    private void AddNewEntry_Click( object sender, EventArgs e )
    {
      _appManager.ManualEntryManager.Add(
        DateTime.Now.Date,
        existingCategories.SelectedItem.ToString(),
        double.Parse( amountInput.Text, CultureInfo.InvariantCulture ),
        descriptionInput.Text );

      amountInput.Text = "";
      descriptionInput.Text = "";
    }

    //-------------------------------------------------------------------------

    private void startDatePicker_ValueChanged( object sender, EventArgs e )
    {
      RefreshRecords();
    }

    //-------------------------------------------------------------------------

    private void endDatePicker_ValueChanged( object sender, EventArgs e )
    {
      RefreshRecords();
    }

    //-------------------------------------------------------------------------

    private void removeSelectedEntry_Click( object sender, EventArgs e )
    {
      int selectedIndex = recordsTable.CurrentCell.RowIndex;
      recordsTable.Rows.RemoveAt( selectedIndex );
      _appManager.ManualEntryManager.RemoveAt( selectedIndex );
    }

    //-------------------------------------------------------------------------
  }
}
