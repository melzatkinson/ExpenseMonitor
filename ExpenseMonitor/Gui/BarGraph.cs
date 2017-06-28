using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseMonitor;
using ExpenseMonitor.AppManagement;

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

  private Point _startPoint;
  private double _barWidth;
  private int _maximumAmount = 10000;
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

    MainForm form = ( MainForm )sender;
    if( form == null )
      return;

    _startPoint = new Point( 700, 700 );
    _barWidth = GraphWidth / ( ( double )_appManager.CategoryManager.CategoryInfos.Count * 3 );
    _scale = (double) GraphHeight / _maximumAmount;

    DrawAxes();
    AddYAxisLabeling();

    foreach( var category in _appManager.CategoryManager.CategoryInfos )
    {
      AddXAxisLabeling( category.Key );

      DrawBars( category, form );
    }
  }

  //-------------------------------------------------------------------------

  private void DrawBars( KeyValuePair<string, double> category, MainForm form )
  {
    _startPoint.X += ( int )_barWidth;

    DrawActualBar( category, form.GetSelectedStartDate(), form.GetSelectedEndDate() );

    _startPoint.X += ( int )_barWidth;

    DrawBudgetBar( category.Value );

    _startPoint.X += ( int )_barWidth;
  }

  //-------------------------------------------------------------------------

  private void DrawActualBar( KeyValuePair<string, double> category, DateTime startDate, DateTime endDate )
  {
    int total = _appManager.ManualEntryManager.GetTotalAmountForCategory( category.Key, startDate, endDate );

    Size size = new Size( ( int )_barWidth, ( int )( total * _scale ) );
    int y = _startPoint.Y - ( int )( total * _scale );
    _paintEventArgs.Graphics.FillRectangle( total > category.Value ? _redBrush : _greenBrush, new Rectangle( new Point( _startPoint.X, y ), size ) );
  }

  //-------------------------------------------------------------------------

  private void DrawBudgetBar( double budget )
  {
    Size size = new Size( ( int )_barWidth, ( int )( budget * _scale ) );
    int x = _startPoint.X;
    int y = _startPoint.Y - ( int )( budget * _scale );
    _paintEventArgs.Graphics.FillRectangle( _purpleBrush, new Rectangle( new Point( x, y ), size ) );
  }

  //-------------------------------------------------------------------------

  private void AddXAxisLabeling( string categoryName )
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen, _startPoint, new Point( _startPoint.X, _startPoint.Y + 20 ) );
    StringFormat drawFormat = new StringFormat( StringFormatFlags.DirectionVertical );

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
    double delta = _scale * YaxisDelta;
    double currentYPosition = _startPoint.Y;
    int currentLabel = 0;

    while( currentLabel < _maximumAmount )
    {
      currentLabel += YaxisDelta;
      currentYPosition -= delta;
      _paintEventArgs.Graphics.DrawLine( _blackPen, new Point( _startPoint.X, ( int )currentYPosition ), new Point( _startPoint.X - 10, ( int )currentYPosition ) );

      StringFormat drawFormat = new StringFormat( StringFormatFlags.DirectionRightToLeft );

      _paintEventArgs.Graphics.DrawString( Convert.ToString( currentLabel ),
                                           new Font( "Arial", 8.0f, FontStyle.Regular ),
                                           _blackBrush,
                                           _startPoint.X - 10,
                                           ( int )currentYPosition - 5,
                                           drawFormat );
    }
  }

  //-------------------------------------------------------------------------

  private void DrawAxes()
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen, _startPoint, new Point( _startPoint.X + GraphWidth, _startPoint.Y ) );
    _paintEventArgs.Graphics.DrawLine( _blackPen, _startPoint, new Point( _startPoint.X, _startPoint.Y - GraphHeight ) );
  }

  //-------------------------------------------------------------------------
}