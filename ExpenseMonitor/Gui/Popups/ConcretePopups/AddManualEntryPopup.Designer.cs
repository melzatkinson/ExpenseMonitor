namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  partial class AddManualEntryPopup
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
      this.AddNewEntry = new System.Windows.Forms.Button();
      this.descriptionInput = new System.Windows.Forms.TextBox();
      this.categoryLabel = new System.Windows.Forms.Label();
      this.description = new System.Windows.Forms.Label();
      this.existingCategories = new System.Windows.Forms.ComboBox();
      this.amountInput = new System.Windows.Forms.TextBox();
      this.amountLabel = new System.Windows.Forms.Label();
      this.popupGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // popupGroupBox
      // 
      this.popupGroupBox.Controls.Add(this.AddNewEntry);
      this.popupGroupBox.Controls.Add(this.descriptionInput);
      this.popupGroupBox.Controls.Add(this.categoryLabel);
      this.popupGroupBox.Controls.Add(this.description);
      this.popupGroupBox.Controls.Add(this.existingCategories);
      this.popupGroupBox.Controls.Add(this.amountInput);
      this.popupGroupBox.Controls.Add(this.amountLabel);
      this.popupGroupBox.Size = new System.Drawing.Size(614, 186);
      this.popupGroupBox.Text = "Add New Entry";
      this.popupGroupBox.Controls.SetChildIndex(this.amountLabel, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.amountInput, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.existingCategories, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.description, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.categoryLabel, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.descriptionInput, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.AddNewEntry, 0);
      // 
      // AddNewEntry
      // 
      this.AddNewEntry.Location = new System.Drawing.Point(20, 150);
      this.AddNewEntry.Name = "AddNewEntry";
      this.AddNewEntry.Size = new System.Drawing.Size(75, 23);
      this.AddNewEntry.TabIndex = 30;
      this.AddNewEntry.Text = "Add";
      this.AddNewEntry.UseVisualStyleBackColor = true;
      this.AddNewEntry.Click += new System.EventHandler(this.AddNewEntry_Click );
      // 
      // descriptionInput
      // 
      this.descriptionInput.Location = new System.Drawing.Point(100, 107);
      this.descriptionInput.Name = "descriptionInput";
      this.descriptionInput.Size = new System.Drawing.Size(187, 20);
      this.descriptionInput.TabIndex = 29;
      // 
      // categoryLabel
      // 
      this.categoryLabel.AutoSize = true;
      this.categoryLabel.Location = new System.Drawing.Point(20, 30);
      this.categoryLabel.Name = "categoryLabel";
      this.categoryLabel.Size = new System.Drawing.Size(49, 13);
      this.categoryLabel.TabIndex = 25;
      this.categoryLabel.Text = "Category";
      // 
      // description
      // 
      this.description.AutoSize = true;
      this.description.Location = new System.Drawing.Point(20, 110);
      this.description.Name = "description";
      this.description.Size = new System.Drawing.Size(60, 13);
      this.description.TabIndex = 28;
      this.description.Text = "Description";
      // 
      // existingCategories
      // 
      this.existingCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.existingCategories.FormattingEnabled = true;
      this.existingCategories.Location = new System.Drawing.Point(100, 27);
      this.existingCategories.Name = "existingCategories";
      this.existingCategories.Size = new System.Drawing.Size(187, 21);
      this.existingCategories.TabIndex = 24;
      // 
      // amountInput
      // 
      this.amountInput.Location = new System.Drawing.Point(100, 67);
      this.amountInput.Name = "amountInput";
      this.amountInput.Size = new System.Drawing.Size(187, 20);
      this.amountInput.TabIndex = 27;
      // 
      // amountLabel
      // 
      this.amountLabel.AutoSize = true;
      this.amountLabel.Location = new System.Drawing.Point(20, 70);
      this.amountLabel.Name = "amountLabel";
      this.amountLabel.Size = new System.Drawing.Size(43, 13);
      this.amountLabel.TabIndex = 26;
      this.amountLabel.Text = "Amount";
      // 
      // AddManualEntryPopup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "AddManualEntryPopup";
      this.Size = new System.Drawing.Size(624, 190);
      this.popupGroupBox.ResumeLayout(false);
      this.popupGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button AddNewEntry;
    private System.Windows.Forms.TextBox descriptionInput;
    private System.Windows.Forms.Label categoryLabel;
    private System.Windows.Forms.Label description;
    private System.Windows.Forms.ComboBox existingCategories;
    private System.Windows.Forms.TextBox amountInput;
    private System.Windows.Forms.Label amountLabel;
  }
}
