namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  partial class AddNewCategoryPopup
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
      this.budgetInput = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.newCategoryInput = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.popupGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // popupGroupBox
      // 
      this.popupGroupBox.Controls.Add(this.budgetInput);
      this.popupGroupBox.Controls.Add(this.label2);
      this.popupGroupBox.Controls.Add(this.newCategoryInput);
      this.popupGroupBox.Controls.Add(this.label3);
      this.popupGroupBox.Location = new System.Drawing.Point(0, 0);
      this.popupGroupBox.Size = new System.Drawing.Size(614, 116);
      this.popupGroupBox.Text = "Add New Category";
      // 
      // budgetInput
      // 
      this.budgetInput.Location = new System.Drawing.Point(95, 60);
      this.budgetInput.Name = "budgetInput";
      this.budgetInput.Size = new System.Drawing.Size(149, 20);
      this.budgetInput.TabIndex = 19;
      this.budgetInput.Text = "0.0";
      this.budgetInput.KeyDown += new System.Windows.Forms.KeyEventHandler( this.addNewCategory_Submit );
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 63);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 13);
      this.label2.TabIndex = 18;
      this.label2.Text = "Budget";
      // 
      // newCategoryInput
      // 
      this.newCategoryInput.Location = new System.Drawing.Point(95, 22);
      this.newCategoryInput.Name = "newCategoryInput";
      this.newCategoryInput.Size = new System.Drawing.Size(149, 20);
      this.newCategoryInput.TabIndex = 17;
      this.budgetInput.KeyDown += new System.Windows.Forms.KeyEventHandler( this.addNewCategory_Submit );
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 25);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(74, 13);
      this.label3.TabIndex = 16;
      this.label3.Text = "New Category";
      // 
      // AddNewCategoryPopup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "AddNewCategoryPopup";
      this.Size = new System.Drawing.Size(621, 119);
      this.popupGroupBox.ResumeLayout(false);
      this.popupGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox budgetInput;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox newCategoryInput;
    private System.Windows.Forms.Label label3;
  }
}
