
namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
    partial class AsynchronousBatchFileCopy
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
            this.TargetFolderLabel = new System.Windows.Forms.Label();
            this.TargetFolderTextBox = new System.Windows.Forms.TextBox();
            this.BrowseForTargetFolder = new System.Windows.Forms.Button();
            this.SourceFilesButton = new System.Windows.Forms.Button();
            this.CopyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BufferSizeLabel = new System.Windows.Forms.Label();
            this.BufferSizeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TargetFolderLabel
            // 
            this.TargetFolderLabel.AutoSize = true;
            this.TargetFolderLabel.Location = new System.Drawing.Point(13, 13);
            this.TargetFolderLabel.Name = "TargetFolderLabel";
            this.TargetFolderLabel.Size = new System.Drawing.Size(75, 15);
            this.TargetFolderLabel.TabIndex = 0;
            this.TargetFolderLabel.Text = "Target Folder";
            // 
            // TargetFolderTextBox
            // 
            this.TargetFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetFolderTextBox.Location = new System.Drawing.Point(13, 32);
            this.TargetFolderTextBox.Name = "TargetFolderTextBox";
            this.TargetFolderTextBox.Size = new System.Drawing.Size(471, 23);
            this.TargetFolderTextBox.TabIndex = 1;
            // 
            // BrowseForTargetFolder
            // 
            this.BrowseForTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseForTargetFolder.Location = new System.Drawing.Point(491, 31);
            this.BrowseForTargetFolder.Name = "BrowseForTargetFolder";
            this.BrowseForTargetFolder.Size = new System.Drawing.Size(28, 23);
            this.BrowseForTargetFolder.TabIndex = 2;
            this.BrowseForTargetFolder.Text = "...";
            this.BrowseForTargetFolder.UseVisualStyleBackColor = true;
            this.BrowseForTargetFolder.Click += new System.EventHandler(this.BrowseForTargetFolder_Click);
            // 
            // SourceFilesButton
            // 
            this.SourceFilesButton.Location = new System.Drawing.Point(13, 71);
            this.SourceFilesButton.Name = "SourceFilesButton";
            this.SourceFilesButton.Size = new System.Drawing.Size(92, 23);
            this.SourceFilesButton.TabIndex = 3;
            this.SourceFilesButton.Text = "Source Files";
            this.SourceFilesButton.UseVisualStyleBackColor = true;
            this.SourceFilesButton.Click += new System.EventHandler(this.SourceFilesButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyButton.Enabled = false;
            this.CopyButton.Location = new System.Drawing.Point(363, 179);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(75, 23);
            this.CopyButton.TabIndex = 4;
            this.CopyButton.Text = "Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Visible = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(445, 179);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BufferSizeLabel
            // 
            this.BufferSizeLabel.AutoSize = true;
            this.BufferSizeLabel.Location = new System.Drawing.Point(13, 108);
            this.BufferSizeLabel.Name = "BufferSizeLabel";
            this.BufferSizeLabel.Size = new System.Drawing.Size(289, 15);
            this.BufferSizeLabel.TabIndex = 6;
            this.BufferSizeLabel.Text = "BufferSize - 81920 is the default use internally for .NET";
            // 
            // BufferSizeComboBox
            // 
            this.BufferSizeComboBox.FormattingEnabled = true;
            this.BufferSizeComboBox.Items.AddRange(new object[] {
            "8192",
            "81920"});
            this.BufferSizeComboBox.Location = new System.Drawing.Point(13, 127);
            this.BufferSizeComboBox.Name = "BufferSizeComboBox";
            this.BufferSizeComboBox.Size = new System.Drawing.Size(218, 23);
            this.BufferSizeComboBox.TabIndex = 7;
            this.BufferSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // AsynchronousBatchFileCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 214);
            this.Controls.Add(this.BufferSizeComboBox);
            this.Controls.Add(this.BufferSizeLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.SourceFilesButton);
            this.Controls.Add(this.BrowseForTargetFolder);
            this.Controls.Add(this.TargetFolderTextBox);
            this.Controls.Add(this.TargetFolderLabel);
            this.Name = "AsynchronousBatchFileCopy";
            this.Text = "Asynchronous File Copy with Item and Batch Progress";
            this.Load += new System.EventHandler(this.AsynchronousBatchFileCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TargetFolderLabel;
        private System.Windows.Forms.TextBox TargetFolderTextBox;
        private System.Windows.Forms.Button BrowseForTargetFolder;
        private System.Windows.Forms.Button SourceFilesButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label BufferSizeLabel;
        private System.Windows.Forms.ComboBox BufferSizeComboBox;
    }
}

