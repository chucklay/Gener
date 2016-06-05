namespace Generalized_Backup_Tool
{
    partial class AddGame
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.GameNameTextBox = new System.Windows.Forms.TextBox();
            this.SavePathLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.FileNamesLabel = new System.Windows.Forms.Label();
            this.saveFilesTextBox = new System.Windows.Forms.TextBox();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.processNameTextBox = new System.Windows.Forms.TextBox();
            this.registerGameButton = new System.Windows.Forms.Button();
            this.filesExampleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.AutoSize = true;
            this.GameNameLabel.Location = new System.Drawing.Point(13, 13);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(66, 13);
            this.GameNameLabel.TabIndex = 0;
            this.GameNameLabel.Text = "Game Name";
            // 
            // GameNameTextBox
            // 
            this.GameNameTextBox.Location = new System.Drawing.Point(16, 30);
            this.GameNameTextBox.Name = "GameNameTextBox";
            this.GameNameTextBox.Size = new System.Drawing.Size(267, 20);
            this.GameNameTextBox.TabIndex = 1;
            // 
            // SavePathLabel
            // 
            this.SavePathLabel.AutoSize = true;
            this.SavePathLabel.Location = new System.Drawing.Point(13, 73);
            this.SavePathLabel.Name = "SavePathLabel";
            this.SavePathLabel.Size = new System.Drawing.Size(57, 13);
            this.SavePathLabel.TabIndex = 2;
            this.SavePathLabel.Text = "Save Path";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(290, 89);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Enabled = false;
            this.savePathTextBox.Location = new System.Drawing.Point(16, 89);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(267, 20);
            this.savePathTextBox.TabIndex = 5;
            // 
            // FileNamesLabel
            // 
            this.FileNamesLabel.AutoSize = true;
            this.FileNamesLabel.Location = new System.Drawing.Point(13, 133);
            this.FileNamesLabel.Name = "FileNamesLabel";
            this.FileNamesLabel.Size = new System.Drawing.Size(212, 13);
            this.FileNamesLabel.TabIndex = 6;
            this.FileNamesLabel.Text = "Save Files (Leave blank to back up all files)";
            // 
            // saveFilesTextBox
            // 
            this.saveFilesTextBox.Location = new System.Drawing.Point(16, 178);
            this.saveFilesTextBox.Name = "saveFilesTextBox";
            this.saveFilesTextBox.Size = new System.Drawing.Size(267, 20);
            this.saveFilesTextBox.TabIndex = 7;
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(13, 220);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(187, 13);
            this.processNameLabel.TabIndex = 9;
            this.processNameLabel.Text = "Process Name (Do not include \".exe\")";
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(16, 236);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(267, 20);
            this.processNameTextBox.TabIndex = 10;
            // 
            // registerGameButton
            // 
            this.registerGameButton.Location = new System.Drawing.Point(16, 295);
            this.registerGameButton.Name = "registerGameButton";
            this.registerGameButton.Size = new System.Drawing.Size(595, 71);
            this.registerGameButton.TabIndex = 11;
            this.registerGameButton.Text = "OK";
            this.registerGameButton.UseVisualStyleBackColor = true;
            this.registerGameButton.Click += new System.EventHandler(this.registerGameButton_Click);
            // 
            // filesExampleLabel
            // 
            this.filesExampleLabel.AutoSize = true;
            this.filesExampleLabel.Location = new System.Drawing.Point(13, 149);
            this.filesExampleLabel.Name = "filesExampleLabel";
            this.filesExampleLabel.Size = new System.Drawing.Size(166, 26);
            this.filesExampleLabel.TabIndex = 12;
            this.filesExampleLabel.Text = "Example:\r\nsave1.sav, save2.sav, save3.sav";
            // 
            // AddGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(623, 378);
            this.Controls.Add(this.filesExampleLabel);
            this.Controls.Add(this.registerGameButton);
            this.Controls.Add(this.processNameTextBox);
            this.Controls.Add(this.processNameLabel);
            this.Controls.Add(this.saveFilesTextBox);
            this.Controls.Add(this.FileNamesLabel);
            this.Controls.Add(this.savePathTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.SavePathLabel);
            this.Controls.Add(this.GameNameTextBox);
            this.Controls.Add(this.GameNameLabel);
            this.Name = "AddGame";
            this.Text = "AddGame";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.TextBox GameNameTextBox;
        private System.Windows.Forms.Label SavePathLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Label FileNamesLabel;
        private System.Windows.Forms.TextBox saveFilesTextBox;
        private System.Windows.Forms.Label processNameLabel;
        private System.Windows.Forms.TextBox processNameTextBox;
        private System.Windows.Forms.Button registerGameButton;
        private System.Windows.Forms.Label filesExampleLabel;
    }
}