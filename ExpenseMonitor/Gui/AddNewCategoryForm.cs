using System.Globalization;
using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor
{
  public partial class AddNewCategoryForm : Form
  {
    private readonly ICategoriesInfo _categoriesInfo;

    //-------------------------------------------------------------------------

    public AddNewCategoryForm( ICategoriesInfo categoriesInfo )
    {
      _categoriesInfo = categoriesInfo;

      InitializeComponent();
    }

    //-------------------------------------------------------------------------

    private void addNewCategory_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      if( !_categoriesInfo.AddCategory( newCategoryInput.Text, double.Parse( budgetInput.Text, CultureInfo.InvariantCulture ) ) )
      {
        MessageBox.Show( "Invalid! Empty or duplicate." );
      }

      newCategoryInput.Text = "";
      budgetInput.Text = "0.0";
    }

    //-------------------------------------------------------------------------
  }
}
