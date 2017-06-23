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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.addNewCategoryButton = new System.Windows.Forms.Button();
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
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(101, 20);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(149, 20);
      this.textBox1.TabIndex = 1;
      // 
      // addNewCategoryButton
      // 
      this.addNewCategoryButton.Location = new System.Drawing.Point(12, 96);
      this.addNewCategoryButton.Name = "addNewCategoryButton";
      this.addNewCategoryButton.Size = new System.Drawing.Size(75, 23);
      this.addNewCategoryButton.TabIndex = 2;
      this.addNewCategoryButton.Text = "Add";
      this.addNewCategoryButton.UseVisualStyleBackColor = true;
      this.addNewCategoryButton.Click += new System.EventHandler(this.addNewCategoryButton_Click);
      // 
      // AddNewCategoryForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(299, 131);
      this.Controls.Add(this.addNewCategoryButton);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.newCategoryNameLabel);
      this.Name = "AddNewCategoryForm";
      this.Text = "Add New Category";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label newCategoryNameLabel;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button addNewCategoryButton;
  }
}