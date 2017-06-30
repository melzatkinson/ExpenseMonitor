using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.EntryFiltering;
using ExpenseMonitor.AppManagement.EntryFiltering.Specifications;
using ExpenseMonitor.Gui;

namespace ExpenseMonitor
{
  public partial class MainForm : Form
  {
    private AddNewCategoryForm _addNewCategoryForm;
    private ChangeCategoryBudgetForm _changeCategoryBudgetForm;
    private AddFixedEntryForm _addFixedEntryForm;
    private BarGraph _barGraph;

    private readonly EntryFilter _entryFilter = new EntryFilter();

    private readonly AppManager _appManager;

    //-------------------------------------------------------------------------

    public MainForm( AppManager appManager )
    {
      _appManager = appManager;

      InitialiseForms();
      SetupEvents();

      InitializeComponent();

      InitialiseMainForm();
    }

    //-------------------------------------------------------------------------

    private void InitialiseMainForm()
    {
      RefreshCategoriesComboBox( _appManager.CategoryManager );

      if( existingCategories.Items.Count > 0 )
        existingCategories.SelectedIndex = 0;

      DateTime threeMonthsAgo = DateTime.Now.AddMonths( -3 );
      startDatePicker.Value = threeMonthsAgo;

      maximumGraphYValueInput.Text = Convert.ToString( _barGraph.MaximumAmount );
      monthSelectedOutput.Text = endDatePicker.Value.ToString( "MMMM" ) + " " + endDatePicker.Value.Date.Year;

      RefreshForm();
    }

    //-------------------------------------------------------------------------

    private void InitialiseForms()
    {
      _addNewCategoryForm = new AddNewCategoryForm( _appManager );
      _changeCategoryBudgetForm = new ChangeCategoryBudgetForm( _appManager );
      _addFixedEntryForm = new AddFixedEntryForm( _appManager );
      _barGraph = new BarGraph( _appManager );
    }

    //-------------------------------------------------------------------------

    private void SetupEvents()
    {
      _appManager.CategoryManager.CategoriesChanged += OnCategoriesChanged;
      _appManager.ManualEntryManager.ManualEntriesChanged += OnManualEntriesChanged;
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

    public void OnBudgetChanged( object source, EventArgs e )
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

      foreach( var entry in _entryFilter.Filter( _appManager.ManualEntryManager.Entries, new EntryDateSpecification( startDatePicker.Value.Date, endDatePicker.Value.Date ) ) )
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
      double totalExpenditure = _appManager.ManualEntryManager.GetTotal( new List<ISpecification<ManualEntryManager.Entry>>() { new EntryMonthSpecification( endDatePicker.Value.Date ) } );
      double totalBudget = _appManager.CategoryManager.GetTotalBudgetAmount();

      totalsOutput.Text = Convert.ToString( totalExpenditure, CultureInfo.InvariantCulture );
      totalsOutput.BackColor = totalExpenditure > totalBudget ? Color.Red : Color.Green;

      budgetTotalOutput.Text = Convert.ToString( totalBudget, CultureInfo.InvariantCulture );

      totalsTable.Rows.Clear();

      foreach( var category in _appManager.CategoryManager.CategoryInfos.Keys )
      {
        var specifications = new List<ISpecification<ManualEntryManager.Entry>>()
        {
          new EntryMonthSpecification(endDatePicker.Value.Date),
          new EntryCategorySpecification(category)
        };

        var index = totalsTable.Rows.Add();
        totalsTable.Rows[ index ].Cells[ "totalsCategory" ].Value = category;
        totalsTable.Rows[ index ].Cells[ "totalsAmount" ].Value = _appManager.ManualEntryManager.GetTotal( specifications );
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
      monthSelectedOutput.Text = endDatePicker.Value.ToString( "MMMM" ) + " " + endDatePicker.Value.Date.Year;
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

    private void maximumGraphYValueInput_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      _barGraph.MaximumAmount = Convert.ToInt32( maximumGraphYValueInput.Text );
      Invalidate();
    }

    //-------------------------------------------------------------------------
  }
}