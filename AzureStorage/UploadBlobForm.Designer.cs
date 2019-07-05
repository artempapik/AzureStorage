namespace AzureStorage
{
	partial class UploadBlobForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadBlobForm));
			this.NameLabel = new System.Windows.Forms.Label();
			this.UploadBlobLabel = new System.Windows.Forms.Label();
			this.UploadBlobButton = new System.Windows.Forms.Button();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.PageBlob = new System.Windows.Forms.RadioButton();
			this.BlockBlob = new System.Windows.Forms.RadioButton();
			this.UploadButton = new System.Windows.Forms.Button();
			this.UploadBlobDialog = new System.Windows.Forms.OpenFileDialog();
			this.BlobName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NameLabel.Location = new System.Drawing.Point(12, 89);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(48, 16);
			this.NameLabel.TabIndex = 3;
			this.NameLabel.Text = "Name:";
			// 
			// UploadBlobLabel
			// 
			this.UploadBlobLabel.AutoSize = true;
			this.UploadBlobLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UploadBlobLabel.Location = new System.Drawing.Point(12, 9);
			this.UploadBlobLabel.Name = "UploadBlobLabel";
			this.UploadBlobLabel.Size = new System.Drawing.Size(158, 19);
			this.UploadBlobLabel.TabIndex = 2;
			this.UploadBlobLabel.Text = "Upload Cloud Blob";
			// 
			// UploadBlobButton
			// 
			this.UploadBlobButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UploadBlobButton.BackgroundImage")));
			this.UploadBlobButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.UploadBlobButton.FlatAppearance.BorderSize = 0;
			this.UploadBlobButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UploadBlobButton.Location = new System.Drawing.Point(175, 55);
			this.UploadBlobButton.Name = "UploadBlobButton";
			this.UploadBlobButton.Size = new System.Drawing.Size(25, 25);
			this.UploadBlobButton.TabIndex = 4;
			this.UploadBlobButton.UseVisualStyleBackColor = true;
			this.UploadBlobButton.Click += new System.EventHandler(this.UploadBlobButton_Click);
			// 
			// TypeLabel
			// 
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TypeLabel.Location = new System.Drawing.Point(12, 59);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(43, 16);
			this.TypeLabel.TabIndex = 5;
			this.TypeLabel.Text = "Type:";
			// 
			// PageBlob
			// 
			this.PageBlob.AutoSize = true;
			this.PageBlob.Checked = true;
			this.PageBlob.Location = new System.Drawing.Point(61, 59);
			this.PageBlob.Name = "PageBlob";
			this.PageBlob.Size = new System.Drawing.Size(50, 17);
			this.PageBlob.TabIndex = 6;
			this.PageBlob.TabStop = true;
			this.PageBlob.Text = "Page";
			this.PageBlob.UseVisualStyleBackColor = true;
			// 
			// BlockBlob
			// 
			this.BlockBlob.AutoSize = true;
			this.BlockBlob.Location = new System.Drawing.Point(117, 59);
			this.BlockBlob.Name = "BlockBlob";
			this.BlockBlob.Size = new System.Drawing.Size(52, 17);
			this.BlockBlob.TabIndex = 7;
			this.BlockBlob.TabStop = true;
			this.BlockBlob.Text = "Block";
			this.BlockBlob.UseVisualStyleBackColor = true;
			// 
			// UploadButton
			// 
			this.UploadButton.Enabled = false;
			this.UploadButton.Location = new System.Drawing.Point(72, 119);
			this.UploadButton.Name = "UploadButton";
			this.UploadButton.Size = new System.Drawing.Size(75, 26);
			this.UploadButton.TabIndex = 8;
			this.UploadButton.Text = "Upload";
			this.UploadButton.UseVisualStyleBackColor = true;
			this.UploadButton.Click += new System.EventHandler(this.UploadButton_ClickAsync);
			// 
			// BlobName
			// 
			this.BlobName.AutoSize = true;
			this.BlobName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BlobName.Location = new System.Drawing.Point(58, 89);
			this.BlobName.Name = "BlobName";
			this.BlobName.Size = new System.Drawing.Size(43, 16);
			this.BlobName.TabIndex = 9;
			this.BlobName.Text = "name";
			this.BlobName.Visible = false;
			// 
			// UploadBlobForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(221, 158);
			this.Controls.Add(this.BlobName);
			this.Controls.Add(this.UploadButton);
			this.Controls.Add(this.BlockBlob);
			this.Controls.Add(this.PageBlob);
			this.Controls.Add(this.TypeLabel);
			this.Controls.Add(this.UploadBlobButton);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.UploadBlobLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UploadBlobForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label UploadBlobLabel;
		private System.Windows.Forms.Button UploadBlobButton;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.RadioButton PageBlob;
		private System.Windows.Forms.RadioButton BlockBlob;
		private System.Windows.Forms.Button UploadButton;
		private System.Windows.Forms.OpenFileDialog UploadBlobDialog;
		private System.Windows.Forms.Label BlobName;
	}
}