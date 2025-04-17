using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Athlete_Management
{
    public partial class AddEditAthleteForm : Form
    {
        private Athlete _currentAthlete; // The Athlete object being added or edited.
        private DatabaseHelper _dbHelper; // Instance of the DatabaseHelper to save the data.

        public AddEditAthleteForm(Athlete athleteToEdit)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper("athlete.xml"); // Use the same XML le.
            _currentAthlete = athleteToEdit;
            // If an athlete is being edited, populate the form with the athlete's data.
            if (_currentAthlete != null)
            {
                Text = "Edit Athlete"; // Set the form title.
                txtBibNumber.Text = _currentAthlete.BibNumber;
                txtFirstName.Text = _currentAthlete.FirstName;
                txtLastName.Text = _currentAthlete.LastName;
                txtTeam.Text = _currentAthlete.Team;
                txtAge.Text = _currentAthlete.Age?.ToString(); // Use null-conditional operator and ToString()
                txtGender.Text = _currentAthlete.Gender;
                txtContactInfo.Text = _currentAthlete.ContactInfo;
                txtBibNumber.ReadOnly = true; // Prevent editing the Bib Number for existing athletes.
            }
            else
            {
                // If a new athlete is being added, set the form title.
                Text = "Add New Athlete";
            }

        }


        private void txtBibNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Basic input validation: Check for required elds.
            if (string.IsNullOrWhiteSpace(txtBibNumber.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text)
            || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter Bib Number, First Name, and Last Name.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the save operation if validation fails.
            }
            // If we are adding a new athlete (_currentAthlete is null), create a new Athlete object.
            if (_currentAthlete == null)
            {
                _currentAthlete = new Athlete
                {
                    BibNumber = txtBibNumber.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Team = txtTeam.Text,
                    Age = string.IsNullOrEmpty(txtAge.Text) ? (int?)null : int.Parse(txtAge.Text), // Use null if empty
                    Gender = txtGender.Text,
                    ContactInfo = txtContactInfo.Text
                };
                _dbHelper.AddAthlete(_currentAthlete); // Add the new athlete to the XML le.
            }
            else
            {
                // If we are editing an existing athlete, update the properties of the existing _currentAthlete object.
                _currentAthlete.BibNumber = txtBibNumber.Text; // In a real application, you might want to prevent the user from changing the BibNumber.
                _currentAthlete.FirstName = txtFirstName.Text;
                _currentAthlete.LastName = txtLastName.Text;
                _currentAthlete.Team = txtTeam.Text;
                _currentAthlete.Age = string.IsNullOrEmpty(txtAge.Text) ? (int?)null : int.Parse(txtAge.Text);
                _currentAthlete.Gender = txtGender.Text;
                _currentAthlete.ContactInfo = txtContactInfo.Text;
                _dbHelper.UpdateAthlete(_currentAthlete); // Update the athlete in the XML le.
            }
            DialogResult = DialogResult.OK; // Set the dialog result to OK to signal that the data was saved successfully.
            Close(); // Close the form.
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Set the dialog result to Cancel if the user cancels.
            Close(); // Close the form.
        }
    }
}
