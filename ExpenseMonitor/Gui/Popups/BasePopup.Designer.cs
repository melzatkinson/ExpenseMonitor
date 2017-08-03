namespace ExpenseMonitor.Gui.Popups
{
  partial class BasePopup
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
      this.popupGroupBox = new System.Windows.Forms.GroupBox();
      this.closePopup = new System.Windows.Forms.Button();
      this.popupGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // popupGroupBox
      // 
      this.popupGroupBox.BackColor = System.Drawing.Color.Transparent;
      this.popupGroupBox.Controls.Add(this.closePopup);
      this.popupGroupBox.Location = new System.Drawing.Point(3, 0);
      this.popupGroupBox.Name = "popupGroupBox";
      this.popupGroupBox.Size = new System.Drawing.Size(614, 100);
      this.popupGroupBox.TabIndex = 0;
      this.popupGroupBox.TabStop = false;
      this.popupGroupBox.Text = "groupBox1";
      // 
      // closePopup
      // 
      this.closePopup.Image = global::ExpenseMonitor.Properties.Resources.close_window;
      this.closePopup.Location = new System.Drawing.Point(580, 10);
      this.closePopup.Name = "closePopup";
      this.closePopup.Size = new System.Drawing.Size(30, 30);
      this.closePopup.TabIndex = 0;
      this.closePopup.UseVisualStyleBackColor = true;
      this.closePopup.Click += new System.EventHandler(this.closePopup_Click);
      // 
      // BasePopup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.popupGroupBox);
      this.Name = "BasePopup";
      this.Size = new System.Drawing.Size(623, 412);
      this.popupGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.GroupBox popupGroupBox;
    private System.Windows.Forms.Button closePopup;
  }
}
