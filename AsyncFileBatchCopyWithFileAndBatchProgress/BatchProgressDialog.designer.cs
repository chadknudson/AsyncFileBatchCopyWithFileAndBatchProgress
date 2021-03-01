namespace AsyncFileBatchCopyWithFileAndBatchProgress
{
	partial class BatchProgressDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchProgressDialog));
            this.ItemProgressBar = new System.Windows.Forms.ProgressBar();
            this.CurrentItemLabel = new System.Windows.Forms.Label();
            this.OverallProgressLabel = new System.Windows.Forms.Label();
            this.OverallProgressBar = new System.Windows.Forms.ProgressBar();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ItemProgressBar
            // 
            this.ItemProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemProgressBar.Location = new System.Drawing.Point(12, 27);
            this.ItemProgressBar.Name = "ItemProgressBar";
            this.ItemProgressBar.Size = new System.Drawing.Size(340, 23);
            this.ItemProgressBar.TabIndex = 0;
            // 
            // CurrentItemLabel
            // 
            this.CurrentItemLabel.AutoSize = true;
            this.CurrentItemLabel.Location = new System.Drawing.Point(9, 9);
            this.CurrentItemLabel.Name = "CurrentItemLabel";
            this.CurrentItemLabel.Size = new System.Drawing.Size(64, 13);
            this.CurrentItemLabel.TabIndex = 1;
            this.CurrentItemLabel.Text = "Current Item";
            // 
            // OverallProgressLabel
            // 
            this.OverallProgressLabel.AutoSize = true;
            this.OverallProgressLabel.Location = new System.Drawing.Point(9, 64);
            this.OverallProgressLabel.Name = "OverallProgressLabel";
            this.OverallProgressLabel.Size = new System.Drawing.Size(84, 13);
            this.OverallProgressLabel.TabIndex = 3;
            this.OverallProgressLabel.Text = "Overall Progress";
            // 
            // OverallProgressBar
            // 
            this.OverallProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OverallProgressBar.Location = new System.Drawing.Point(12, 80);
            this.OverallProgressBar.Name = "OverallProgressBar";
            this.OverallProgressBar.Size = new System.Drawing.Size(340, 23);
            this.OverallProgressBar.TabIndex = 2;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(151, 121);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BatchProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 156);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OverallProgressLabel);
            this.Controls.Add(this.OverallProgressBar);
            this.Controls.Add(this.CurrentItemLabel);
            this.Controls.Add(this.ItemProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatchProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Norse Technologies";
            this.Load += new System.EventHandler(this.DialogStatus_Load);
            this.Click += new System.EventHandler(this.DialogStatus_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar ItemProgressBar;
        private System.Windows.Forms.Label CurrentItemLabel;
        private System.Windows.Forms.Label OverallProgressLabel;
        private System.Windows.Forms.ProgressBar OverallProgressBar;
        private System.Windows.Forms.Button CancelButton;
    }
}