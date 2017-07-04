using System;
using System.Linq;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.ManualEntries;
using ExpenseMonitor.AppManagement.RecurringEntries;

namespace ExpenseMonitor.Gui
{
  public partial class AddFixedEntryForm : Form
  {
    private readonly IManualEntriesInfo _manualEntriesInfo;
    private readonly ICategoriesInfo _categoriesInfo;
    private readonly IRecurringEntriesInfo _recurringEntriesInfo;

    //-------------------------------------------------------------------------

    public AddFixedEntryForm( IManualEntriesInfo manualEntriesInfo, ICategoriesInfo categoriesInfo, IRecurringEntriesInfo recurringEntriesInfo )
    {
      _manualEntriesInfo = manualEntriesInfo;
      _categoriesInfo = categoriesInfo;
      _recurringEntriesInfo = recurringEntriesInfo;

      InitializeComponent();

      Shown += OnShown;
    }

    //-------------------------------------------------------------------------

    public void OnShown( object sender, EventArgs e )
    {
      fixedEntriesTable.Rows.Clear();

      foreach( var entry in _recurringEntriesInfo.GetEntries() )
      {
        var index = fixedEntriesTable.Rows.Add();

        var comboBox = ( DataGridViewComboBoxCell )fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryCategory" ];
        comboBox.Items.Clear();

        int categoryIndex = 0;

        foreach( var category in _categoriesInfo.GetCategories() )
        {
          comboBox.Items.Add( category.Key );

          if( category.Key == entry.Category )
          {
            comboBox.Value = comboBox.Items[ categoryIndex ];
          }

          categoryIndex++;
        }

        fixedEntriesTable.Rows[ index ].Cells[ "selected" ].Value = false;
        fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryAmount" ].Value = entry.Amount;
        fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryDescription" ].Value = entry.Description;
      }
    }

    //-------------------------------------------------------------------------

    private void submit_Click( object sender, EventArgs e )
    {
      int index = 0;

      foreach( var entry in fixedEntriesTable.Rows )
      {
        var row = ( DataGridViewRow )entry;

        var category = row.Cells[ "fixedEntryCategory" ].Value.ToString();
        var amount = Convert.ToDouble( row.Cells[ "fixedEntryAmount" ].Value );
        var description = ( string )row.Cells[ "fixedEntryDescription" ].Value;

        if( ( bool )row.Cells[ "selected" ].Value )
        {
          _manualEntriesInfo.Add( DateTime.Now.Date, category, amount, description );
        }

        _recurringEntriesInfo.UpdateAtIndex( index, category, amount, description );
        index++;
      }

      Close();
    }

    //-------------------------------------------------------------------------

    private void addNewRecurringEntry_Click( object sender, EventArgs e )
    {
      var index = fixedEntriesTable.Rows.Add();
      var comboBox = ( DataGridViewComboBoxCell )fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryCategory" ];

      foreach( var category in _categoriesInfo.GetCategories() )
      {
        comboBox.Items.Add( category.Key );
      }

      comboBox.Value = comboBox.Items[ 0 ];
      fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryAmount" ].Value = "0.0";
      fixedEntriesTable.Rows[ index ].Cells[ "selected" ].Value = false;
      fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryDescription" ].Value = "";

      _recurringEntriesInfo.Add( _categoriesInfo.GetCategories().First().Key, 0.0, "" );
    }

    //-------------------------------------------------------------------------

    private void removeSelectedRow_Click( object sender, EventArgs e )
    {
      int selectedIndex = fixedEntriesTable.CurrentCell.RowIndex;
      fixedEntriesTable.Rows.RemoveAt( selectedIndex );
      _recurringEntriesInfo.RemoveAt( selectedIndex );
    }

    //-------------------------------------------------------------------------
  }
}
