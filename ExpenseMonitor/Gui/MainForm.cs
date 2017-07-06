using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.EntryFiltering;
using ExpenseMonitor.AppManagement.EntryFiltering.Specifications;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;
using ExpenseMonitor.Gui;
using ExpenseMonitor.Gui.BarGraph;

namespace ExpenseMonitor
{
  public partial class MainForm : Form
  {
    private AddNewCategoryForm _addNewCategoryForm;
    private ChangeCategoryBudgetForm _changeCategoryBudgetForm;
    private AddFixedEntryForm _addFixedEntryForm;
    private BarGraph _barGraph;

    private readonly EntryFilter _entryFilter = new EntryFilter();

    private readonly IManualEntriesInfo _manualEntriesInfo;
    private readonly ICategoriesInfo _categoriesInfo;
    private readonly IRecurringEntriesInfo _recurringEntriesInfo;

    //-------------------------------------------------------------------------

    public MainForm( IManualEntriesInfo manualEntriesInfo, ICategoriesInfo categoriesInfo, IRecurringEntriesInfo recurringEntriesInfo )
    {
      _manualEntriesInfo = manualEntriesInfo;
      _categoriesInfo = categoriesInfo;
      _recurringEntriesInfo = recurringEntriesInfo;

      InitialiseForms();
      SetupEvents();

      InitializeComponent();

      InitialiseMainForm();
    }

    //-------------------------------------------------------------------------

    private void InitialiseMainForm()
    {
      RefreshCategoriesComboBox( _categoriesInfo );

      if( existingCategories.Items.Count > 0 )
        existingCategories.SelectedIndex = 0;

      var threeMonthsAgo = DateTime.Now.AddMonths( -3 );
      startDatePicker.Value = threeMonthsAgo;

      monthSelectedOutput.Text = endDatePicker.Value.ToString( "MMMM" ) + " " + endDatePicker.Value.Date.Year;

      RefreshForm();
    }

    //-------------------------------------------------------------------------

    private void InitialiseForms()
    {
      _addNewCategoryForm = new AddNewCategoryForm( _categoriesInfo );
      _changeCategoryBudgetForm = new ChangeCategoryBudgetForm( _categoriesInfo );
      _addFixedEntryForm = new AddFixedEntryForm( _manualEntriesInfo, _categoriesInfo, _recurringEntriesInfo );
      _barGraph = new BarGraph( _manualEntriesInfo, _categoriesInfo );
    }

    //-------------------------------------------------------------------------

    private void SetupEvents()
    {
      _categoriesInfo.CategoriesChanged += OnCategoriesChanged;
      _manualEntriesInfo.ManualEntriesChanged += OnManualEntriesesChanged;
      _changeCategoryBudgetForm.BudgetChanged += OnBudgetChanged;
      Paint += _barGraph.DrawGraph;
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
      var categoriesManager = ( ICategoriesInfo )source;
      if( categoriesManager == null )
        return;

      RefreshCategoriesComboBox( categoriesManager );

      existingCategories.SelectedIndex = existingCategories.Items.Count - 1;

      _addNewCategoryForm.Close();
    }

    //-------------------------------------------------------------------------

    public void OnManualEntriesesChanged( object source, EventArgs e )
    {
      RefreshForm();
    }

    //-------------------------------------------------------------------------

    public void OnBudgetChanged( object source, EventArgs e )
    {
      RefreshForm();
    }

    //-------------------------------------------------------------------------

    private void RefreshCategoriesComboBox( ICategoriesInfo categoriesInfo )
    {
      existingCategories.Items.Clear();

      foreach( var category in categoriesInfo.GetCategories() )
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

      foreach( var entry in _entryFilter.Filter( _manualEntriesInfo.GetEntries(), new EntryDateSpecification( startDatePicker.Value.Date, endDatePicker.Value.Date ) ) )
      {
        var index = recordsTable.Rows.Add();
        recordsTable.Rows[ index ].Cells[ "EntryCategory" ].Value = entry.Category;
        recordsTable.Rows[ index ].Cells[ "EntryAmount" ].Value = entry.Amount;
        recordsTable.Rows[ index ].Cells[ "EntryDate" ].Value = entry.Date.ToString( "dd/MM/yyyy" ); ;
        recordsTable.Rows[ index ].Cells[ "EntryDescription" ].Value = entry.Description;
      }
    }

    //-------------------------------------------------------------------------

    private void RefreshProfilingInformation()
    {
      double totalExpenditure = _manualEntriesInfo.GetTotal( new EntryMonthSpecification( endDatePicker.Value.Date ) );
      double totalBudget = _categoriesInfo.GetTotalBudgetAmount();

      totalsOutput.Text = Convert.ToString( totalExpenditure, CultureInfo.InvariantCulture );
      totalsOutput.BackColor = totalExpenditure > totalBudget ? Color.Red : Color.Green;

      budgetTotalOutput.Text = Convert.ToString( totalBudget, CultureInfo.InvariantCulture );

      totalsTable.Rows.Clear();

      foreach( var category in _categoriesInfo.GetCategoryNames() )
      {
        var specifications = new AndSpecification<Entry>( new EntryMonthSpecification( endDatePicker.Value.Date ),
                                                          new EntryCategorySpecification( category ) );

        var index = totalsTable.Rows.Add();
        totalsTable.Rows[ index ].Cells[ "totalsCategory" ].Value = category;
        totalsTable.Rows[ index ].Cells[ "totalsAmount" ].Value = _manualEntriesInfo.GetTotal( specifications );
      }
    }

    //-------------------------------------------------------------------------

    private void AddNewEntry_Click( object sender, EventArgs e )
    {
      _manualEntriesInfo.Add(
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
      monthSelectedOutput.Text = endDatePicker.Value.ToString( "MMMM" ) + " " + endDatePicker.Value.Date.Year;
    }

    //-------------------------------------------------------------------------

    private void removeSelectedEntry_Click( object sender, EventArgs e )
    {
      int selectedIndex = recordsTable.CurrentCell.RowIndex;
      recordsTable.Rows.RemoveAt( selectedIndex );
      _manualEntriesInfo.RemoveAt( selectedIndex );

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

    private void addNewBudget_Click( object sender, EventArgs e )
    {
      _addNewCategoryForm.ShowDialog( this );
    }

    //-------------------------------------------------------------------------

    private void updateExistingBudget_Click( object sender, EventArgs e )
    {
      _changeCategoryBudgetForm.ShowDialog( this );
    }

    //-------------------------------------------------------------------------
  }
}