using System;
using System.Windows.Forms;

namespace StudentProfile
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			string email = txtEmailAddress.Text.Trim();

			if (IsValidEmail(email))
			{
				MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Please enter a valid email address (e.g., name@domain.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtEmailAddress.Focus();
				txtEmailAddress.SelectAll();
			}
		}

		private bool IsValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			try
			{
				return System.Text.RegularExpressions.Regex.IsMatch(email,
					@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
					System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			}
			catch
			{
				return false;
			}
		}
	}
}