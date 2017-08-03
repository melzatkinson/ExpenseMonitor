namespace ExpenseMonitor.Gui.Popups.ConcretePopups
{
  partial class AddRecurringEntryPopup
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
      this.removeSelectedRow = new System.Windows.Forms.Button();
      this.addNewRecurringEntry = new System.Windows.Forms.Button();
      this.submit = new System.Windows.Forms.Button();
      this.fixedEntriesTable = new System.Windows.Forms.DataGridView();
      this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.fixedEntryCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.fixedEntryAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fixedEntryDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.popupGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fixedEntriesTable)).BeginInit();
      this.SuspendLayout();
      // 
      // popupGroupBox
      // 
      this.popupGroupBox.Controls.Add(this.removeSelectedRow);
      this.popupGroupBox.Controls.Add(this.addNewRecurringEntry);
      this.popupGroupBox.Controls.Add(this.submit);
      this.popupGroupBox.Controls.Add(this.fixedEntriesTable);
      this.popupGroupBox.Size = new System.Drawing.Size(614, 387);
      this.popupGroupBox.Text = "Add Recurring Entry";
      this.popupGroupBox.Controls.SetChildIndex(this.fixedEntriesTable, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.submit, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.addNewRecurringEntry, 0);
      this.popupGroupBox.Controls.SetChildIndex(this.removeSelectedRow, 0);
      // 
      // removeSelectedRow
      // 
      this.removeSelectedRow.Location = new System.Drawing.Point(168, 358);
      this.removeSelectedRow.Name = "removeSelectedRow";
      this.removeSelectedRow.Size = new System.Drawing.Size(113, 23);
      this.removeSelectedRow.TabIndex = 10;
      this.removeSelectedRow.Text = "Remove Selected";
      this.removeSelectedRow.UseVisualStyleBackColor = true;
      this.removeSelectedRow.Click += new System.EventHandler(this.removeSelectedRow_Click);
      // 
      // addNewRecurringEntry
      // 
      this.addNewRecurringEntry.Location = new System.Drawing.Point(87, 358);
      this.addNewRecurringEntry.Name = "addNewRecurringEntry";
      this.addNewRecurringEntry.Size = new System.Drawing.Size(75, 23);
      this.addNewRecurringEntry.TabIndex = 9;
      this.addNewRecurringEntry.Text = "Add New";
      this.addNewRecurringEntry.UseVisualStyleBackColor = true;
      this.addNewRecurringEntry.Click += new System.EventHandler(this.addNewRecurringEntry_Click);
      // 
      // submit
      // 
      this.submit.Location = new System.Drawing.Point(6, 358);
      this.submit.Name = "submit";
      this.submit.Size = new System.Drawing.Size(75, 23);
      this.submit.TabIndex = 8;
      this.submit.Text = "Submit";
      this.submit.UseVisualStyleBackColor = true;
      this.submit.Click += new System.EventHandler(this.submit_Click);
      // 
      // fixedEntriesTable
      // 
      this.fixedEntriesTable.AllowUserToAddRows = false;
      this.fixedEntriesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.fixedEntriesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.fixedEntriesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.fixedEntryCategory,
            this.fixedEntryAmount,
            this.fixedEntryDescription});
      this.fixedEntriesTable.Location = new System.Drawing.Point(6, 50);
      this.fixedEntriesTable.Name = "fixedEntriesTable";
      this.fixedEntriesTable.Size = new System.Drawing.Size(602, 302);
      this.fixedEntriesTable.TabIndex = 7;
      // 
      // selected
      // 
      this.selected.HeaderText = "";
      this.selected.Name = "selected";
      this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // fixedEntryCategory
      // 
      this.fixedEntryCategory.HeaderText = "Category";
      this.fixedEntryCategory.Name = "fixedEntryCategory";
      this.fixedEntryCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.fixedEntryCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // fixedEntryAmount
      // 
      this.fixedEntryAmount.HeaderText = "Amount";
      this.fixedEntryAmount.Name = "fixedEntryAmount";
      // 
      // fixedEntryDescription
      // 
      this.fixedEntryDescription.HeaderText = "Description";
      this.fixedEntryDescription.Name = "fixedEntryDescription";
      // 
      // AddRecurringEntryPopup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "AddRecurringEntryPopup";
      this.Size = new System.Drawing.Size(614, 390);
      this.popupGroupBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.fixedEntriesTable)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button removeSelectedRow;
    private System.Windows.Forms.Button addNewRecurringEntry;
    private System.Windows.Forms.Button submit;
    private System.Windows.Forms.DataGridView fixedEntriesTable;
    private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
    private System.Windows.Forms.DataGridViewComboBoxColumn fixedEntryCategory;
    private System.Windows.Forms.DataGridViewTextBoxColumn fixedEntryAmount;
    private System.Windows.Forms.DataGridViewTextBoxColumn fixedEntryDescription;
  }
}
