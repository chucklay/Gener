namespace Generalized_Backup_Tool
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.addGameButton = new System.Windows.Forms.Button();
            this.GameList = new System.Windows.Forms.ListView();
            this.gameName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gameImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.processNameTextBox = new System.Windows.Forms.TextBox();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.saveFilesTextBox = new System.Windows.Forms.TextBox();
            this.saveFilesLabel = new System.Windows.Forms.Label();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.savePathLabel = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.gameNameChangeLabel = new System.Windows.Forms.Label();
            this.GameLabel = new System.Windows.Forms.Label();
            this.pathBrowseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.addGameButton);
            this.splitContainer1.Panel1.Controls.Add(this.GameList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pathBrowseButton);
            this.splitContainer1.Panel2.Controls.Add(this.saveChangesButton);
            this.splitContainer1.Panel2.Controls.Add(this.processNameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.processNameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.saveFilesTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.saveFilesLabel);
            this.splitContainer1.Panel2.Controls.Add(this.savePathTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.savePathLabel);
            this.splitContainer1.Panel2.Controls.Add(this.gameNameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.gameNameChangeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.GameLabel);
            this.splitContainer1.Size = new System.Drawing.Size(948, 560);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // addGameButton
            // 
            this.addGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGameButton.Location = new System.Drawing.Point(0, 514);
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Size = new System.Drawing.Size(202, 46);
            this.addGameButton.TabIndex = 1;
            this.addGameButton.Text = "Add Game";
            this.addGameButton.UseVisualStyleBackColor = true;
            this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
            // 
            // GameList
            // 
            this.GameList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.GameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gameName,
            this.gameImage});
            this.GameList.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameList.GridLines = true;
            this.GameList.Location = new System.Drawing.Point(0, 0);
            this.GameList.MultiSelect = false;
            this.GameList.Name = "GameList";
            this.GameList.Size = new System.Drawing.Size(205, 508);
            this.GameList.TabIndex = 0;
            this.GameList.UseCompatibleStateImageBehavior = false;
            this.GameList.View = System.Windows.Forms.View.List;
            this.GameList.SelectedIndexChanged += new System.EventHandler(this.GameList_SelectedIndexChanged);
            // 
            // gameName
            // 
            this.gameName.DisplayIndex = 1;
            this.gameName.Text = "Game Name";
            this.gameName.Width = 332;
            // 
            // gameImage
            // 
            this.gameImage.DisplayIndex = 0;
            this.gameImage.Text = "Game Image";
            this.gameImage.Width = 88;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveChangesButton.Enabled = false;
            this.saveChangesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveChangesButton.Location = new System.Drawing.Point(3, 514);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(733, 46);
            this.saveChangesButton.TabIndex = 9;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(14, 212);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(294, 20);
            this.processNameTextBox.TabIndex = 8;
            this.processNameTextBox.Visible = false;
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processNameLabel.Location = new System.Drawing.Point(10, 190);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(118, 19);
            this.processNameLabel.TabIndex = 7;
            this.processNameLabel.Text = "Process name";
            this.processNameLabel.Visible = false;
            // 
            // saveFilesTextBox
            // 
            this.saveFilesTextBox.Location = new System.Drawing.Point(14, 167);
            this.saveFilesTextBox.Name = "saveFilesTextBox";
            this.saveFilesTextBox.Size = new System.Drawing.Size(294, 20);
            this.saveFilesTextBox.TabIndex = 6;
            this.saveFilesTextBox.Visible = false;
            // 
            // saveFilesLabel
            // 
            this.saveFilesLabel.AutoSize = true;
            this.saveFilesLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFilesLabel.Location = new System.Drawing.Point(10, 145);
            this.saveFilesLabel.Name = "saveFilesLabel";
            this.saveFilesLabel.Size = new System.Drawing.Size(435, 19);
            this.saveFilesLabel.TabIndex = 5;
            this.saveFilesLabel.Text = "Save file names (Blank to back up all, comma separated)";
            this.saveFilesLabel.Visible = false;
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Enabled = false;
            this.savePathTextBox.Location = new System.Drawing.Point(14, 122);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(294, 20);
            this.savePathTextBox.TabIndex = 4;
            this.savePathTextBox.Visible = false;
            // 
            // savePathLabel
            // 
            this.savePathLabel.AutoSize = true;
            this.savePathLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePathLabel.Location = new System.Drawing.Point(10, 100);
            this.savePathLabel.Name = "savePathLabel";
            this.savePathLabel.Size = new System.Drawing.Size(86, 19);
            this.savePathLabel.TabIndex = 3;
            this.savePathLabel.Text = "Save Path";
            this.savePathLabel.Visible = false;
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Location = new System.Drawing.Point(14, 77);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.Size = new System.Drawing.Size(294, 20);
            this.gameNameTextBox.TabIndex = 2;
            this.gameNameTextBox.Visible = false;
            // 
            // gameNameChangeLabel
            // 
            this.gameNameChangeLabel.AutoSize = true;
            this.gameNameChangeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameNameChangeLabel.Location = new System.Drawing.Point(10, 54);
            this.gameNameChangeLabel.Name = "gameNameChangeLabel";
            this.gameNameChangeLabel.Size = new System.Drawing.Size(101, 19);
            this.gameNameChangeLabel.TabIndex = 1;
            this.gameNameChangeLabel.Text = "Game Name";
            this.gameNameChangeLabel.Visible = false;
            // 
            // GameLabel
            // 
            this.GameLabel.AutoSize = true;
            this.GameLabel.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLabel.Location = new System.Drawing.Point(3, 9);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(305, 41);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "Game Name Here";
            this.GameLabel.Visible = false;
            // 
            // pathBrowseButton
            // 
            this.pathBrowseButton.Location = new System.Drawing.Point(314, 122);
            this.pathBrowseButton.Name = "pathBrowseButton";
            this.pathBrowseButton.Size = new System.Drawing.Size(99, 20);
            this.pathBrowseButton.TabIndex = 10;
            this.pathBrowseButton.Text = "Browse";
            this.pathBrowseButton.UseVisualStyleBackColor = true;
            this.pathBrowseButton.Visible = false;
            this.pathBrowseButton.Click += new System.EventHandler(this.pathBrowseButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(948, 560);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Generalized Backup Tool";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView GameList;
        private System.Windows.Forms.Button addGameButton;
        private System.Windows.Forms.ColumnHeader gameName;
        private System.Windows.Forms.ColumnHeader gameImage;
        private System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.Label gameNameChangeLabel;
        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Label saveFilesLabel;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Label savePathLabel;
        private System.Windows.Forms.TextBox saveFilesTextBox;
        private System.Windows.Forms.Label processNameLabel;
        private System.Windows.Forms.TextBox processNameTextBox;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Button pathBrowseButton;
    }
}

