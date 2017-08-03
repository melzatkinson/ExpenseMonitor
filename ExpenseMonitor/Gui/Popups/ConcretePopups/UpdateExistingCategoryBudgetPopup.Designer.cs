namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  partial class UpdateExistingCategoryBudgetPopup
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.newBudgetInput = new System.Windows.Forms.TextBox();
      this.categoryInput = new System.Windows.Forms.ComboBox();
      this.Budget = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.popupGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // popupGroupBox
      // 
      this.popupGroupBox.Controls.Add(this.newBudgetInput);
      this.popupGroupBox.Controls.Add(this.categoryInput);
      this.popupGroupBox.Controls.Add(this.Budget);
      this.popupGroupBox.Controls.Add(this.label2);
      this.popupGroupBox.Size = new System.Drawing.Size(614, 93);
      this.popupGroupBox.Text = "Update Existing Category";
      this.popupGroupBox.Controls.SetChildIndex(this.label2, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.Budget, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.categoryInput, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.newBudgetInput, 0);
      // 
      // newBudgetInput
      // 
      this.newBudgetInput.Location = new System.Drawing.Point(95, 62);
      this.newBudgetInput.Name = "newBudgetInput";
      this.newBudgetInput.Size = new System.Drawing.Size(149, 20);
      this.newBudgetInput.TabIndex = 11;
      this.newBudgetInput.KeyDown += new System.Windows.Forms.KeyEventHandler( this.changeCategoryBudget_Submit );
      // 
      // categoryInput
      // 
      this.categoryInput.FormattingEnabled = true;
      this.categoryInput.Location = new System.Drawing.Point(95, 24);
      this.categoryInput.Name = "categoryInput";
      this.categoryInput.Size = new System.Drawing.Size(149, 21);
      this.categoryInput.TabIndex = 10;
      this.categoryInput.SelectedIndexChanged += new System.EventHandler(this.categoryInput_SelectedIndexChanged);
      // 
      // Budget
      // 
      this.Budget.AutoSize = true;
      this.Budget.Location = new System.Drawing.Point(6, 65);
      this.Budget.Name = "Budget";
      this.Budget.Size = new System.Drawing.Size(41, 13);
      this.Budget.TabIndex = 9;
      this.Budget.Text = "Budget";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 27);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(49, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Category";
      // 
      // UpdateExistingCategoryBudgetPopup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "UpdateExistingCategoryBudgetPopup";
      this.Size = new System.Drawing.Size(619, 98);
      this.popupGroupBox.ResumeLayout(false);
      this.popupGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox newBudgetInput;
    private System.Windows.Forms.ComboBox categoryInput;
    private System.Windows.Forms.Label Budget;
    private System.Windows.Forms.Label label2;
  }
}
