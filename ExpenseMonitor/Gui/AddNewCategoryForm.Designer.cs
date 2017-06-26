using System.Windows.Forms;

namespace ExpenseMonitor
{
  partial class AddNewCategoryForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.newCategoryNameLabel = new System.Windows.Forms.Label();
      this.newCategoryInput = new System.Windows.Forms.TextBox();
      this.budgetLabel = new System.Windows.Forms.Label();
      this.budgetInput = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // newCategoryNameLabel
      // 
      this.newCategoryNameLabel.AutoSize = true;
      this.newCategoryNameLabel.Location = new System.Drawing.Point(12, 23);
      this.newCategoryNameLabel.Name = "newCategoryNameLabel";
      this.newCategoryNameLabel.Size = new System.Drawing.Size(74, 13);
      this.newCategoryNameLabel.TabIndex = 0;
      this.newCategoryNameLabel.Text = "New Category";
      // 
      // newCategoryInput
      // 
      this.newCategoryInput.Location = new System.Drawing.Point(101, 20);
      this.newCategoryInput.Name = "newCategoryInput";
      this.newCategoryInput.Size = new System.Drawing.Size(149, 20);
      this.newCategoryInput.TabIndex = 1;
      this.newCategoryInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addNewCategory_Submit);
      // 
      // budgetLabel
      // 
      this.budgetLabel.AutoSize = true;
      this.budgetLabel.Location = new System.Drawing.Point(12, 61);
      this.budgetLabel.Name = "budgetLabel";
      this.budgetLabel.Size = new System.Drawing.Size(41, 13);
      this.budgetLabel.TabIndex = 2;
      this.budgetLabel.Text = "Budget";
      // 
      // budgetInput
      // 
      this.budgetInput.Location = new System.Drawing.Point(101, 58);
      this.budgetInput.Name = "budgetInput";
      this.budgetInput.Size = new System.Drawing.Size(149, 20);
      this.budgetInput.TabIndex = 3;
      this.budgetInput.Text = "0.0";
      // 
      // AddNewCategoryForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(299, 95);
      this.Controls.Add(this.budgetInput);
      this.Controls.Add(this.budgetLabel);
      this.Controls.Add(this.newCategoryInput);
      this.Controls.Add(this.newCategoryNameLabel);
      this.Name = "AddNewCategoryForm";
      this.Text = "Add New Category";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label newCategoryNameLabel;
    private System.Windows.Forms.TextBox newCategoryInput;
    private Label budgetLabel;
    private TextBox budgetInput;
  }
}