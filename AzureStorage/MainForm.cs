using Microsoft.WindowsAzure.Storage.DataMovement;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System;

namespace AzureStorage
{
	public partial class MainForm : Form
	{
		static CloudStorageAccount Account { get; set; } = CloudStorageAccount.DevelopmentStorageAccount;
		public static CloudBlobClient Client { get; set; } = Account.CreateCloudBlobClient();
		public static string Answer { get; set; }

		public MainForm()
		{
			InitializeComponent();
			AccountLabel.Text = Client.Credentials.AccountName;
			RefreshAll();
		}

		void RefreshAll()
		{
			Answer = null;
			Containers.Nodes.Clear();
			var directories = new List<CloudBlobDirectory>();

			foreach (var container in Client.ListContainers())
			{
				TreeNode c = Containers.Nodes.Add(container.Name);
				c.ImageIndex = 0;

				foreach (var blob in container.ListBlobs())
				{
					TreeNode node;
					switch (blob)
					{
						case CloudBlobDirectory cbd:
							node = c.Nodes.Add(blob.Uri.Directory());
							directories.Add(blob as CloudBlobDirectory);
							node.ImageIndex = 1;
							node.SelectedImageIndex = 1;
							RefreshAll(directories.ToArray(), node);
							directories.Clear();
							break;
						case CloudBlob cb:
							node = c.Nodes.Add(blob.Uri.File());
							node.ImageIndex = 2;
							node.SelectedImageIndex = 2;
							break;
					}
				}
			}
		}

		void RefreshAll(CloudBlobDirectory[] directories, TreeNode treeNode)
		{
			if (directories.Length == 0)
			{
				return;
			}

			var destDirectories = new List<CloudBlobDirectory>();

			foreach (var directory in directories)
			{
				foreach (var blob in directory.ListBlobs())
				{
					TreeNode node;
					switch (blob)
					{
						case CloudBlobDirectory cbd:
							node = treeNode.Nodes.Add(blob.Uri.Directory());
							node.ImageIndex = 1;
							node.SelectedImageIndex = 1;
							destDirectories.Add(blob as CloudBlobDirectory);
							RefreshAll(destDirectories.ToArray(), node);
							destDirectories.Clear();
							break;
						case CloudBlob cb:
							node = treeNode.Nodes.Add(blob.Uri.File());
							node.ImageIndex = 2;
							node.SelectedImageIndex = 2;
							break;
					}
				}
			}
		}

		async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode node = Containers.SelectedNode;
			if (node == null)
			{
				MessageBox.Show("Choose an item to delete first");
				return;
			}

			CloudBlobContainer container;
			CloudBlobDirectory directory;
			CloudBlob blob;
			TreeNode parentNode = node.Parent;

			switch (node.ImageIndex)
			{
				case 0:
					container = Client.GetContainerReference(node.Text);
					await container.DeleteIfExistsAsync();
					break;
				case 1:
					switch (parentNode.ImageIndex)
					{
						case 0:
							container = Client.GetContainerReference(parentNode.Text);
							directory = container.GetDirectoryReference(node.Text);
							await DeleteDirectory(directory);
							break;
						case 1:
							(TreeNode containerNode, int count, string[] hier) = GetContainerNode(parentNode);
							Array.Reverse(hier);

							container = Client.GetContainerReference(containerNode.Text);
							directory = container.GetDirectoryReference(hier[0]);

							for (int i = 0; i < count; i++)
							{
								directory = directory.GetDirectoryReference(hier[i + 1]);
							}
							directory = directory.GetDirectoryReference(node.Text);
							await DeleteDirectory(directory);
							break;
					}
					break;
				case 2:
					switch (parentNode.ImageIndex)
					{
						case 0:
							container = Client.GetContainerReference(parentNode.Text);
							blob = container.GetBlobReference(node.Text);
							await blob.DeleteIfExistsAsync();
							break;
						case 1:
							(TreeNode containerNode, int count, string[] hier) = GetContainerNode(parentNode);
							Array.Reverse(hier);

							container = Client.GetContainerReference(containerNode.Text);
							directory = container.GetDirectoryReference(hier[0]);

							for (int i = 0; i < count; i++)
							{
								directory = directory.GetDirectoryReference(hier[i + 1]);
							}
							blob = directory.GetBlobReference(node.Text);
							await blob.DeleteIfExistsAsync();
							break;
					}
					break;
			}
			RefreshAll();
		}

