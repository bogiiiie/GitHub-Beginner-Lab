using System;
using System.Windows.Forms;

namespace StudentProfile
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			txtYearLevel.Text = "8";
		}

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			// Get the email input and remove any extra spaces
			string email = txtEmailAddress.Text.Trim();

			// Validate the email before saving
			if (IsValidEmail(email))
			{
				// Prevent double-submits by disabling the button temporarily
				btnSubmit.Enabled = false;

				// Notify the user of a successful update
				MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Clear the input fields for the next entry
				txtEmailAddress.Clear();
				txtPhoneNumber.Clear();

				// Re-enable the button after processing
				btnSubmit.Enabled = true;
			}
			else
			{
				// Show an error message if the email format is invalid
				MessageBox.Show("Please enter a valid email address (e.g., name@domain.com).", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// Highlight the email field so the user knows where the error is
				txtEmailAddress.Focus();
				txtEmailAddress.SelectAll();
			}
		}

		// Helper method to check if the email format is valid
		private bool IsValidEmail(string email)
		{
			// Reject empty or whitespace-only input
			if (string.IsNullOrWhiteSpace(email))
				return false;

			try
			{
				// Use a regex pattern to require an '@' symbol and a domain
				return System.Text.RegularExpressions.Regex.IsMatch(email,
					@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
					System.Text.RegularExpressions.RegexOptions.IgnoreCase);
			}
			catch
			{
				// Return false if the regex throws an error
				return false;
			}
		}
	}
}