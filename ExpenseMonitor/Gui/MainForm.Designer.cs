using System.Windows.Forms;

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
      this.manualEntryGroup = new System.Windows.Forms.GroupBox();
      this.AddNewEntry = new System.Windows.Forms.Button();
      this.descriptionInput = new System.Windows.Forms.TextBox();
      this.description = new System.Windows.Forms.Label();
      this.amountInput = new System.Windows.Forms.TextBox();
      this.amountLabel = new System.Windows.Forms.Label();
      this.categoryLabel = new System.Windows.Forms.Label();
      this.existingCategories = new System.Windows.Forms.ComboBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.endDatePicker = new System.Windows.Forms.DateTimePicker();
      this.endDateLabel = new System.Windows.Forms.Label();
      this.startDateLabel = new System.Windows.Forms.Label();
      this.startDatePicker = new System.Windows.Forms.DateTimePicker();
      this.recordsTable = new System.Windows.Forms.DataGridView();
      this.EntryCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EntryAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EntryDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fixedEntryGroup = new System.Windows.Forms.GroupBox();
      this.addFixedEntryButton = new System.Windows.Forms.Button();
      this.removeSelectedEntry = new System.Windows.Forms.Button();
      this.profilingGroup = new System.Windows.Forms.GroupBox();
      this.budgetLabel = new System.Windows.Forms.Label();
      this.budgetTotalOutput = new System.Windows.Forms.TextBox();
      this.totalsTable = new System.Windows.Forms.DataGridView();
      this.totalsCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalsOutput = new System.Windows.Forms.TextBox();
      this.totalLabel = new System.Windows.Forms.Label();
      this.categoryManagerGroup = new System.Windows.Forms.GroupBox();
      this.updateExistingCategoryBudget = new System.Windows.Forms.Button();
      this.addNewCategory = new System.Windows.Forms.Button();
      this.maximumGraphYValueLabel = new System.Windows.Forms.Label();
      this.maximumGraphYValueInput = new System.Windows.Forms.TextBox();
      this.monthSelectedToProfileLabel = new System.Windows.Forms.Label();
      this.monthSelectedOutput = new System.Windows.Forms.TextBox();
      this.manualEntryGroup.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.recordsTable)).BeginInit();
      this.fixedEntryGroup.SuspendLayout();
      this.profilingGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.totalsTable)).BeginInit();
      this.categoryManagerGroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // manualEntryGroup
      // 
      this.manualEntryGroup.AutoSize = true;
      this.manualEntryGroup.Controls.Add(this.AddNewEntry);
      this.manualEntryGroup.Controls.Add(this.descriptionInput);
      this.manualEntryGroup.Controls.Add(this.description);
      this.manualEntryGroup.Controls.Add(this.amountInput);
      this.manualEntryGroup.Controls.Add(this.amountLabel);
      this.manualEntryGroup.Controls.Add(this.categoryLabel);
      this.manualEntryGroup.Controls.Add(this.existingCategories);
      this.manualEntryGroup.Location = new System.Drawing.Point(12, 12);
      this.manualEntryGroup.Name = "manualEntryGroup";
      this.manualEntryGroup.Size = new System.Drawing.Size(320, 180);
      this.manualEntryGroup.TabIndex = 0;
      this.manualEntryGroup.TabStop = false;
      this.manualEntryGroup.Text = "Add Manual Entry";
      // 
      // AddNewEntry
      // 
      this.AddNewEntry.Location = new System.Drawing.Point(19, 138);
      this.AddNewEntry.Name = "AddNewEntry";
      this.AddNewEntry.Size = new System.Drawing.Size(75, 23);
      this.AddNewEntry.TabIndex = 7;
      this.AddNewEntry.Text = "Add";
      this.AddNewEntry.UseVisualStyleBackColor = true;
      this.AddNewEntry.Click += new System.EventHandler(this.AddNewEntry_Click);
      // 
      // descriptionInput
      // 
      this.descriptionInput.Location = new System.Drawing.Point(89, 93);
      this.descriptionInput.Name = "descriptionInput";
      this.descriptionInput.Size = new System.Drawing.Size(187, 20);
      this.descriptionInput.TabIndex = 5;
      // 
      // description
      // 
      this.description.AutoSize = true;
      this.description.Location = new System.Drawing.Point(16, 96);
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
      this.amountLabel.Location = new System.Drawing.Point(16, 62);
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
      this.existingCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.existingCategories.FormattingEnabled = true;
      this.existingCategories.Location = new System.Drawing.Point(89, 24);
      this.existingCategories.Name = "existingCategories";
      this.existingCategories.Size = new System.Drawing.Size(187, 21);
      this.existingCategories.TabIndex = 0;
      // 
      // groupBox2
      // 
      this.groupBox2.AutoSize = true;
      this.groupBox2.Controls.Add(this.endDatePicker);
      this.groupBox2.Controls.Add(this.endDateLabel);
      this.groupBox2.Controls.Add(this.startDateLabel);
      this.groupBox2.Controls.Add(this.startDatePicker);
      this.groupBox2.Controls.Add(this.recordsTable);
      this.groupBox2.Location = new System.Drawing.Point(12, 198);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(614, 291);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "View";
      // 
      // endDatePicker
      // 
      this.endDatePicker.Location = new System.Drawing.Point(356, 29);
      this.endDatePicker.Name = "endDatePicker";
      this.endDatePicker.Size = new System.Drawing.Size(200, 20);
      this.endDatePicker.TabIndex = 4;
      this.endDatePicker.ValueChanged += new System.EventHandler(this.endDatePicker_ValueChanged);
      // 
      // endDateLabel
      // 
      this.endDateLabel.AutoSize = true;
      this.endDateLabel.Location = new System.Drawing.Point(295, 33);
      this.endDateLabel.Name = "endDateLabel";
      this.endDateLabel.Size = new System.Drawing.Size(55, 13);
      this.endDateLabel.TabIndex = 3;
      this.endDateLabel.Text = "End Date:";
      // 
      // startDateLabel
      // 
      this.startDateLabel.AutoSize = true;
      this.startDateLabel.Location = new System.Drawing.Point(15, 33);
      this.startDateLabel.Name = "startDateLabel";
      this.startDateLabel.Size = new System.Drawing.Size(58, 13);
      this.startDateLabel.TabIndex = 2;
      this.startDateLabel.Text = "Start Date:";
      // 
      // startDatePicker
      // 
      this.startDatePicker.Location = new System.Drawing.Point(79, 29);
      this.startDatePicker.Name = "startDatePicker";
      this.startDatePicker.Size = new System.Drawing.Size(200, 20);
      this.startDatePicker.TabIndex = 1;
      this.startDatePicker.ValueChanged += new System.EventHandler(this.startDatePicker_ValueChanged);
      // 
      // recordsTable
      // 
      this.recordsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.recordsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.recordsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntryCategory,
            this.EntryAmount,
            this.EntryDate,
            this.EntryDescription});
      this.recordsTable.Location = new System.Drawing.Point(6, 73);
      this.recordsTable.Name = "recordsTable";
      this.recordsTable.Size = new System.Drawing.Size(592, 199);
      this.recordsTable.TabIndex = 0;
      // 
      // EntryCategory
      // 
      this.EntryCategory.HeaderText = "Category";
      this.EntryCategory.Name = "EntryCategory";
      // 
      // EntryAmount
      // 
      this.EntryAmount.HeaderText = "Amount";
      this.EntryAmount.Name = "EntryAmount";
      // 
      // EntryDate
      // 
      this.EntryDate.HeaderText = "Date";
      this.EntryDate.Name = "EntryDate";
      // 
      // EntryDescription
      // 
      this.EntryDescription.HeaderText = "Description";
      this.EntryDescription.Name = "EntryDescription";
      // 
      // fixedEntryGroup
      // 
      this.fixedEntryGroup.Controls.Add(this.addFixedEntryButton);
      this.fixedEntryGroup.Location = new System.Drawing.Point(338, 12);
      this.fixedEntryGroup.Name = "fixedEntryGroup";
      this.fixedEntryGroup.Size = new System.Drawing.Size(288, 92);
      this.fixedEntryGroup.TabIndex = 2;
      this.fixedEntryGroup.TabStop = false;
      this.fixedEntryGroup.Text = "Add Fixed Entry";
      // 
      // addFixedEntryButton
      // 
      this.addFixedEntryButton.Location = new System.Drawing.Point(19, 37);
      this.addFixedEntryButton.Name = "addFixedEntryButton";
      this.addFixedEntryButton.Size = new System.Drawing.Size(75, 23);
      this.addFixedEntryButton.TabIndex = 0;
      this.addFixedEntryButton.Text = "Add";
      this.addFixedEntryButton.UseVisualStyleBackColor = true;
      this.addFixedEntryButton.Click += new System.EventHandler(this.addFixedEntryButton_Click);
      // 
      // removeSelectedEntry
      // 
      this.removeSelectedEntry.Location = new System.Drawing.Point(12, 495);
      this.removeSelectedEntry.Name = "removeSelectedEntry";
      this.removeSelectedEntry.Size = new System.Drawing.Size(130, 23);
      this.removeSelectedEntry.TabIndex = 3;
      this.removeSelectedEntry.Text = "Remove Selected";
      this.removeSelectedEntry.UseVisualStyleBackColor = true;
      this.removeSelectedEntry.Click += new System.EventHandler(this.removeSelectedEntry_Click);
      // 
      // profilingGroup
      // 
      this.profilingGroup.Controls.Add(this.monthSelectedOutput);
      this.profilingGroup.Controls.Add(this.monthSelectedToProfileLabel);
      this.profilingGroup.Controls.Add(this.budgetLabel);
      this.profilingGroup.Controls.Add(this.budgetTotalOutput);
      this.profilingGroup.Controls.Add(this.totalsTable);
      this.profilingGroup.Controls.Add(this.totalsOutput);
      this.profilingGroup.Controls.Add(this.totalLabel);
      this.profilingGroup.Location = new System.Drawing.Point(12, 524);
      this.profilingGroup.Name = "profilingGroup";
      this.profilingGroup.Size = new System.Drawing.Size(614, 253);
      this.profilingGroup.TabIndex = 4;
      this.profilingGroup.TabStop = false;
      this.profilingGroup.Text = "Profiling";
      // 
      // budgetLabel
      // 
      this.budgetLabel.AutoSize = true;
      this.budgetLabel.Location = new System.Drawing.Point(3, 102);
      this.budgetLabel.Name = "budgetLabel";
      this.budgetLabel.Size = new System.Drawing.Size(41, 13);
      this.budgetLabel.TabIndex = 10;
      this.budgetLabel.Text = "Budget";
      // 
      // budgetTotalOutput
      // 
      this.budgetTotalOutput.Location = new System.Drawing.Point(46, 99);
      this.budgetTotalOutput.Name = "budgetTotalOutput";
      this.budgetTotalOutput.ReadOnly = true;
      this.budgetTotalOutput.Size = new System.Drawing.Size(100, 20);
      this.budgetTotalOutput.TabIndex = 3;
      // 
      // totalsTable
      // 
      this.totalsTable.AllowUserToAddRows = false;
      this.totalsTable.AllowUserToDeleteRows = false;
      this.totalsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.totalsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.totalsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totalsCategory,
            this.totalsAmount});
      this.totalsTable.Location = new System.Drawing.Point(152, 19);
      this.totalsTable.Name = "totalsTable";
      this.totalsTable.ReadOnly = true;
      this.totalsTable.Size = new System.Drawing.Size(446, 220);
      this.totalsTable.TabIndex = 2;
      // 
      // totalsCategory
      // 
      this.totalsCategory.HeaderText = "Category";
      this.totalsCategory.Name = "totalsCategory";
      this.totalsCategory.ReadOnly = true;
      // 
      // totalsAmount
      // 
      this.totalsAmount.HeaderText = "Total";
      this.totalsAmount.Name = "totalsAmount";
      this.totalsAmount.ReadOnly = true;
      // 
      // totalsOutput
      // 
      this.totalsOutput.Location = new System.Drawing.Point(46, 73);
      this.totalsOutput.Name = "totalsOutput";
      this.totalsOutput.ReadOnly = true;
      this.totalsOutput.Size = new System.Drawing.Size(100, 20);
      this.totalsOutput.TabIndex = 1;
      // 
      // totalLabel
      // 
      this.totalLabel.AutoSize = true;
      this.totalLabel.Location = new System.Drawing.Point(3, 76);
      this.totalLabel.Name = "totalLabel";
      this.totalLabel.Size = new System.Drawing.Size(34, 13);
      this.totalLabel.TabIndex = 0;
      this.totalLabel.Text = "Total:";
      // 
      // categoryManagerGroup
      // 
      this.categoryManagerGroup.Controls.Add(this.updateExistingCategoryBudget);
      this.categoryManagerGroup.Controls.Add(this.addNewCategory);
      this.categoryManagerGroup.Location = new System.Drawing.Point(338, 108);
      this.categoryManagerGroup.Name = "categoryManagerGroup";
      this.categoryManagerGroup.Size = new System.Drawing.Size(288, 84);
      this.categoryManagerGroup.TabIndex = 9;
      this.categoryManagerGroup.TabStop = false;
      this.categoryManagerGroup.Text = "Category Manager";
      // 
      // updateExistingCategoryBudget
      // 
      this.updateExistingCategoryBudget.Location = new System.Drawing.Point(142, 19);
      this.updateExistingCategoryBudget.Name = "updateExistingCategoryBudget";
      this.updateExistingCategoryBudget.Size = new System.Drawing.Size(130, 46);
      this.updateExistingCategoryBudget.TabIndex = 1;
      this.updateExistingCategoryBudget.Text = "Update Existing Category Budget";
      this.updateExistingCategoryBudget.UseVisualStyleBackColor = true;
      this.updateExistingCategoryBudget.Click += new System.EventHandler(this.updateExistingBudget_Click);
      // 
      // addNewCategory
      // 
      this.addNewCategory.Location = new System.Drawing.Point(20, 19);
      this.addNewCategory.Name = "addNewCategory";
      this.addNewCategory.Size = new System.Drawing.Size(116, 46);
      this.addNewCategory.TabIndex = 0;
      this.addNewCategory.Text = "Add New Category";
      this.addNewCategory.UseVisualStyleBackColor = true;
      this.addNewCategory.Click += new System.EventHandler(this.addNewBudget_Click);
      // 
      // maximumGraphYValueLabel
      // 
      this.maximumGraphYValueLabel.AutoSize = true;
      this.maximumGraphYValueLabel.Location = new System.Drawing.Point(1086, 15);
      this.maximumGraphYValueLabel.Name = "maximumGraphYValueLabel";
      this.maximumGraphYValueLabel.Size = new System.Drawing.Size(54, 13);
      this.maximumGraphYValueLabel.TabIndex = 10;
      this.maximumGraphYValueLabel.Text = "Maximum:";
      // 
      // maximumGraphYValueInput
      // 
      this.maximumGraphYValueInput.Location = new System.Drawing.Point(1146, 12);
      this.maximumGraphYValueInput.Name = "maximumGraphYValueInput";
      this.maximumGraphYValueInput.Size = new System.Drawing.Size(100, 20);
      this.maximumGraphYValueInput.TabIndex = 11;
      this.maximumGraphYValueInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maximumGraphYValueInput_Submit);
      // 
      // monthSelectedToProfileLabel
      // 
      this.monthSelectedToProfileLabel.AutoSize = true;
      this.monthSelectedToProfileLabel.Location = new System.Drawing.Point(3, 34);
      this.monthSelectedToProfileLabel.Name = "monthSelectedToProfileLabel";
      this.monthSelectedToProfileLabel.Size = new System.Drawing.Size(37, 13);
      this.monthSelectedToProfileLabel.TabIndex = 12;
      this.monthSelectedToProfileLabel.Text = "Month";
      // 
      // monthSelectedOutput
      // 
      this.monthSelectedOutput.Location = new System.Drawing.Point(46, 31);
      this.monthSelectedOutput.Name = "monthSelectedOutput";
      this.monthSelectedOutput.ReadOnly = true;
      this.monthSelectedOutput.Size = new System.Drawing.Size(100, 20);
      this.monthSelectedOutput.TabIndex = 12;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1258, 789);
      this.Controls.Add(this.maximumGraphYValueInput);
      this.Controls.Add(this.maximumGraphYValueLabel);
      this.Controls.Add(this.categoryManagerGroup);
      this.Controls.Add(this.profilingGroup);
      this.Controls.Add(this.removeSelectedEntry);
      this.Controls.Add(this.fixedEntryGroup);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.manualEntryGroup);
      this.Name = "MainForm";
      this.Text = "Expense Monitor";
      this.manualEntryGroup.ResumeLayout(false);
      this.manualEntryGroup.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.recordsTable)).EndInit();
      this.fixedEntryGroup.ResumeLayout(false);
      this.profilingGroup.ResumeLayout(false);
      this.profilingGroup.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.totalsTable)).EndInit();
      this.categoryManagerGroup.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox manualEntryGroup;
    private System.Windows.Forms.TextBox descriptionInput;
    private System.Windows.Forms.Label description;
    private System.Windows.Forms.TextBox amountInput;
    private System.Windows.Forms.Label amountLabel;
    private System.Windows.Forms.Label categoryLabel;
    private System.Windows.Forms.ComboBox existingCategories;
    private Button AddNewEntry;
    private GroupBox groupBox2;
    private DataGridView recordsTable;
    private DataGridViewTextBoxColumn EntryCategory;
    private DataGridViewTextBoxColumn EntryAmount;
    private DataGridViewTextBoxColumn EntryDate;
    private DataGridViewTextBoxColumn EntryDescription;
    private Label startDateLabel;
    private DateTimePicker startDatePicker;
    private Label endDateLabel;
    private DateTimePicker endDatePicker;
    private GroupBox fixedEntryGroup;
    private Button addFixedEntryButton;
    private Button removeSelectedEntry;
    private GroupBox profilingGroup;
    private Label totalLabel;
    private TextBox totalsOutput;
    private DataGridView totalsTable;
    private DataGridViewTextBoxColumn totalsCategory;
    private DataGridViewTextBoxColumn totalsAmount;
    private TextBox budgetTotalOutput;
    private GroupBox categoryManagerGroup;
    private Button updateExistingCategoryBudget;
    private Button addNewCategory;
    private Label budgetLabel;
    private Label maximumGraphYValueLabel;
    private TextBox maximumGraphYValueInput;
    private Label monthSelectedToProfileLabel;
    private TextBox monthSelectedOutput;
  }
}

