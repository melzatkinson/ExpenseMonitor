namespace ExpenseMonitor.Gui
{
  partial class AddFixedEntryForm
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
      this.fixedEntriesTable = new System.Windows.Forms.DataGridView();
      this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.fixedEntryCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.fixedEntryAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fixedEntryDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.submit = new System.Windows.Forms.Button();
      this.addNewRecurringEntry = new System.Windows.Forms.Button();
      this.removeSelectedRow = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.fixedEntriesTable)).BeginInit();
      this.SuspendLayout();
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
      this.fixedEntriesTable.Location = new System.Drawing.Point(12, 38);
      this.fixedEntriesTable.Name = "fixedEntriesTable";
      this.fixedEntriesTable.Size = new System.Drawing.Size(655, 393);
      this.fixedEntriesTable.TabIndex = 0;
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
      // submit
      // 
      this.submit.Location = new System.Drawing.Point(12, 437);
      this.submit.Name = "submit";
      this.submit.Size = new System.Drawing.Size(75, 23);
      this.submit.TabIndex = 1;
      this.submit.Text = "Submit";
      this.submit.UseVisualStyleBackColor = true;
      this.submit.Click += new System.EventHandler(this.submit_Click);
      // 
      // addNewRecurringEntry
      // 
      this.addNewRecurringEntry.Location = new System.Drawing.Point(94, 437);
      this.addNewRecurringEntry.Name = "addNewRecurringEntry";
      this.addNewRecurringEntry.Size = new System.Drawing.Size(75, 23);
      this.addNewRecurringEntry.TabIndex = 2;
      this.addNewRecurringEntry.Text = "Add New";
      this.addNewRecurringEntry.UseVisualStyleBackColor = true;
      this.addNewRecurringEntry.Click += new System.EventHandler(this.addNewRecurringEntry_Click);
      // 
      // removeSelectedRow
      // 
      this.removeSelectedRow.Location = new System.Drawing.Point(176, 437);
      this.removeSelectedRow.Name = "removeSelectedRow";
      this.removeSelectedRow.Size = new System.Drawing.Size(113, 23);
      this.removeSelectedRow.TabIndex = 3;
      this.removeSelectedRow.Text = "Remove Selected";
      this.removeSelectedRow.UseVisualStyleBackColor = true;
      this.removeSelectedRow.Click += new System.EventHandler(this.removeSelectedRow_Click);
      // 
      // AddFixedEntryForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(679, 472);
      this.Controls.Add(this.removeSelectedRow);
      this.Controls.Add(this.addNewRecurringEntry);
      this.Controls.Add(this.submit);
      this.Controls.Add(this.fixedEntriesTable);
      this.Name = "AddFixedEntryForm";
      this.Text = "Add Fixed Entry";
      ((System.ComponentModel.ISupportInitialize)(this.fixedEntriesTable)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView fixedEntriesTable;
    private System.Windows.Forms.Button submit;
    private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
    private System.Windows.Forms.DataGridViewComboBoxColumn fixedEntryCategory;
    private System.Windows.Forms.DataGridViewTextBoxColumn fixedEntryAmount;
    private System.Windows.Forms.DataGridViewTextBoxColumn fixedEntryDescription;
    private System.Windows.Forms.Button addNewRecurringEntry;
    private System.Windows.Forms.Button removeSelectedRow;
  }
}