		async void RenameToolStripMenuItem_ClickAsync(object sender, EventArgs e)
		{
			TreeNode node = Containers.SelectedNode;
			if (node == null)
			{
				MessageBox.Show("Choose an item to rename first");
				return;
			}

			CloudBlobDirectory sourceDir;
			CloudBlobDirectory targetDir;
			var options = new CopyDirectoryOptions { Recursive = true };
			TreeNode parentNode = node.Parent;

			switch (node.ImageIndex)
			{
				case 0:
					new AskForm("Rename Container").ShowDialog();
					if (Answer == null)
					{
						return;
					}

					if (!Answer.Any(n => n.IsLetter()))
					{
						MessageBox.Show("Russian is not allowed");
						return;
					}
					ProgressBar.Visible = true;

					CloudBlobContainer sourceC = Client.GetContainerReference(node.Text);
					CloudBlobContainer targetC = Client.GetContainerReference(Answer);
					await targetC.CreateIfNotExistsAsync();

					foreach (var blob in sourceC.ListBlobs())
					{
						switch (blob)
						{
							case CloudBlobDirectory cbd:
								sourceDir = sourceC.GetDirectoryReference(blob.Uri.Directory());
								targetDir = targetC.GetDirectoryReference(blob.Uri.Directory());
								await TransferManager.CopyDirectoryAsync(sourceDir, targetDir, true, options, null);
								break;
							case CloudBlob cb:
								CloudBlob sourceBlob = sourceC.GetBlobReference(blob.Uri.File());
								CloudBlob targetBlob = targetC.GetBlobReference(blob.Uri.File());
								await TransferManager.CopyAsync(sourceBlob, targetBlob, true);
								break;
						}
					}
					await sourceC.DeleteIfExistsAsync();
					break;
				case 1:
					switch (parentNode.ImageIndex)
					{
						case 0:
							CloudBlobContainer container = Client.GetContainerReference(parentNode.Text);
							sourceDir = container.GetDirectoryReference(node.Text);

							new AskForm("Rename Directory").ShowDialog();
							if (Answer == null)
							{
								return;
							}
							ProgressBar.Visible = true;

							targetDir = container.GetDirectoryReference(Answer);
							await TransferManager.CopyDirectoryAsync(sourceDir, targetDir, true, options, null);
							await DeleteDirectory(sourceDir);
							break;
						case 1:
							(TreeNode containerNode, int count, string[] hier) = GetContainerNode(parentNode);
							Array.Reverse(hier);

							container = Client.GetContainerReference(containerNode.Text);
							sourceDir = container.GetDirectoryReference(hier[0]);

							for (int i = 0; i < count; i++)
							{
								sourceDir = sourceDir.GetDirectoryReference(hier[i + 1]);
							}
							sourceDir = sourceDir.GetDirectoryReference(node.Text);

							new AskForm("Rename Directory").ShowDialog();
							if (Answer == null)
							{
								return;
							}
							ProgressBar.Visible = true;

							targetDir = sourceDir.Parent.GetDirectoryReference(Answer);
							await TransferManager.CopyDirectoryAsync(sourceDir, targetDir, true, options, null);
							await DeleteDirectory(sourceDir);
							break;
					}
					break;
				case 2:
					switch (parentNode.ImageIndex)
					{
						case 0:
							CloudBlobContainer container = Client.GetContainerReference(parentNode.Text);
							CloudBlob sourceBlob = container.GetBlobReference(node.Text);

							new AskForm("Rename Cloud Blob").ShowDialog();
							if (Answer == null)
							{
								return;
							}
							ProgressBar.Visible = true;

							CloudBlob targetBlob = container.GetBlobReference(Answer);
							await TransferManager.CopyAsync(sourceBlob, targetBlob, true);
							await sourceBlob.DeleteIfExistsAsync();
							break;
						case 1:
							(TreeNode containerNode, int count, string[] hier) = GetContainerNode(parentNode);
							Array.Reverse(hier);

							container = Client.GetContainerReference(containerNode.Text);
							sourceDir = container.GetDirectoryReference(hier[0]);

							for (int i = 0; i < count; i++)
							{
								sourceDir = sourceDir.GetDirectoryReference(hier[i + 1]);
							}
							sourceBlob = sourceDir.GetBlobReference(node.Text);

							new AskForm("Rename Cloud Blob").ShowDialog();
							if (Answer == null)
							{
								return;
							}
							ProgressBar.Visible = true;

							targetBlob = sourceDir.GetBlobReference(Answer);
							await TransferManager.CopyAsync(sourceBlob, targetBlob, true);
							await sourceBlob.DeleteIfExistsAsync();
							break;
					}
					break;
			}
			RefreshAll();
			ProgressBar.Visible = false;
		}

		async void CreateContainer_ClickAsync(object sender, EventArgs e)
		{
			new AskForm("Create New Container").ShowDialog();
			if (Answer == null)
			{
				return;
			}

			if (!Answer.Any(n => n.IsLetter()))
			{
				MessageBox.Show("Russian is not allowed");
				return;
			}

			CloudBlobContainer container = Client.GetContainerReference(Answer);
			await container.CreateIfNotExistsAsync();
			RefreshAll();
		}

