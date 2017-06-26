namespace ExpenseMonitor.Gui
{
  partial class ChangeCategoryBudgetForm
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
      this.categoryLabel = new System.Windows.Forms.Label();
      this.Budget = new System.Windows.Forms.Label();
      this.categoryInput = new System.Windows.Forms.ComboBox();
      this.newBudgetInput = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // categoryLabel
      // 
      this.categoryLabel.AutoSize = true;
      this.categoryLabel.Location = new System.Drawing.Point(12, 23);
      this.categoryLabel.Name = "categoryLabel";
      this.categoryLabel.Size = new System.Drawing.Size(49, 13);
      this.categoryLabel.TabIndex = 0;
      this.categoryLabel.Text = "Category";
      // 
      // Budget
      // 
      this.Budget.AutoSize = true;
      this.Budget.Location = new System.Drawing.Point(12, 61);
      this.Budget.Name = "Budget";
      this.Budget.Size = new System.Drawing.Size(41, 13);
      this.Budget.TabIndex = 1;
      this.Budget.Text = "Budget";
      // 
      // categoryInput
      // 
      this.categoryInput.FormattingEnabled = true;
      this.categoryInput.Location = new System.Drawing.Point(101, 20);
      this.categoryInput.Name = "categoryInput";
      this.categoryInput.Size = new System.Drawing.Size(149, 21);
      this.categoryInput.TabIndex = 2;
      this.categoryInput.SelectedIndexChanged += new System.EventHandler(this.categoryInput_SelectedIndexChanged);
      // 
      // newBudgetInput
      // 
      this.newBudgetInput.Location = new System.Drawing.Point(101, 58);
      this.newBudgetInput.Name = "newBudgetInput";
      this.newBudgetInput.Size = new System.Drawing.Size(149, 20);
      this.newBudgetInput.TabIndex = 3;
      this.newBudgetInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.changeCategoryBudget_Submit);
      // 
      // ChangeCategoryBudgetForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(299, 95);
      this.Controls.Add(this.newBudgetInput);
      this.Controls.Add(this.categoryInput);
      this.Controls.Add(this.Budget);
      this.Controls.Add(this.categoryLabel);
      this.Name = "ChangeCategoryBudgetForm";
      this.Text = "Change Budget";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label categoryLabel;
    private System.Windows.Forms.Label Budget;
    private System.Windows.Forms.ComboBox categoryInput;
    private System.Windows.Forms.TextBox newBudgetInput;
  }
}