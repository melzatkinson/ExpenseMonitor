using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpenseMonitor
{
  public class CategoryManager
  {
    private List< string> categories = new List<string>();

    public void ReadFromXml(string filename)
    {
      // TODO
    }

    public void AddNewCategory(string categoryName)
    {
      if (categories.Contains(categoryName))
      {
        MessageBox.Show("You're trying to add a category that already exists.");
      }
      else
      {
        categories.Add(categoryName);
      }
    }

    public void WriteToXml(string filename)
    {
      // TODO
    }
  }
}