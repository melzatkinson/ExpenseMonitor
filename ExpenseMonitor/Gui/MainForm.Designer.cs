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
      this.viewRecordsGroupbox = new System.Windows.Forms.GroupBox();
      this.endDatePicker = new System.Windows.Forms.DateTimePicker();
      this.endDateLabel = new System.Windows.Forms.Label();
      this.startDateLabel = new System.Windows.Forms.Label();
      this.startDatePicker = new System.Windows.Forms.DateTimePicker();
      this.recordsTable = new System.Windows.Forms.DataGridView();
      this.EntryCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EntryAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EntryDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.removeSelectedEntry = new System.Windows.Forms.Button();
      this.profilingGroup = new System.Windows.Forms.GroupBox();
      this.monthSelectedOutput = new System.Windows.Forms.TextBox();
      this.monthSelectedToProfileLabel = new System.Windows.Forms.Label();
      this.budgetLabel = new System.Windows.Forms.Label();
      this.budgetTotalOutput = new System.Windows.Forms.TextBox();
      this.totalsTable = new System.Windows.Forms.DataGridView();
      this.totalsCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalsOutput = new System.Windows.Forms.TextBox();
      this.totalLabel = new System.Windows.Forms.Label();
      this.functionOptions = new System.Windows.Forms.GroupBox();
      this.functionOptionsInput = new System.Windows.Forms.ComboBox();
      this.viewRecordsGroupbox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.recordsTable)).BeginInit();
      this.profilingGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.totalsTable)).BeginInit();
      this.functionOptions.SuspendLayout();
      this.SuspendLayout();
      // 
      // viewRecordsGroupbox
      // 
      this.viewRecordsGroupbox.AutoSize = true;
      this.viewRecordsGroupbox.BackColor = System.Drawing.Color.Transparent;
      this.viewRecordsGroupbox.Controls.Add(this.endDatePicker);
      this.viewRecordsGroupbox.Controls.Add(this.endDateLabel);
      this.viewRecordsGroupbox.Controls.Add(this.startDateLabel);
      this.viewRecordsGroupbox.Controls.Add(this.startDatePicker);
      this.viewRecordsGroupbox.Controls.Add(this.recordsTable);
      this.viewRecordsGroupbox.Location = new System.Drawing.Point(12, 92);
      this.viewRecordsGroupbox.Name = "viewRecordsGroupbox";
      this.viewRecordsGroupbox.Size = new System.Drawing.Size(620, 291);
      this.viewRecordsGroupbox.TabIndex = 1;
      this.viewRecordsGroupbox.TabStop = false;
      this.viewRecordsGroupbox.Text = "View";
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
      // removeSelectedEntry
      // 
      this.removeSelectedEntry.Location = new System.Drawing.Point(12, 390);
      this.removeSelectedEntry.Name = "removeSelectedEntry";
      this.removeSelectedEntry.Size = new System.Drawing.Size(130, 23);
      this.removeSelectedEntry.TabIndex = 3;
      this.removeSelectedEntry.Text = "Remove Selected";
      this.removeSelectedEntry.UseVisualStyleBackColor = true;
      this.removeSelectedEntry.Click += new System.EventHandler(this.removeSelectedEntry_Click);
      // 
      // profilingGroup
      // 
      this.profilingGroup.BackColor = System.Drawing.Color.Transparent;
      this.profilingGroup.Controls.Add(this.monthSelectedOutput);
      this.profilingGroup.Controls.Add(this.monthSelectedToProfileLabel);
      this.profilingGroup.Controls.Add(this.budgetLabel);
      this.profilingGroup.Controls.Add(this.budgetTotalOutput);
      this.profilingGroup.Controls.Add(this.totalsTable);
      this.profilingGroup.Controls.Add(this.totalsOutput);
      this.profilingGroup.Controls.Add(this.totalLabel);
      this.profilingGroup.Location = new System.Drawing.Point(12, 419);
      this.profilingGroup.Name = "profilingGroup";
      this.profilingGroup.Size = new System.Drawing.Size(614, 253);
      this.profilingGroup.TabIndex = 4;
      this.profilingGroup.TabStop = false;
      this.profilingGroup.Text = "Profiling";
      // 
      // monthSelectedOutput
      // 
      this.monthSelectedOutput.Location = new System.Drawing.Point(46, 31);
      this.monthSelectedOutput.Name = "monthSelectedOutput";
      this.monthSelectedOutput.ReadOnly = true;
      this.monthSelectedOutput.Size = new System.Drawing.Size(100, 20);
      this.monthSelectedOutput.TabIndex = 12;
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
      // functionOptions
      // 
      this.functionOptions.BackColor = System.Drawing.Color.Transparent;
      this.functionOptions.Controls.Add(this.functionOptionsInput);
      this.functionOptions.Location = new System.Drawing.Point(12, 12);
      this.functionOptions.Name = "functionOptions";
      this.functionOptions.Size = new System.Drawing.Size(614, 74);
      this.functionOptions.TabIndex = 10;
      this.functionOptions.TabStop = false;
      this.functionOptions.Text = "Add/Update";
      // 
      // functionOptionsInput
      // 
      this.functionOptionsInput.FormattingEnabled = true;
      this.functionOptionsInput.Items.AddRange(new object[] {
            "Add Manual Entry",
            "Add Recurring Entry",
            "Add New Category",
            "Update Existing Category Budget"});
      this.functionOptionsInput.Location = new System.Drawing.Point(18, 33);
      this.functionOptionsInput.Name = "functionOptionsInput";
      this.functionOptionsInput.Size = new System.Drawing.Size(284, 21);
      this.functionOptionsInput.TabIndex = 0;
      this.functionOptionsInput.SelectedIndexChanged += new System.EventHandler(this.functionOptionsInput_SelectedIndexChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::ExpenseMonitor.Properties.Resources.MainBackground;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.ClientSize = new System.Drawing.Size(1194, 686);
      this.Controls.Add(this.functionOptions);
      this.Controls.Add(this.profilingGroup);
      this.Controls.Add(this.removeSelectedEntry);
      this.Controls.Add(this.viewRecordsGroupbox);
      this.Name = "MainForm";
      this.Text = "Expense Monitor";
      this.viewRecordsGroupbox.ResumeLayout(false);
      this.viewRecordsGroupbox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.recordsTable)).EndInit();
      this.profilingGroup.ResumeLayout(false);
      this.profilingGroup.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.totalsTable)).EndInit();
      this.functionOptions.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private GroupBox viewRecordsGroupbox;
    private DataGridView recordsTable;
    private DataGridViewTextBoxColumn EntryCategory;
    private DataGridViewTextBoxColumn EntryAmount;
    private DataGridViewTextBoxColumn EntryDate;
    private DataGridViewTextBoxColumn EntryDescription;
    private Label startDateLabel;
    private DateTimePicker startDatePicker;
    private Label endDateLabel;
    private DateTimePicker endDatePicker;
    private Button removeSelectedEntry;
    private GroupBox profilingGroup;
    private Label totalLabel;
    private TextBox totalsOutput;
    private DataGridView totalsTable;
    private DataGridViewTextBoxColumn totalsCategory;
    private DataGridViewTextBoxColumn totalsAmount;
    private TextBox budgetTotalOutput;
    private Label budgetLabel;
    private Label monthSelectedToProfileLabel;
    private TextBox monthSelectedOutput;
    private GroupBox functionOptions;
    private ComboBox functionOptionsInput;
  }
}

