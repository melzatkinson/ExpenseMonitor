using System.Collections.Generic;
using System.Drawing;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor.Gui.BarGraph
{
  public class Bars
  {
    private readonly SolidBrush _redBrush = new SolidBrush( Color.Red );
    private readonly SolidBrush _greenBrush = new SolidBrush( Color.Green );
    private readonly SolidBrush _purpleBrush = new SolidBrush( Color.Purple );

    private readonly ICategoriesInfo _categoriesInfo;

    private Point _startPoint;
    private Graphics _graphics;
    private double _barWidth;
    private double _scale;

    //-------------------------------------------------------------------------

    public Bars( ICategoriesInfo categoriesInfo )
    {
      _categoriesInfo = categoriesInfo;
    }

    //-------------------------------------------------------------------------

    public void Generate( BarGraphInfo barGraphInfo,
                          Dictionary<string, double> categoryTotals )
    {
      _graphics = barGraphInfo.Graphics;
      _startPoint = barGraphInfo.StartPoint;
      _barWidth = barGraphInfo.BarWidth;
      _scale = barGraphInfo.Scale;

      foreach( var category in categoryTotals )
      {
        DrawBars( category.Value, _categoriesInfo.GetBudgetForCategory( category.Key ) );
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
      var brush = total > categoryBudget ? _redBrush : _greenBrush;

      DrawBar( brush,
               GetPosition( _startPoint, 0, -( int )( total * _scale ) ),
               ( int )_barWidth,
               ( int )( total * _scale ) );
    }

    //-------------------------------------------------------------------------

    private void DrawBudgetBar( double categoryBudget )
    {
      DrawBar( _purpleBrush,
               GetPosition( _startPoint, 0, -( int )( categoryBudget * _scale ) ),
              ( int )_barWidth,
              ( int )( categoryBudget * _scale ) );
    }

    //-------------------------------------------------------------------------

    private static Point GetPosition( Point point, int xOffset = 0, int yOffset = 0 )
    {
      return new Point( point.X + xOffset, point.Y + yOffset );
    }

    //-------------------------------------------------------------------------

    private void DrawBar( Brush brush, Point point, int width, int height )
    {
      _graphics.FillRectangle( brush,
                               new Rectangle( point, new Size( width, height ) ) );
    }

    //-------------------------------------------------------------------------
  }
}