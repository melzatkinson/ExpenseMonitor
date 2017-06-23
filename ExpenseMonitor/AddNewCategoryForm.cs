using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseMonitor
{
  public partial class AddNewCategoryForm : Form
  {
    public AddNewCategoryForm()
    {
      InitializeComponent();
    }

    private void addNewCategoryButton_Click( object sender, EventArgs e )
    {
      this.Close();
    }
  }
}
