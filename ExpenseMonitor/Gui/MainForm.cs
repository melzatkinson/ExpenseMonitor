using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.EntryFiltering;
using ExpenseMonitor.AppManagement.EntryFiltering.Specifications;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;
using ExpenseMonitor.Gui;
using ExpenseMonitor.Gui.BarGraph;
using ExpenseMonitor.Gui.Popups;

namespace ExpenseMonitor
{
  public partial class MainForm : Form
  {
    private BarGraph _barGraph;

    private readonly EntryFilter _entryFilter = new EntryFilter();

    private readonly InfoCollection _infoCollection;

    private List<BasePopup> _popups;

    //-------------------------------------------------------------------------

    public MainForm( InfoCollection infoCollection )
    {
      _infoCollection = infoCollection;

      _popups = PopupFactory.CreatePopups( this, infoCollection ).ToList();

      InitialiseForms();
      SetupEvents();

      InitializeComponent();

      InitialiseMainForm();
    }

    //-------------------------------------------------------------------------

    private void InitialiseMainForm()
    {
      functionOptionsInput.Text = "Select option...";

      var threeMonthsAgo = DateTime.Now.AddMonths( -3 );
      startDatePicker.Value = threeMonthsAgo;

      monthSelectedOutput.Text = endDatePicker.Value.ToString( "MMMM" ) + " " + endDatePicker.Value.Date.Year;

      RefreshForm();
    }

    //-------------------------------------------------------------------------

    private void InitialiseForms()
    {
      _barGraph = new BarGraph( _infoCollection );
    }

    //-------------------------------------------------------------------------

    private void SetupEvents()
    {
      _infoCollection.ManualEntriesInfo.ManualEntriesChanged += OnManualEntriesChanged;
      Paint += _barGraph.DrawGraph;
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

      foreach( var entry in _entryFilter.Filter( _infoCollection.ManualEntriesInfo.GetEntries(), new EntryDateSpecification( startDatePicker.Value.Date, endDatePicker.Value.Date ) ) )
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
      double totalExpenditure = _infoCollection.ManualEntriesInfo.GetTotal( new EntryMonthSpecification( endDatePicker.Value.Date ) );
      double totalBudget = _infoCollection.CategoriesInfo.GetTotalBudgetAmount();

      totalsOutput.Text = Convert.ToString( totalExpenditure, CultureInfo.InvariantCulture );
      totalsOutput.BackColor = totalExpenditure > totalBudget ? Color.Red : Color.Green;

      budgetTotalOutput.Text = Convert.ToString( totalBudget, CultureInfo.InvariantCulture );

      totalsTable.Rows.Clear();

      foreach( var category in _infoCollection.CategoriesInfo.GetCategoryNames() )
      {
        var specifications = new AndSpecification<Entry>( new EntryMonthSpecification( endDatePicker.Value.Date ),
                                                          new EntryCategorySpecification( category ) );

        var index = totalsTable.Rows.Add();
        totalsTable.Rows[ index ].Cells[ "totalsCategory" ].Value = category;
        totalsTable.Rows[ index ].Cells[ "totalsAmount" ].Value = _infoCollection.ManualEntriesInfo.GetTotal( specifications );
      }
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
      _infoCollection.ManualEntriesInfo.RemoveAt( selectedIndex );

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

    private void functionOptionsInput_SelectedIndexChanged( object sender, EventArgs e )
    {
      viewRecordsGroupbox.Visible = false;
      profilingGroup.Visible = false;
      removeSelectedEntry.Visible = false;

      PopupHelper.HideAllPopups( _popups );
      PopupHelper.GetPopupWithName( _popups, name: functionOptionsInput.SelectedItem.ToString() ).ShowPopup();

      functionOptionsInput.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    //-------------------------------------------------------------------------

    public void OnPopupClosed( object source, EventArgs e )
    {
      viewRecordsGroupbox.Visible = true;
      profilingGroup.Visible = true;
      removeSelectedEntry.Visible = true;

      functionOptionsInput.SelectionLength = 0;
      functionOptionsInput.DropDownStyle = ComboBoxStyle.DropDown;
      functionOptionsInput.Text = "Select option...";

      Invalidate();
    }

    //-------------------------------------------------------------------------
  }
}