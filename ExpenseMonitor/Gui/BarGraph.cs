using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseMonitor;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.EntryFiltering.Specifications;

public class BarGraph
{
  public int MaximumAmount
  {
    get { return _maximumAmount; }
    set { _maximumAmount = value; }
  }

  private readonly AppManager _appManager;

  private readonly Pen _blackPen = new Pen( Color.Black, 1 );
  private readonly SolidBrush _redBrush = new SolidBrush( Color.Red );
  private readonly SolidBrush _greenBrush = new SolidBrush( Color.Green );
  private readonly SolidBrush _purpleBrush = new SolidBrush( Color.Purple );
  private readonly SolidBrush _blackBrush = new SolidBrush( Color.Black );

  private PaintEventArgs _paintEventArgs;

  private const int GraphHeight = 650;
  private const int GraphWidth = 550;
  private const int YaxisDelta = 500;
  private const int SlotsPerCategory = 3;
  private const int MinimumYAxisValueMaximum = 5000;

  private Point _startPoint;
  private double _barWidth;
  private int _maximumAmount = MinimumYAxisValueMaximum;
  private readonly Dictionary<string, double> _categoryTotals = new Dictionary<string, double>();
  private double _scale;

  //-------------------------------------------------------------------------

  public BarGraph( AppManager appManager )
  {
    _appManager = appManager;
  }

  //-------------------------------------------------------------------------

  public void DrawGraph( object sender, System.Windows.Forms.PaintEventArgs e )
  {
    _paintEventArgs = e;

    var form = ( MainForm )sender;
    if( form == null )
      return;

    _startPoint = new Point( 700, 700 );

    GenerateTotalsPerCategory( form );

    _barWidth = GraphWidth / ( ( double )_appManager.CategoryManager.CategoryInfos.Count * SlotsPerCategory );
    _scale = ( double )GraphHeight / _maximumAmount;

    DrawAxes();
    AddYAxisLabeling();

    foreach( var category in _categoryTotals )
    {
      AddXAxisLabeling( category.Key );

      double categoryBudget;
      _appManager.CategoryManager.CategoryInfos.TryGetValue( category.Key, out categoryBudget );

      DrawBars( category.Value, categoryBudget );
    }
  }

  //-------------------------------------------------------------------------

  private void GenerateTotalsPerCategory( MainForm form )
  {
    _categoryTotals.Clear();
    _maximumAmount = MinimumYAxisValueMaximum;

    foreach( var entry in _appManager.CategoryManager.CategoryInfos )
    {
      var specifications = new List<ISpecification<ManualEntryManager.Entry>>()
      {
        new EntryDateSpecification(form.GetSelectedStartDate(), form.GetSelectedEndDate()),
        new EntryCategorySpecification(entry.Key)
      };

      var total = _appManager.ManualEntryManager.GetTotal( specifications );
      _categoryTotals.Add( entry.Key, total );

      if( total > _maximumAmount ) _maximumAmount = ( int )total;
    }
  }

  //-------------------------------------------------------------------------

  private void DrawBars( double categoryTotal, double categoryBudget )
  {
    _startPoint.X += ( int )_barWidth;

    DrawActualTotalBar( categoryTotal, categoryBudget );

    _startPoint.X += ( int )_barWidth;

    DrawBudgetBar( categoryBudget );

    _startPoint.X += ( int )_barWidth;
  }

  //-------------------------------------------------------------------------

  private void DrawActualTotalBar( double total, double categoryBudget )
  {
    var size = new Size( ( int )_barWidth, ( int )( total * _scale ) );
    var y = _startPoint.Y - ( int )( total * _scale );

    var brush = total > categoryBudget ? _redBrush : _greenBrush;
    _paintEventArgs.Graphics.FillRectangle( brush, new Rectangle( new Point( _startPoint.X, y ), size ) );
  }

  //-------------------------------------------------------------------------

  private void DrawBudgetBar( double categoryBudget )
  {
    var size = new Size( ( int )_barWidth, ( int )( categoryBudget * _scale ) );
    var x = _startPoint.X;
    var y = _startPoint.Y - ( int )( categoryBudget * _scale );
    _paintEventArgs.Graphics.FillRectangle( _purpleBrush, new Rectangle( new Point( x, y ), size ) );
  }

  //-------------------------------------------------------------------------

  private void AddXAxisLabeling( string categoryName )
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen, _startPoint, new Point( _startPoint.X, _startPoint.Y + 20 ) );
    var drawFormat = new StringFormat( StringFormatFlags.DirectionVertical );

    _paintEventArgs.Graphics.DrawString( categoryName,
                                         new Font( "Arial", 7.0f, FontStyle.Regular ),
                                         _blackBrush,
                                         _startPoint.X + ( int )_barWidth + 10,
                                         _startPoint.Y + 5,
                                         drawFormat );
  }

  //-------------------------------------------------------------------------

  private void AddYAxisLabeling()
  {
    var delta = _scale * YaxisDelta;
    double currentYPosition = _startPoint.Y;
    var currentLabel = 0;

    while( currentLabel < _maximumAmount )
    {
      currentLabel += YaxisDelta;
      currentYPosition -= delta;

      DrawYAxisLabelLine( currentYPosition );

      DrawYAxisLabel( currentLabel, currentYPosition );
    }
  }

  //-------------------------------------------------------------------------

  private void DrawYAxisLabelLine( double currentYPosition )
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen,
                                       new Point( _startPoint.X, ( int )currentYPosition ),
                                       new Point( _startPoint.X - 10, ( int )currentYPosition ) );
  }

  //-------------------------------------------------------------------------

  private void DrawYAxisLabel( int currentLabel, double currentYPosition )
  {
    var drawFormat = new StringFormat( StringFormatFlags.DirectionRightToLeft );

    _paintEventArgs.Graphics.DrawString( Convert.ToString( currentLabel ),
                                         new Font( "Arial", 8.0f, FontStyle.Regular ),
                                         _blackBrush,
                                         _startPoint.X - 10,
                                         ( int )currentYPosition - 5,
                                         drawFormat );
  }

  //-------------------------------------------------------------------------

  private void DrawAxes()
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen, _startPoint, new Point( _startPoint.X + GraphWidth, _startPoint.Y ) );
    _paintEventArgs.Graphics.DrawLine( _blackPen, _startPoint, new Point( _startPoint.X, _startPoint.Y - GraphHeight ) );
  }

  //-------------------------------------------------------------------------
}