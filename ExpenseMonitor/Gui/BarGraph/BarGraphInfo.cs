using System.Drawing;

namespace ExpenseMonitor.Gui.BarGraph
{
  public struct BarGraphInfo
  {
    public Graphics Graphics;
    public Point StartPoint;
    public double BarWidth;
    public double Scale;
  }
}