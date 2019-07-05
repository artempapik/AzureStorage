namespace AzureStorage
{
	partial class AskForm
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
			this.CreateLabel = new System.Windows.Forms.Label();
			this.NameLabel = new System.Windows.Forms.Label();
			this.CreateTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// CreateLabel
			// 
			this.CreateLabel.AutoSize = true;
			this.CreateLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CreateLabel.Location = new System.Drawing.Point(12, 9);
			this.CreateLabel.Name = "CreateLabel";
			this.CreateLabel.Size = new System.Drawing.Size(97, 19);
			this.CreateLabel.TabIndex = 0;
			this.CreateLabel.Text = "Some Text";
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NameLabel.Location = new System.Drawing.Point(12, 59);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(48, 16);
			this.NameLabel.TabIndex = 1;
			this.NameLabel.Text = "Name:";
			// 
			// CreateTextBox
			// 
			this.CreateTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CreateTextBox.Location = new System.Drawing.Point(15, 80);
			this.CreateTextBox.Name = "CreateTextBox";
			this.CreateTextBox.Size = new System.Drawing.Size(224, 23);
			this.CreateTextBox.TabIndex = 2;
			this.CreateTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateTextBox_KeyDown);
			// 
			// AskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(251, 115);
			this.Controls.Add(this.CreateTextBox);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.CreateLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AskForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label CreateLabel;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox CreateTextBox;
	}
}