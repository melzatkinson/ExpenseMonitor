using System.Windows.Forms;
using ExpenseMonitor.AppManagement;

namespace ExpenseMonitor
{
  public partial class AddNewCategoryForm : Form
  {
    private readonly AppManager _appManager;

    //-------------------------------------------------------------------------

    public AddNewCategoryForm( AppManager appManager )
    {
      _appManager = appManager;

      InitializeComponent();
    }

    //-------------------------------------------------------------------------

    private void addNewCategory_Submit( object sender, KeyEventArgs e )
    {
      if( e.KeyCode != Keys.Enter )
        return;

      _appManager.CategoryManager.AddCategory( newCategoryInput.Text );
      newCategoryInput.Text = "";
    }

    //-------------------------------------------------------------------------
  }
}
