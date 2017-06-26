using System;
using System.Collections.Generic;
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


    private readonly AppManager _appManager;

    private readonly Pen _blackPen = new Pen( Color.Black, 1 );
    private readonly SolidBrush _redBrush = new SolidBrush( Color.Red );
    private readonly SolidBrush _greenBrush = new SolidBrush( Color.Green );
    private readonly SolidBrush _purpleBrush = new SolidBrush( Color.Purple );
    private readonly SolidBrush _blackBrush = new SolidBrush( Color.Black );


    //-------------------------------------------------------------------------

    public MainForm( AppManager appManager )
    {
      _appManager = appManager;
      _addNewCategoryForm = new AddNewCategoryForm( _appManager );
      _changeCategoryBudgetForm = new ChangeCategoryBudgetForm( _appManager );
      _addFixedEntryForm = new AddFixedEntryForm( _appManager );

      _appManager.CategoryManager.CategoriesChanged += OnCategoriesChanged;
      _appManager.ManualEntryManager.ManualEntriesChanged += OnManualEntriesChanged;
      Paint += DrawGraph;

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

      Invalidate();
    }

    //-------------------------------------------------------------------------

    private void startDatePicker_ValueChanged( object sender, EventArgs e )
    {
      RefreshRecords();
      Invalidate();
    }

    //-------------------------------------------------------------------------

    private void endDatePicker_ValueChanged( object sender, EventArgs e )
    {
      RefreshRecords();
      Invalidate();
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

    public void DrawGraph( object sender, System.Windows.Forms.PaintEventArgs e )
    {
      double scale = 0.05;

      Point startPoint = new Point( 700, 550 );

      DrawAxes( e, _blackPen, startPoint );

      double barWidth = 400 / ( ( double )_appManager.CategoryManager.CategoryInfos.Count * 3 );

      foreach( var category in _appManager.CategoryManager.CategoryInfos )
      {
        startPoint.X += ( int )barWidth;

        DrawActualBar( e, category, barWidth, scale, startPoint );

        startPoint.X += ( int )barWidth;

        AddBudgetBar( e, barWidth, category.Value, scale, startPoint );

        startPoint.X += ( int )barWidth;

        AddXAxisLabeling( e, startPoint, category.Key, (int)barWidth );
      }
    }

    //-------------------------------------------------------------------------

    private void DrawActualBar( PaintEventArgs e, KeyValuePair<string, double> category, double barWidth, double scale, Point startPoint )
    {
      int total = _appManager.ManualEntryManager.GetTotalAmountForCategory( category.Key, startDatePicker.Value.Date, endDatePicker.Value.Date );

      Size size = new Size( ( int )barWidth, ( int )( total * scale ) );
      int y = startPoint.Y - ( int )( total * scale );
      e.Graphics.FillRectangle( total > category.Value ? _redBrush : _greenBrush, new Rectangle( new Point( startPoint.X, y ), size ) );
    }

    //-------------------------------------------------------------------------

    private void AddBudgetBar( PaintEventArgs e, double barWidth, double budget, double scale, Point startPoint )
    {
      Size size = new Size( ( int )barWidth, ( int )( budget * scale ) );
      int x = startPoint.X;
      int y = startPoint.Y - ( int )( budget * scale );
      e.Graphics.FillRectangle( _purpleBrush, new Rectangle( new Point( x, y ), size ) );
    }

    //-------------------------------------------------------------------------

    private void AddXAxisLabeling(PaintEventArgs e, Point startPoint, string categoryName, int barWidth)
    {
      e.Graphics.DrawLine( _blackPen, startPoint, new Point( startPoint.X, startPoint.Y + 20 ) );
      StringFormat drawFormat = new StringFormat( StringFormatFlags.DirectionVertical );

      e.Graphics.DrawString( categoryName,
        new Font( "Arial", 8.0f, FontStyle.Regular ),
        _blackBrush,
        startPoint.X - ( barWidth * 2),
        ( startPoint.Y + 5 ),
        drawFormat );
    }

    //-------------------------------------------------------------------------

    private static void DrawAxes( PaintEventArgs e, Pen blackPen, Point startPoint )
    {
      e.Graphics.DrawLine( blackPen, startPoint, new Point( 1100, 550 ) );
      e.Graphics.DrawLine( blackPen, startPoint, new Point( 700, 50 ) );
    }

    //-------------------------------------------------------------------------
  }
}
