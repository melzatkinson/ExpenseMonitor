using System;
using System.Linq;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui
{
  public partial class AddFixedEntryForm : Form
  {
    private readonly AppManager _appManager;

    //-------------------------------------------------------------------------

    public AddFixedEntryForm( AppManager appManager )
    {
      _appManager = appManager;

      InitializeComponent();

      Shown += OnShown;
    }

    //-------------------------------------------------------------------------


    public void OnShown( object sender, EventArgs e )
    {
      fixedEntriesTable.Rows.Clear();

      foreach( var entry in _appManager.RecurringEntryManager.RecurringEntries )
      {
        var index = fixedEntriesTable.Rows.Add();

        DataGridViewComboBoxCell comboBox = ( DataGridViewComboBoxCell )fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryCategory" ];
        comboBox.Items.Clear();

        int categoryIndex = 0;

        foreach( var category in _appManager.CategoryManager.CategoryInfos )
        {
          comboBox.Items.Add( category.Key );

          if( category.Key == entry.Category )
          {
            comboBox.Value = comboBox.Items[ categoryIndex ];
          }

          categoryIndex++;
        }

        fixedEntriesTable.Rows[index].Cells["selected"].Value = false;
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
        DataGridViewRow row = ( DataGridViewRow )entry;

        string category = row.Cells[ "fixedEntryCategory" ].Value.ToString();
        double amount = Convert.ToDouble( row.Cells[ "fixedEntryAmount" ].Value );
        string description = ( string )row.Cells[ "fixedEntryDescription" ].Value;

        if( ( bool )row.Cells[ "selected" ].Value )
        {
          _appManager.ManualEntryManager.Add( DateTime.Now.Date, category, amount, description );
        }

        _appManager.RecurringEntryManager.UpdateAtIndex( index, category, amount, description );
        index++;
      }

      Close();
    }

    //-------------------------------------------------------------------------

    private void addNewRecurringEntry_Click( object sender, EventArgs e )
    {
      var index = fixedEntriesTable.Rows.Add();
      DataGridViewComboBoxCell comboBox = ( DataGridViewComboBoxCell )fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryCategory" ];

      foreach( var category in _appManager.CategoryManager.CategoryInfos )
      {
        comboBox.Items.Add( category.Key );
      }

      comboBox.Value = comboBox.Items[ 0 ];
      fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryAmount" ].Value = "0.0";
      fixedEntriesTable.Rows[ index ].Cells[ "selected" ].Value = false;
      fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryDescription" ].Value = "";

      _appManager.RecurringEntryManager.Add( _appManager.CategoryManager.CategoryInfos.First().Key, 0.0, "" );
    }

    //-------------------------------------------------------------------------

    private void removeSelectedRow_Click( object sender, EventArgs e )
    {
      int selectedIndex = fixedEntriesTable.CurrentCell.RowIndex;
      fixedEntriesTable.Rows.RemoveAt( selectedIndex );
      _appManager.RecurringEntryManager.RemoveAt( selectedIndex );
    }

    //-------------------------------------------------------------------------
  }
}
