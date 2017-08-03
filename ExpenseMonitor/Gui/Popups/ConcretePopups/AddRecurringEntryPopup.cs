using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  public partial class AddRecurringEntryPopup : BasePopup
  {
    private readonly InfoCollection _infoCollection;

    //-------------------------------------------------------------------------

    public AddRecurringEntryPopup( MainForm form, InfoCollection infoCollection ) : base( form, infoCollection )
    {
      _infoCollection = infoCollection;

      InitializeComponent();

      popupGroupBox.Location = new Point( 12, 92 );
      popupGroupBox.Size = new Size( 617, 395 );
      popupGroupBox.Visible = false;
      form.Controls.Add( popupGroupBox );
    }

    //-------------------------------------------------------------------------

    public override void ShowPopup()
    {
      popupGroupBox.Visible = true;
      Setup();
    }

    //-------------------------------------------------------------------------

    public override string GetName()
    {
      return "Add Recurring Entry";
    }

    //-------------------------------------------------------------------------

    private void Setup()
    {
      fixedEntriesTable.Rows.Clear();

      foreach( var entry in _infoCollection.RecurringEntriesInfo.GetEntries() )
      {
        var index = fixedEntriesTable.Rows.Add();

        var comboBox = ( DataGridViewComboBoxCell )fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryCategory" ];
        comboBox.Items.Clear();

        int categoryIndex = 0;

        foreach( var category in _infoCollection.CategoriesInfo.GetCategories() )
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

    private void submit_Click( object sender, System.EventArgs e )
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
          _infoCollection.ManualEntriesInfo.Add( DateTime.Now.Date, category, amount, description );
        }

        _infoCollection.RecurringEntriesInfo.UpdateAtIndex( index, category, amount, description );
        index++;
      }

      HidePopup();
      OnPopupClosed();
    }

    //-------------------------------------------------------------------------

    private void addNewRecurringEntry_Click( object sender, System.EventArgs e )
    {
      var index = fixedEntriesTable.Rows.Add();
      var comboBox = ( DataGridViewComboBoxCell )fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryCategory" ];

      foreach( var category in _infoCollection.CategoriesInfo.GetCategories() )
      {
        comboBox.Items.Add( category.Key );
      }

      comboBox.Value = comboBox.Items[ 0 ];
      fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryAmount" ].Value = "0.0";
      fixedEntriesTable.Rows[ index ].Cells[ "selected" ].Value = false;
      fixedEntriesTable.Rows[ index ].Cells[ "fixedEntryDescription" ].Value = "";

      _infoCollection.RecurringEntriesInfo.Add( _infoCollection.CategoriesInfo.GetCategories().First().Key, 0.0, "" );
    }

    //-------------------------------------------------------------------------

    private void removeSelectedRow_Click( object sender, System.EventArgs e )
    {
      int selectedIndex = fixedEntriesTable.CurrentCell.RowIndex;
      fixedEntriesTable.Rows.RemoveAt( selectedIndex );
      _infoCollection.RecurringEntriesInfo.RemoveAt( selectedIndex );
    }

    //-------------------------------------------------------------------------
  }
}
