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
      this.addNewCategory = new System.Windows.Forms.Label();
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
      this.changeBudget = new System.Windows.Forms.Label();
      this.fixedEntryGroup = new System.Windows.Forms.GroupBox();
      this.addFixedEntryButton = new System.Windows.Forms.Button();
      this.removeSelectedEntry = new System.Windows.Forms.Button();
      this.manualEntryGroup.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.recordsTable)).BeginInit();
      this.fixedEntryGroup.SuspendLayout();
      this.SuspendLayout();
      // 
      // manualEntryGroup
      // 
      this.manualEntryGroup.AutoSize = true;
      this.manualEntryGroup.Controls.Add(this.changeBudget);
      this.manualEntryGroup.Controls.Add(this.AddNewEntry);
      this.manualEntryGroup.Controls.Add(this.addNewCategory);
      this.manualEntryGroup.Controls.Add(this.descriptionInput);
      this.manualEntryGroup.Controls.Add(this.description);
      this.manualEntryGroup.Controls.Add(this.amountInput);
      this.manualEntryGroup.Controls.Add(this.amountLabel);
      this.manualEntryGroup.Controls.Add(this.categoryLabel);
      this.manualEntryGroup.Controls.Add(this.existingCategories);
      this.manualEntryGroup.Location = new System.Drawing.Point(25, 28);
      this.manualEntryGroup.Name = "manualEntryGroup";
      this.manualEntryGroup.Size = new System.Drawing.Size(618, 180);
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
      // addNewCategory
      // 
      this.addNewCategory.AutoSize = true;
      this.addNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.addNewCategory.ForeColor = System.Drawing.SystemColors.Highlight;
      this.addNewCategory.Location = new System.Drawing.Point(295, 32);
      this.addNewCategory.Name = "addNewCategory";
      this.addNewCategory.Size = new System.Drawing.Size(49, 13);
      this.addNewCategory.TabIndex = 6;
      this.addNewCategory.Text = "Add new";
      this.addNewCategory.Click += new System.EventHandler(this.addNewCategory_Click);
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
      this.groupBox2.Location = new System.Drawing.Point(25, 298);
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
      // changeBudget
      // 
      this.changeBudget.AutoSize = true;
      this.changeBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.changeBudget.ForeColor = System.Drawing.SystemColors.Highlight;
      this.changeBudget.Location = new System.Drawing.Point(342, 32);
      this.changeBudget.Name = "changeBudget";
      this.changeBudget.Size = new System.Drawing.Size(89, 13);
      this.changeBudget.TabIndex = 8;
      this.changeBudget.Text = "/  Update budget";
      this.changeBudget.Click += new System.EventHandler(this.changeBudget_Click);
      // 
      // fixedEntryGroup
      // 
      this.fixedEntryGroup.Controls.Add(this.addFixedEntryButton);
      this.fixedEntryGroup.Location = new System.Drawing.Point(25, 215);
      this.fixedEntryGroup.Name = "fixedEntryGroup";
      this.fixedEntryGroup.Size = new System.Drawing.Size(614, 77);
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
      this.removeSelectedEntry.Location = new System.Drawing.Point(31, 596);
      this.removeSelectedEntry.Name = "removeSelectedEntry";
      this.removeSelectedEntry.Size = new System.Drawing.Size(130, 23);
      this.removeSelectedEntry.TabIndex = 3;
      this.removeSelectedEntry.Text = "Remove Selected";
      this.removeSelectedEntry.UseVisualStyleBackColor = true;
      this.removeSelectedEntry.Click += new System.EventHandler(this.removeSelectedEntry_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(679, 641);
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
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox manualEntryGroup;
    private System.Windows.Forms.Label addNewCategory;
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
    private Label changeBudget;
    private GroupBox fixedEntryGroup;
    private Button addFixedEntryButton;
    private Button removeSelectedEntry;
  }
}

