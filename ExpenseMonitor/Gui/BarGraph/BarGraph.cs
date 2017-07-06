using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;
using ExpenseMonitor.AppManagement.EntryFiltering.Specifications;
using ExpenseMonitor.AppManagement.ManualEntries;

namespace ExpenseMonitor.Gui.BarGraph
{
  public class BarGraph
  {
    private readonly IManualEntriesInfo _manualEntriesInfo;
    private readonly ICategoriesInfo _categoriesInfo;

    private PaintEventArgs _paintEventArgs;

    private const int GraphHeight = 650;
    private const int GraphWidth = 550;
    private const int SlotsPerCategory = 3;
    private const int MinimumYAxisValueMaximum = 5000;

    private int _maximumAmount = MinimumYAxisValueMaximum;
    private readonly Dictionary<string, double> _categoryTotals = new Dictionary<string, double>();

    private BarGraphInfo _barGraphInfo = new BarGraphInfo();

    private readonly Axes _axes = new Axes( GraphWidth, GraphHeight );
    private readonly Bars _bars;

    //-------------------------------------------------------------------------

    public BarGraph( IManualEntriesInfo manualEntriesInfo, ICategoriesInfo categoriesInfo )
    {
      _manualEntriesInfo = manualEntriesInfo;
      _categoriesInfo = categoriesInfo;
      _bars = new Bars( categoriesInfo );
    }

    //-------------------------------------------------------------------------

    public void DrawGraph( object sender, System.Windows.Forms.PaintEventArgs e )
    {
      _paintEventArgs = e;

      var form = ( MainForm )sender;
      if( form == null )
        return;

      GenerateTotalsPerCategory( form );
      GenerateBarGraphInfo( _paintEventArgs.Graphics );
      GenerateAxes( _barGraphInfo );
      GenerateBars( _barGraphInfo );
    }

    //-------------------------------------------------------------------------

    private double GetBarWidth()
    {
      return GraphWidth / ( ( double )_categoriesInfo.GetCategoryCount() * SlotsPerCategory );
    }

    //-------------------------------------------------------------------------

    private double GetScale()
    {
      return ( double )GraphHeight / _maximumAmount;
    }

    //-------------------------------------------------------------------------

    private void GenerateBarGraphInfo( Graphics graphics )
    {
      _barGraphInfo.Graphics = graphics;
      _barGraphInfo.StartPoint = new Point( 700, 700 );
      _barGraphInfo.Scale = GetScale();
      _barGraphInfo.BarWidth = GetBarWidth();
    }

    //-------------------------------------------------------------------------

    private void GenerateAxes( BarGraphInfo barGraphInfo )
    {
      _axes.Generate( barGraphInfo,
                      _maximumAmount,
                      _categoryTotals );
    }

    //-------------------------------------------------------------------------

    private void GenerateBars( BarGraphInfo barGraphInfo )
    {
      _bars.Generate( barGraphInfo, _categoryTotals );
    }

    //-------------------------------------------------------------------------

    private void GenerateTotalsPerCategory( MainForm form )
    {
      _categoryTotals.Clear();
      _maximumAmount = MinimumYAxisValueMaximum;

      foreach( var entry in _categoriesInfo.GetCategories() )
      {
        var specifications = new AndSpecification<Entry>( new EntryDateSpecification( form.GetSelectedStartDate(), form.GetSelectedEndDate() ),
                                                          new EntryCategorySpecification( entry.Key ) );

        var total = _manualEntriesInfo.GetTotal( specifications );
        _categoryTotals.Add( entry.Key, total );

        if( total > _maximumAmount ) _maximumAmount = ( int )total;
      }
    }

    //-------------------------------------------------------------------------
  }
}