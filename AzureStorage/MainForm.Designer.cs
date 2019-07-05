namespace AzureStorage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.Containers = new System.Windows.Forms.TreeView();
			this.ContainerContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ContainersImages = new System.Windows.Forms.ImageList(this.components);
			this.CreateContainer = new System.Windows.Forms.Button();
			this.AccountLabel = new System.Windows.Forms.Label();
			this.CreateDirectory = new System.Windows.Forms.Button();
			this.UploadBlob = new System.Windows.Forms.Button();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.ContainerContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// Containers
			// 
			this.Containers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Containers.BackColor = System.Drawing.SystemColors.Control;
			this.Containers.ContextMenuStrip = this.ContainerContextMenu;
			this.Containers.ImageIndex = 0;
			this.Containers.ImageList = this.ContainersImages;
			this.Containers.Location = new System.Drawing.Point(12, 43);
			this.Containers.Name = "Containers";
			this.Containers.SelectedImageIndex = 0;
			this.Containers.Size = new System.Drawing.Size(324, 349);
			this.Containers.TabIndex = 0;
			// 
			// ContainerContextMenu
			// 
			this.ContainerContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem,
            this.RenameToolStripMenuItem,
            this.PropertiesToolStripMenuItem});
			this.ContainerContextMenu.Name = "ContainerContextMenu";
			this.ContainerContextMenu.Size = new System.Drawing.Size(165, 70);
			// 
			// DeleteToolStripMenuItem
			// 
			this.DeleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripMenuItem.Image")));
			this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
			this.DeleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
			this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.DeleteToolStripMenuItem.Text = "Delete";
			this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// RenameToolStripMenuItem
			// 
			this.RenameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RenameToolStripMenuItem.Image")));
			this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
			this.RenameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
			this.RenameToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.RenameToolStripMenuItem.Text = "Rename...";
			this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_ClickAsync);
			// 
			// PropertiesToolStripMenuItem
			// 
			this.PropertiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PropertiesToolStripMenuItem.Image")));
			this.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem";
			this.PropertiesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
			this.PropertiesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.PropertiesToolStripMenuItem.Text = "Properties";
			this.PropertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
			// 
			// ContainersImages
			// 
			this.ContainersImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ContainersImages.ImageStream")));
			this.ContainersImages.TransparentColor = System.Drawing.Color.Transparent;
			this.ContainersImages.Images.SetKeyName(0, "container");
			this.ContainersImages.Images.SetKeyName(1, "folder.ico");
			this.ContainersImages.Images.SetKeyName(2, "file.ico");
			// 
			// CreateContainer
			// 
			this.CreateContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CreateContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateContainer.BackgroundImage")));
			this.CreateContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CreateContainer.FlatAppearance.BorderSize = 0;
			this.CreateContainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreateContainer.Location = new System.Drawing.Point(249, 12);
			this.CreateContainer.Name = "CreateContainer";
			this.CreateContainer.Size = new System.Drawing.Size(25, 25);
			this.CreateContainer.TabIndex = 2;
			this.CreateContainer.UseVisualStyleBackColor = true;
			this.CreateContainer.Click += new System.EventHandler(this.CreateContainer_ClickAsync);
			// 
			// AccountLabel
			// 
			this.AccountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AccountLabel.Location = new System.Drawing.Point(12, 12);
			this.AccountLabel.Name = "AccountLabel";
			this.AccountLabel.Size = new System.Drawing.Size(231, 25);
			this.AccountLabel.TabIndex = 4;
			this.AccountLabel.Text = "Account";
			this.AccountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CreateDirectory
			// 
			this.CreateDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CreateDirectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreateDirectory.BackgroundImage")));
			this.CreateDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CreateDirectory.FlatAppearance.BorderSize = 0;
			this.CreateDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreateDirectory.Location = new System.Drawing.Point(280, 12);
			this.CreateDirectory.Name = "CreateDirectory";
			this.CreateDirectory.Size = new System.Drawing.Size(25, 25);
			this.CreateDirectory.TabIndex = 5;
			this.CreateDirectory.UseVisualStyleBackColor = true;
			this.CreateDirectory.Click += new System.EventHandler(this.CreateDirectory_Click);
			// 
			// UploadBlob
			// 
			this.UploadBlob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.UploadBlob.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UploadBlob.BackgroundImage")));
			this.UploadBlob.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.UploadBlob.FlatAppearance.BorderSize = 0;
			this.UploadBlob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UploadBlob.Location = new System.Drawing.Point(311, 12);
			this.UploadBlob.Name = "UploadBlob";
			this.UploadBlob.Size = new System.Drawing.Size(25, 25);
			this.UploadBlob.TabIndex = 6;
			this.UploadBlob.UseVisualStyleBackColor = true;
			this.UploadBlob.Click += new System.EventHandler(this.UploadBlob_Click);
			// 
			// ProgressBar
			// 
			this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ProgressBar.Location = new System.Drawing.Point(145, 18);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(94, 12);
			this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.ProgressBar.TabIndex = 7;
			this.ProgressBar.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(348, 404);
			this.Controls.Add(this.ProgressBar);
			this.Controls.Add(this.UploadBlob);
			this.Controls.Add(this.CreateContainer);
			this.Controls.Add(this.CreateDirectory);
			this.Controls.Add(this.AccountLabel);
			this.Controls.Add(this.Containers);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ContainerContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ImageList ContainersImages;
		private System.Windows.Forms.ContextMenuStrip ContainerContextMenu;
		private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
		private System.Windows.Forms.Button CreateContainer;
		private System.Windows.Forms.Label AccountLabel;
		private System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem;
		private System.Windows.Forms.Button CreateDirectory;
		private System.Windows.Forms.Button UploadBlob;
		private System.Windows.Forms.TreeView Containers;
		private System.Windows.Forms.ProgressBar ProgressBar;
	}
}

