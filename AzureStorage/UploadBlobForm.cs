using Microsoft.WindowsAzure.Storage.Blob;
using System.Windows.Forms;
using System;

namespace AzureStorage
{
	public partial class UploadBlobForm : Form
	{
		new CloudBlobContainer Container { get; set; }
		CloudBlobDirectory Directory { get; set; }
		ICloudBlob Blob { get; set; }

		public UploadBlobForm(CloudBlobContainer container)
		{
			InitializeComponent();
			Container = container;
		}

		public UploadBlobForm(CloudBlobDirectory directory)
		{
			InitializeComponent();
			Directory = directory;
		}

		void UploadBlobButton_Click(object sender, EventArgs e)
		{
			if (UploadBlobDialog.ShowDialog() == DialogResult.OK)
			{
				if (Container != null)
				{
					if (PageBlob.Checked)
					{
						Blob = Container.GetPageBlobReference(UploadBlobDialog.SafeFileName);
					}
					else
					{
						Blob = Container.GetBlockBlobReference(UploadBlobDialog.SafeFileName);
					}
				}
				else
				{
					if (PageBlob.Checked)
					{
						Blob = Directory.GetPageBlobReference(UploadBlobDialog.SafeFileName);
					}
					else
					{
						Blob = Directory.GetBlockBlobReference(UploadBlobDialog.SafeFileName);
					}
				}
				BlobName.Text = UploadBlobDialog.SafeFileName;
				BlobName.Visible = true;
				UploadButton.Enabled = true;
			}
		}

		async void UploadButton_ClickAsync(object sender, EventArgs e)
		{
			await Blob.UploadFromFileAsync(UploadBlobDialog.FileName);
			Close();
		}
	}
}