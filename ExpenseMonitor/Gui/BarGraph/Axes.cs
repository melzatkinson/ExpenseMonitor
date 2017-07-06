using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExpenseMonitor.Gui.BarGraph
{
  public class Axes
  {
    private readonly Pen _blackPen = new Pen( Color.Black, 1 );
    private readonly SolidBrush _blackBrush = new SolidBrush( Color.Black );

    private static int _graphWidth;
    private static int _graphHeight;

    private Graphics _graphics;
    private double _scale;
    private int _maximumAmount;

    private const int YaxisDelta = 500;

    //-------------------------------------------------------------------------

    public Axes( int graphWidth, int graphHeight )
    {
      _graphWidth = graphWidth;
      _graphHeight = graphHeight;
    }

    //-------------------------------------------------------------------------

    public void Generate( BarGraphInfo barGraphInfo,
                          int maximumAmount,
                          Dictionary<string, double> categoryTotals )
    {
      _graphics = barGraphInfo.Graphics;
      _scale = barGraphInfo.Scale;
      _maximumAmount = maximumAmount;

      DrawAxes( barGraphInfo.StartPoint );
      AddAllYAxisLabels( barGraphInfo.StartPoint );
      AddAllXAxisLabels( barGraphInfo.StartPoint, barGraphInfo.BarWidth, categoryTotals );
    }

    //-------------------------------------------------------------------------

    private void DrawAxes( Point startPoint )
    {
      _graphics.DrawLine( _blackPen, startPoint, new Point( startPoint.X + _graphWidth, startPoint.Y ) );
      _graphics.DrawLine( _blackPen, startPoint, new Point( startPoint.X, startPoint.Y - _graphHeight ) );
    }

    //-------------------------------------------------------------------------

    private void AddAllYAxisLabels( Point startPoint )
    {
      var delta = _scale * YaxisDelta;
      double currentYPosition = startPoint.Y;
      var currentYLabelValue = 0;

      while( currentYLabelValue < _maximumAmount )
      {
        currentYLabelValue += YaxisDelta;
        currentYPosition -= delta;

        DrawLabelLine( GetPosition( startPoint.X, ( int )currentYPosition ),
                       GetPosition( startPoint.X, ( int )currentYPosition, -10 ) );

        DrawLabel( Convert.ToString( currentYLabelValue ),
                   GetPosition( startPoint.X, ( int )currentYPosition, -10, -5 ),
                   new StringFormat( StringFormatFlags.DirectionRightToLeft ) );
      }
    }

    //-------------------------------------------------------------------------

    private void AddAllXAxisLabels( Point startPoint, double barWidth, Dictionary<string, double> categoryTotals )
    {
      foreach( var category in categoryTotals )
      {
        DrawLabel( category.Key,
                   GetPosition( startPoint.X, startPoint.Y, ( int )barWidth + 10, 5 ),
                   new StringFormat( StringFormatFlags.DirectionVertical ) );

        DrawLabelLine( startPoint,
                       GetPosition( startPoint.X, startPoint.Y, 0, 20 ) );

        startPoint.X += ( int )barWidth * 3;
      }
    }

    //-------------------------------------------------------------------------

    private Point GetPosition( int originalX, int originalY, int xOffset = 0, int yOffset = 0 )
    {
      return new Point( originalX + xOffset, originalY + yOffset );
    }

    //-------------------------------------------------------------------------

    private void DrawLabelLine( Point startPoint, Point endPoint )
    {
      _graphics.DrawLine( _blackPen,
                          startPoint,
                          endPoint );
    }

    //-------------------------------------------------------------------------

    private void DrawLabel( string labelName, Point point, StringFormat drawFormat )
    {
      _graphics.DrawString( labelName,
                            new Font( "Arial", 7.0f, FontStyle.Regular ),
                            _blackBrush,
                            point.X,
                            point.Y,
                            drawFormat );
    }

    //-------------------------------------------------------------------------
  }
}