		void CreateDirectory_Click(object sender, EventArgs e)
		{
			TreeNode node = Containers.SelectedNode;
			if (node == null)
			{
				return;
			}

			if (node.ImageIndex == 2)
			{
				node = node.Parent;
			}

			new AskForm("Create New Directory").ShowDialog();
			if (Answer == null)
			{
				return;
			}

			CloudBlobContainer container;
			CloudBlobDirectory directory;

			switch (node.ImageIndex)
			{
				case 0:
					container = Client.GetContainerReference(node.Text);
					directory = container.GetDirectoryReference(Answer);
					new UploadBlobForm(directory).ShowDialog();
					break;
				case 1:
					(TreeNode containerNode, int count, string[] hier) = GetContainerNode(node);
					Array.Reverse(hier);

					container = Client.GetContainerReference(containerNode.Text);
					directory = container.GetDirectoryReference(hier[0]);

					for (int i = 0; i < count; i++)
					{
						directory = directory.GetDirectoryReference(hier[i + 1]);
					}

					directory = directory.GetDirectoryReference(Answer);
					new UploadBlobForm(directory).ShowDialog();
					break;
			}
			RefreshAll();
		}

		void UploadBlob_Click(object sender, EventArgs e)
		{
			TreeNode node = Containers.SelectedNode;
			if (node == null)
			{
				return;
			}

			if (node.ImageIndex == 2)
			{
				node = node.Parent;
			}

			CloudBlobContainer container;
			switch (node.ImageIndex)
			{
				case 0:
					container = Client.GetContainerReference(node.Text);
					new UploadBlobForm(container).ShowDialog();
					break;
				case 1:
					(TreeNode containerNode, int count, string[] hier) = GetContainerNode(node);
					Array.Reverse(hier);

					container = Client.GetContainerReference(containerNode.Text);
					CloudBlobDirectory directory = container.GetDirectoryReference(hier[0]);

					for (int i = 0; i < count; i++)
					{
						directory = directory.GetDirectoryReference(hier[i + 1]);
					}

					new UploadBlobForm(directory).ShowDialog();
					break;
			}
			RefreshAll();
		}

		void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode node = Containers.SelectedNode;
			if (node == null)
			{
				MessageBox.Show("Choose an item first");
				return;
			}

			CloudBlobContainer container;
			CloudBlobDirectory directory;

			switch (node.ImageIndex)
			{
				case 0:
					container = Client.GetContainerReference(node.Text);
					MessageBox.Show
					(
						$"Name: {container.Name}\n" +
						$"Uri: {container.Uri}\n" +
						$"Etag: {container.Properties.ETag}\n" +
						$"Last Modified: {container.Properties.LastModified}\n" +
						$"Lease Status: {container.Properties.LeaseStatus}",
						$"{node.Text} Properties"
					);
					break;
				case 1:
					(TreeNode containerNode, int count, string[] hier) = GetContainerNode(node);
					Array.Reverse(hier);

					container = Client.GetContainerReference(containerNode.Text);
					directory = container.GetDirectoryReference(hier[0]);

					for (int i = 0; i < count; i++)
					{
						directory = directory.GetDirectoryReference(hier[i + 1]);
					}

					MessageBox.Show
					(
						$"Container: {directory.Container.Name}\n" +
						$"Parent: {directory.Parent}\n" +
						$"Prefix: {directory.Prefix}\n" +
						$"Uri: {directory.Uri}",
						$"{node.Text} Properties"
					);
					break;
				case 2:
					(TreeNode containerNode, int count, string[] hier) t = GetContainerNode(node);
					Array.Reverse(t.hier);

					container = Client.GetContainerReference(t.containerNode.Text);
					directory = container.GetDirectoryReference(t.hier[0]);

					for (int i = 0; i < t.count; i++)
					{
						directory = directory.GetDirectoryReference(t.hier[i + 1]);
					}
					CloudBlob blob = directory.GetBlobReference(node.Text);

					MessageBox.Show
					(
						$"Name: {blob.Name}\n" +
						$"Container: {blob.Container.Name}\n" +
						$"Blob Type: {blob.Properties.BlobType}\n" +
						$"Content Encoding: {blob.Properties.ContentEncoding}\n" +
						$"Length: {blob.Properties.Length}",
						$"{node.Text} Properties"
					);
					break;
			}
		}

		(TreeNode, int, string[]) GetContainerNode(TreeNode node)
		{
			var hier = new List<string>();
			int count = 0;

			while (node.Parent != null)
			{
				hier.Add(node.Text);
				node = node.Parent;
				count++;
			}
			return (node, --count, hier.ToArray());
		}

		async Task DeleteDirectory(CloudBlobDirectory directory)
		{
			foreach (var blob in directory.ListBlobs())
			{
				switch (blob)
				{
					case CloudBlobDirectory cbd:
						await DeleteDirectory(cbd);
						break;
					case CloudBlob cb:
						await cb.DeleteIfExistsAsync();
						break;
				}
			}
		}
	}
}