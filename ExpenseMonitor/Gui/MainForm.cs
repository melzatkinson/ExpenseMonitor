using System;
using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor
{
  public partial class MainForm : Form
  {
    private readonly AddNewCategoryForm _addNewCategoryForm;

    private readonly AppManager _appManager;

    //-------------------------------------------------------------------------

    public MainForm( AppManager appManager )
    {
      _appManager = appManager;
      _addNewCategoryForm = new AddNewCategoryForm( _appManager );
      _appManager.CategoryManager.CategoriesChanged += OnCategoriesChanged;

      InitializeComponent();

      RefreshCategoriesComboBox( _appManager.CategoryManager );
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

    public void OnCategoriesChanged( object source, EventArgs e )
    {
      CategoryManager categoryManager = ( CategoryManager )source;
      if( categoryManager == null )
        return;

      RefreshCategoriesComboBox( categoryManager );

      _addNewCategoryForm.Close();
    }

    //-------------------------------------------------------------------------

    private void RefreshCategoriesComboBox( CategoryManager categoryManager )
    {
      existingCategories.Items.Clear();

      foreach( string category in categoryManager.Categories )
      {
        existingCategories.Items.Add( category );
      }

      existingCategories.SelectedIndex = 0;
    }

    //-------------------------------------------------------------------------

    private void RefreshRecords( )
    {
      recordsTable.Rows.Clear();

      foreach( var entry in _appManager.EntryManager.Entries )
      {
        if (DateTime.Compare(startDatePicker.Value.Date, entry.Date) <= 0 &&
            DateTime.Compare(endDatePicker.Value.Date, entry.Date) >= 0)
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
      _appManager.EntryManager.Add(
        DateTime.Now.Date,
        existingCategories.SelectedItem.ToString(),
        double.Parse( amountInput.Text, CultureInfo.InvariantCulture ),
        descriptionInput.Text );

      RefreshRecords();

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
  }
}
