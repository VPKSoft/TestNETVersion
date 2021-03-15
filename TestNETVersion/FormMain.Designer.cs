
namespace TestNETVersion
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbApplicationTypeSelection = new System.Windows.Forms.ComboBox();
            this.lbApplicationTypeSelection = new System.Windows.Forms.Label();
            this.lbVersions = new System.Windows.Forms.ListBox();
            this.lbMinimumVersion = new System.Windows.Forms.Label();
            this.lbMaximumVersion = new System.Windows.Forms.Label();
            this.lbMinimumVersionValue = new System.Windows.Forms.Label();
            this.lbMaximumVersionValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbApplicationTypeSelection
            // 
            this.cmbApplicationTypeSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbApplicationTypeSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplicationTypeSelection.FormattingEnabled = true;
            this.cmbApplicationTypeSelection.Location = new System.Drawing.Point(147, 12);
            this.cmbApplicationTypeSelection.Name = "cmbApplicationTypeSelection";
            this.cmbApplicationTypeSelection.Size = new System.Drawing.Size(324, 23);
            this.cmbApplicationTypeSelection.TabIndex = 0;
            this.cmbApplicationTypeSelection.SelectedValueChanged += new System.EventHandler(this.cmbApplicationTypeSelection_SelectedValueChanged);
            // 
            // lbApplicationTypeSelection
            // 
            this.lbApplicationTypeSelection.AutoSize = true;
            this.lbApplicationTypeSelection.Location = new System.Drawing.Point(12, 15);
            this.lbApplicationTypeSelection.Name = "lbApplicationTypeSelection";
            this.lbApplicationTypeSelection.Size = new System.Drawing.Size(129, 15);
            this.lbApplicationTypeSelection.TabIndex = 1;
            this.lbApplicationTypeSelection.Text = "Select application type:";
            // 
            // lbVersions
            // 
            this.lbVersions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVersions.FormattingEnabled = true;
            this.lbVersions.IntegralHeight = false;
            this.lbVersions.ItemHeight = 15;
            this.lbVersions.Location = new System.Drawing.Point(12, 41);
            this.lbVersions.Name = "lbVersions";
            this.lbVersions.Size = new System.Drawing.Size(190, 175);
            this.lbVersions.TabIndex = 2;
            // 
            // lbMinimumVersion
            // 
            this.lbMinimumVersion.AutoSize = true;
            this.lbMinimumVersion.Location = new System.Drawing.Point(208, 41);
            this.lbMinimumVersion.Name = "lbMinimumVersion";
            this.lbMinimumVersion.Size = new System.Drawing.Size(104, 15);
            this.lbMinimumVersion.TabIndex = 3;
            this.lbMinimumVersion.Text = "Minimum version:";
            // 
            // lbMaximumVersion
            // 
            this.lbMaximumVersion.AutoSize = true;
            this.lbMaximumVersion.Location = new System.Drawing.Point(208, 78);
            this.lbMaximumVersion.Name = "lbMaximumVersion";
            this.lbMaximumVersion.Size = new System.Drawing.Size(106, 15);
            this.lbMaximumVersion.TabIndex = 4;
            this.lbMaximumVersion.Text = "Maximum version:";
            // 
            // lbMinimumVersionValue
            // 
            this.lbMinimumVersionValue.AutoSize = true;
            this.lbMinimumVersionValue.Location = new System.Drawing.Point(334, 41);
            this.lbMinimumVersionValue.Name = "lbMinimumVersionValue";
            this.lbMinimumVersionValue.Size = new System.Drawing.Size(12, 15);
            this.lbMinimumVersionValue.TabIndex = 5;
            this.lbMinimumVersionValue.Text = "-";
            // 
            // lbMaximumVersionValue
            // 
            this.lbMaximumVersionValue.AutoSize = true;
            this.lbMaximumVersionValue.Location = new System.Drawing.Point(334, 78);
            this.lbMaximumVersionValue.Name = "lbMaximumVersionValue";
            this.lbMaximumVersionValue.Size = new System.Drawing.Size(12, 15);
            this.lbMaximumVersionValue.TabIndex = 6;
            this.lbMaximumVersionValue.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 228);
            this.Controls.Add(this.lbMaximumVersionValue);
            this.Controls.Add(this.lbMinimumVersionValue);
            this.Controls.Add(this.lbMaximumVersion);
            this.Controls.Add(this.lbMinimumVersion);
            this.Controls.Add(this.lbVersions);
            this.Controls.Add(this.lbApplicationTypeSelection);
            this.Controls.Add(this.cmbApplicationTypeSelection);
            this.Name = "FormMain";
            this.Text = "Test NET version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbApplicationTypeSelection;
        private System.Windows.Forms.Label lbApplicationTypeSelection;
        private System.Windows.Forms.ListBox lbVersions;
        private System.Windows.Forms.Label lbMinimumVersion;
        private System.Windows.Forms.Label lbMaximumVersion;
        private System.Windows.Forms.Label lbMinimumVersionValue;
        private System.Windows.Forms.Label lbMaximumVersionValue;
    }
}

