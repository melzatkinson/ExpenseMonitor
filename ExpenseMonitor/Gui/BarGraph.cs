using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseMonitor;
using ExpenseMonitor.AppManagement;

public class BarGraph
{
  private readonly AppManager _appManager;

  private readonly Pen _blackPen = new Pen( Color.Black, 1 );
  private readonly SolidBrush _redBrush = new SolidBrush( Color.Red );
  private readonly SolidBrush _greenBrush = new SolidBrush( Color.Green );
  private readonly SolidBrush _purpleBrush = new SolidBrush( Color.Purple );
  private readonly SolidBrush _blackBrush = new SolidBrush( Color.Black );

  private PaintEventArgs _paintEventArgs;

  private const int GraphHeight = 500;
  private const int MaximumAmount = 10000;

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

    double scale = 0.05;

    Point startPoint = new Point( 700, 550 );

    DrawAxes( startPoint );
    AddYAxisLabeling( startPoint );

    double barWidth = 400 / ( ( double )_appManager.CategoryManager.CategoryInfos.Count * 3 );

    foreach( var category in _appManager.CategoryManager.CategoryInfos )
    {
      startPoint.X += ( int )barWidth;

      DrawActualBar( category, barWidth, scale, startPoint, form.GetSelectedStartDate(), form.GetSelectedEndDate() );

      startPoint.X += ( int )barWidth;

      AddBudgetBar( barWidth, category.Value, scale, startPoint );

      startPoint.X += ( int )barWidth;

      AddXAxisLabeling( startPoint, category.Key, ( int )barWidth );
    }
  }

  //-------------------------------------------------------------------------

  private void DrawActualBar( KeyValuePair<string, double> category,
                              double barWidth,
                              double scale,
                              Point startPoint,
                              DateTime startDate,
                              DateTime endDate )
  {
    int total = _appManager.ManualEntryManager.GetTotalAmountForCategory( category.Key, startDate, endDate );

    Size size = new Size( ( int )barWidth, ( int )( total * scale ) );
    int y = startPoint.Y - ( int )( total * scale );
    _paintEventArgs.Graphics.FillRectangle( total > category.Value ? _redBrush : _greenBrush, new Rectangle( new Point( startPoint.X, y ), size ) );
  }

  //-------------------------------------------------------------------------

  private void AddBudgetBar( double barWidth, double budget, double scale, Point startPoint )
  {
    Size size = new Size( ( int )barWidth, ( int )( budget * scale ) );
    int x = startPoint.X;
    int y = startPoint.Y - ( int )( budget * scale );
    _paintEventArgs.Graphics.FillRectangle( _purpleBrush, new Rectangle( new Point( x, y ), size ) );
  }

  //-------------------------------------------------------------------------

  private void AddXAxisLabeling( Point startPoint, string categoryName, int barWidth )
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen, startPoint, new Point( startPoint.X, startPoint.Y + 20 ) );
    StringFormat drawFormat = new StringFormat( StringFormatFlags.DirectionVertical );

    _paintEventArgs.Graphics.DrawString( categoryName,
      new Font( "Arial", 8.0f, FontStyle.Regular ),
      _blackBrush,
      startPoint.X - ( barWidth * 2 ),
      ( startPoint.Y + 5 ),
      drawFormat );
  }

  //-------------------------------------------------------------------------

  private void AddYAxisLabeling( Point startPoint )
  {
    double x = ( double )GraphHeight / MaximumAmount;
    int delta = ( int )( x * 500 );
    int currentYPosition = startPoint.Y;
    int currentLabel = 0;

    while( currentYPosition > ( startPoint.Y - GraphHeight ) )
    {
      currentLabel += 500;
      currentYPosition -= delta;
      _paintEventArgs.Graphics.DrawLine( _blackPen, new Point( startPoint.X, currentYPosition ), new Point( startPoint.X - 10, currentYPosition ) );

      StringFormat drawFormat = new StringFormat( StringFormatFlags.DirectionRightToLeft );

      _paintEventArgs.Graphics.DrawString( Convert.ToString( currentLabel ),
                                            new Font( "Arial", 8.0f, FontStyle.Regular ),
                                            _blackBrush,
                                            startPoint.X - 10,
                                            currentYPosition - 5,
                                            drawFormat );
    }
  }

  //-------------------------------------------------------------------------

  private void DrawAxes( Point startPoint )
  {
    _paintEventArgs.Graphics.DrawLine( _blackPen, startPoint, new Point( 1100, 550 ) );
    _paintEventArgs.Graphics.DrawLine( _blackPen, startPoint, new Point( 700, 50 ) );
  }

  //-------------------------------------------------------------------------
}