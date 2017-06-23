namespace ExpenseMonitor
{
  partial class MainForm
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.addNewCategory = new System.Windows.Forms.Label();
      this.descriptionInput = new System.Windows.Forms.TextBox();
      this.description = new System.Windows.Forms.Label();
      this.amountInput = new System.Windows.Forms.TextBox();
      this.amountLabel = new System.Windows.Forms.Label();
      this.categoryLabel = new System.Windows.Forms.Label();
      this.existingCategories = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.addNewCategory);
      this.groupBox1.Controls.Add(this.descriptionInput);
      this.groupBox1.Controls.Add(this.description);
      this.groupBox1.Controls.Add(this.amountInput);
      this.groupBox1.Controls.Add(this.amountLabel);
      this.groupBox1.Controls.Add(this.categoryLabel);
      this.groupBox1.Controls.Add(this.existingCategories);
      this.groupBox1.Location = new System.Drawing.Point(25, 28);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(618, 139);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Add";
      // 
      // addNewCategory
      // 
      this.addNewCategory.AutoSize = true;
      this.addNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.addNewCategory.ForeColor = System.Drawing.SystemColors.MenuHighlight;
      this.addNewCategory.Location = new System.Drawing.Point(282, 32);
      this.addNewCategory.Name = "addNewCategory";
      this.addNewCategory.Size = new System.Drawing.Size(58, 13);
      this.addNewCategory.TabIndex = 6;
      this.addNewCategory.Text = "Add new...";
      this.addNewCategory.Click += new System.EventHandler(this.addNewCategory_Click);
      // 
      // descriptionInput
      // 
      this.descriptionInput.Location = new System.Drawing.Point(89, 97);
      this.descriptionInput.Name = "descriptionInput";
      this.descriptionInput.Size = new System.Drawing.Size(187, 20);
      this.descriptionInput.TabIndex = 5;
      // 
      // description
      // 
      this.description.AutoSize = true;
      this.description.Location = new System.Drawing.Point(16, 100);
      this.description.Name = "description";
      this.description.Size = new System.Drawing.Size(60, 13);
      this.description.TabIndex = 4;
      this.description.Text = "Description";
      // 
      // amountInput
      // 
      this.amountInput.Location = new System.Drawing.Point(89, 59);
      this.amountInput.Name = "amountInput";
      this.amountInput.Size = new System.Drawing.Size(187, 20);
      this.amountInput.TabIndex = 3;
      // 
      // amountLabel
      // 
      this.amountLabel.AutoSize = true;
      this.amountLabel.Location = new System.Drawing.Point(16, 59);
      this.amountLabel.Name = "amountLabel";
      this.amountLabel.Size = new System.Drawing.Size(43, 13);
      this.amountLabel.TabIndex = 2;
      this.amountLabel.Text = "Amount";
      // 
      // categoryLabel
      // 
      this.categoryLabel.AutoSize = true;
      this.categoryLabel.Location = new System.Drawing.Point(16, 27);
      this.categoryLabel.Name = "categoryLabel";
      this.categoryLabel.Size = new System.Drawing.Size(49, 13);
      this.categoryLabel.TabIndex = 1;
      this.categoryLabel.Text = "Category";
      // 
      // existingCategories
      // 
      this.existingCategories.FormattingEnabled = true;
      this.existingCategories.Location = new System.Drawing.Point(89, 24);
      this.existingCategories.Name = "existingCategories";
      this.existingCategories.Size = new System.Drawing.Size(187, 21);
      this.existingCategories.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(679, 641);
      this.Controls.Add(this.groupBox1);
      this.Name = "MainForm";
      this.Text = "Expense Monitor";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label addNewCategory;
    private System.Windows.Forms.TextBox descriptionInput;
    private System.Windows.Forms.Label description;
    private System.Windows.Forms.TextBox amountInput;
    private System.Windows.Forms.Label amountLabel;
    private System.Windows.Forms.Label categoryLabel;
    private System.Windows.Forms.ComboBox existingCategories;
  }
}

