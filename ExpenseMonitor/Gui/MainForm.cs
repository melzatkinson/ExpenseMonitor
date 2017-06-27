using System;
using System.Drawing;
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
    private readonly BarGraph _barGraph;

    private readonly AppManager _appManager;

    //-------------------------------------------------------------------------

    public MainForm( AppManager appManager )
    {
      _appManager = appManager;
      _addNewCategoryForm = new AddNewCategoryForm( _appManager );
      _changeCategoryBudgetForm = new ChangeCategoryBudgetForm( _appManager );
      _addFixedEntryForm = new AddFixedEntryForm( _appManager );
      _barGraph = new BarGraph( _appManager );

      _appManager.CategoryManager.CategoriesChanged += OnCategoriesChanged;
      _appManager.ManualEntryManager.ManualEntriesChanged += OnManualEntriesChanged;
      Paint += _barGraph.DrawGraph;

      InitializeComponent();

      RefreshCategoriesComboBox( _appManager.CategoryManager );

      if( existingCategories.Items.Count > 0 )
        existingCategories.SelectedIndex = 0;

      RefreshForm();

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
      RefreshForm();
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

    private void RefreshForm()
    {
      RefreshRecords();
      RefreshProfilingInformation();
      Invalidate();
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

    private void RefreshProfilingInformation()
    {
      double totalExpenditure = _appManager.ManualEntryManager.GetTotalAmountForMonth( endDatePicker.Value.Date );
      double totalBudget = _appManager.CategoryManager.GetTotalBudgetAmount();

      totalsOutput.Text = Convert.ToString( totalExpenditure, CultureInfo.InvariantCulture );
      totalsOutput.BackColor = totalExpenditure > totalBudget ? Color.Red : Color.Green;

      budgetTotalOutput.Text = Convert.ToString( totalBudget, CultureInfo.InvariantCulture );

      totalsTable.Rows.Clear();

      foreach( var category in _appManager.CategoryManager.CategoryInfos.Keys )
      {
        var index = totalsTable.Rows.Add();
        totalsTable.Rows[ index ].Cells[ "totalsCategory" ].Value = category;
        totalsTable.Rows[ index ].Cells[ "totalsAmount" ].Value = _appManager.ManualEntryManager.GetTotalAmountForCategoryInMonth( category, endDatePicker.Value.Date );
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

      Invalidate();
    }

    //-------------------------------------------------------------------------

    private void startDatePicker_ValueChanged( object sender, EventArgs e )
    {
      RefreshForm();
    }

    //-------------------------------------------------------------------------

    private void endDatePicker_ValueChanged( object sender, EventArgs e )
    {
      RefreshForm();
    }

    //-------------------------------------------------------------------------

    private void removeSelectedEntry_Click( object sender, EventArgs e )
    {
      int selectedIndex = recordsTable.CurrentCell.RowIndex;
      recordsTable.Rows.RemoveAt( selectedIndex );
      _appManager.ManualEntryManager.RemoveAt( selectedIndex );

      Invalidate();
    }

    //-------------------------------------------------------------------------

    public DateTime GetSelectedStartDate()
    {
      return startDatePicker.Value.Date;
    }

    //-------------------------------------------------------------------------

    public DateTime GetSelectedEndDate()
    {
      return endDatePicker.Value.Date;
    }

    //-------------------------------------------------------------------------
  }
}