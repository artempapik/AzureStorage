using System.Windows.Forms;
using System.Linq;
using System;

namespace AzureStorage
{
	public partial class AskForm : Form
	{
		public AskForm(string text)
		{
			InitializeComponent();
			CreateLabel.Text = text;
		}

		void CreateTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (CreateTextBox.Text == String.Empty)
			{
				return;
			}

			string answer = CreateTextBox.Text;
			answer = answer.ToLower().Trim();

			if (e.KeyCode == Keys.Enter)
			{
				if (answer.Length < 3 || answer.Any(n => Char.IsDigit(n)))
				{
					MessageBox.Show
					(
						"Name must be:\n" +
						"- more than 2 symbols\n" +
						"- in lower case\n" +
						"- digits and letters are allowed"
					);
					return;
				}
				MainForm.Answer = answer;
				Close();
			}
		}
	}
}