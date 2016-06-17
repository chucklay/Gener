namespace Generalized_Backup_Tool.src
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveSlotLabel = new System.Windows.Forms.Label();
            this.saveSlotsTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveIntervalLabel = new System.Windows.Forms.Label();
            this.saveIntervalTextBox = new System.Windows.Forms.TextBox();
            this.backupLabel = new System.Windows.Forms.Label();
            this.backupFolderTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveSlotLabel
            // 
            this.saveSlotLabel.AutoSize = true;
            this.saveSlotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSlotLabel.Location = new System.Drawing.Point(13, 13);
            this.saveSlotLabel.Name = "saveSlotLabel";
            this.saveSlotLabel.Size = new System.Drawing.Size(230, 20);
            this.saveSlotLabel.TabIndex = 0;
            this.saveSlotLabel.Text = "Number of save slots (1-50)";
            // 
            // saveSlotsTextBox
            // 
            this.saveSlotsTextBox.Location = new System.Drawing.Point(249, 15);
            this.saveSlotsTextBox.MaxLength = 2;
            this.saveSlotsTextBox.Name = "saveSlotsTextBox";
            this.saveSlotsTextBox.Size = new System.Drawing.Size(100, 20);
            this.saveSlotsTextBox.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(12, 266);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(594, 51);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveIntervalLabel
            // 
            this.saveIntervalLabel.AutoSize = true;
            this.saveIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveIntervalLabel.Location = new System.Drawing.Point(13, 52);
            this.saveIntervalLabel.Name = "saveIntervalLabel";
            this.saveIntervalLabel.Size = new System.Drawing.Size(211, 20);
            this.saveIntervalLabel.TabIndex = 3;
            this.saveIntervalLabel.Text = "Save interval (in minutes)";
            // 
            // saveIntervalTextBox
            // 
            this.saveIntervalTextBox.Location = new System.Drawing.Point(249, 54);
            this.saveIntervalTextBox.MaxLength = 3;
            this.saveIntervalTextBox.Name = "saveIntervalTextBox";
            this.saveIntervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.saveIntervalTextBox.TabIndex = 4;
            // 
            // backupLabel
            // 
            this.backupLabel.AutoSize = true;
            this.backupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupLabel.Location = new System.Drawing.Point(13, 92);
            this.backupLabel.Name = "backupLabel";
            this.backupLabel.Size = new System.Drawing.Size(120, 20);
            this.backupLabel.TabIndex = 5;
            this.backupLabel.Text = "Backup folder";
            // 
            // backupFolderTextBox
            // 
            this.backupFolderTextBox.Enabled = false;
            this.backupFolderTextBox.Location = new System.Drawing.Point(139, 94);
            this.backupFolderTextBox.MaxLength = 3;
            this.backupFolderTextBox.Name = "backupFolderTextBox";
            this.backupFolderTextBox.Size = new System.Drawing.Size(210, 20);
            this.backupFolderTextBox.TabIndex = 6;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(355, 94);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(618, 319);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.backupFolderTextBox);
            this.Controls.Add(this.backupLabel);
            this.Controls.Add(this.saveIntervalTextBox);
            this.Controls.Add(this.saveIntervalLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.saveSlotsTextBox);
            this.Controls.Add(this.saveSlotLabel);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label saveSlotLabel;
        private System.Windows.Forms.TextBox saveSlotsTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label saveIntervalLabel;
        private System.Windows.Forms.TextBox saveIntervalTextBox;
        private System.Windows.Forms.Label backupLabel;
        private System.Windows.Forms.TextBox backupFolderTextBox;
        private System.Windows.Forms.Button browseButton;
    }
}